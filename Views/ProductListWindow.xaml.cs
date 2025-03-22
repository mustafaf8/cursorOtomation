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
            cmbCategoryFilter.SelectedIndex = 0; // "Tümü" seçeneğini seç
            LoadProducts();
        }

        private void LoadProducts()
        {
            var query = _context.Products.AsQueryable();

            // Kategori filtresi
            if (cmbCategoryFilter.SelectedIndex > 0) // 0 = "Tümü"
            {
                var selectedCategory = (cmbCategoryFilter.SelectedItem as ComboBoxItem)?.Content.ToString();
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

            dgProducts.ItemsSource = query
                .OrderBy(p => p.Category)
                .ThenBy(p => p.Name)
                .ToList();
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadProducts();
        }

        private void CmbCategoryFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                    LoadProducts();
                }
                catch
                {
                    MessageBox.Show(
                        "Ürün silinirken bir hata oluştu.",
                        "Hata",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
        }
    }
} 