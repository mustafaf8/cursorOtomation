using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using SolarAutomation.Data;
using SolarAutomation.Models;

namespace SolarAutomation.Views
{
    public partial class ProductListWindow : Window
    {
        private readonly ApplicationDbContext _context;

        public ProductListWindow()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                // Tüm özellikleri dahil ederek tam Product nesnelerini alalım
                var query = _context.Products.AsQueryable();

                // Kategori filtresi
                var selectedCategory = (cmbCategoryFilter.SelectedItem as ComboBoxItem)?.Content.ToString();
                if (!string.IsNullOrEmpty(selectedCategory))
                {
                    query = query.Where(p => p.Category == selectedCategory);
                }

                // Arama filtresi
                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    var searchText = txtSearch.Text.ToLower();
                    query = query.Where(p =>
                        p.Name.ToLower().Contains(searchText) ||
                        p.Manufacturer.ToLower().Contains(searchText));
                }

                // Şebeke desteği filtresi
                if (rbGridSupported.IsChecked == true)
                {
                    query = query.Where(p => p.IsGridSupported == true);
                }
                else if (rbGridUnsupported.IsChecked == true)
                {
                    query = query.Where(p => p.IsGridSupported == false);
                }

                // DataGrid'e veriyi atayalım
                dgProducts.ItemsSource = query
                    .OrderBy(p => p.Category)
                    .ThenBy(p => p.Name)
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürünleri yüklerken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadProducts();
        }

        private void CmbCategoryFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCategory = (cmbCategoryFilter.SelectedItem as ComboBoxItem)?.Content.ToString();
            if (selectedCategory == "Tarımsal Ges")
            {
                spGridSupportOptions.Visibility = Visibility.Visible;
            }
            else
            {
                spGridSupportOptions.Visibility = Visibility.Collapsed;
                rbGridSupported.IsChecked = false;
                rbGridUnsupported.IsChecked = false;
            }
            LoadProducts();
        }

        private void RbGridSupport_Checked(object sender, RoutedEventArgs e)
        {
            LoadProducts();
        }

        private void BtnNewProduct_Click(object sender, RoutedEventArgs e)
        {
            var productWindow = new ProductWindow();
            productWindow.Owner = this;
            if (productWindow.ShowDialog() == true)
            {
                LoadProducts();
            }
        }

        private void DgProducts_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            EditSelectedProduct();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedProduct();
        }

        private void EditSelectedProduct()
        {
            var selectedProduct = dgProducts.SelectedItem as Product;
            if (selectedProduct == null) return;

            var productWindow = new ProductWindow(selectedProduct);
            productWindow.Owner = this;
            if (productWindow.ShowDialog() == true)
            {
                LoadProducts();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var product = (sender as Button)?.DataContext as Product;
            if (product == null) return;

            var result = MessageBox.Show(
                $"'{product.Name}' ürününü silmek istediğinizden emin misiniz?",
                "Ürün Silme",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    // Veritabanından ürünü ID'ye göre bulalım ve silelim
                    var dbProduct = _context.Products.Find(product.Id);
                    if (dbProduct != null)
                    {
                        _context.Products.Remove(dbProduct);
                        _context.SaveChanges();
                        LoadProducts();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Ürün silinirken bir hata oluştu: {ex.Message}",
                        "Hata",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
        }
    }
}