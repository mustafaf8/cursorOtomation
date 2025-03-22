using System;
using System.Windows;
using SolarAutomation.Data;
using SolarAutomation.Models;

namespace SolarAutomation.Views
{
    public partial class ProductWindow : Window
    {
        private readonly ApplicationDbContext _context;
        private Product? _product;

        public ProductWindow(Product? product = null)
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            _product = product;

            if (_product != null)
            {
                LoadProductData();
            }
        }

        private void LoadProductData()
        {
            if (_product == null) return;

            txtName.Text = _product.Name;
            txtDescription.Text = _product.Description;
            txtPrice.Text = _product.Price.ToString("N2");
            txtStock.Text = _product.StockQuantity.ToString();
            txtPower.Text = _product.PowerOutput.ToString("N2");
            txtManufacturer.Text = _product.Manufacturer;
            cmbCategory.Text = _product.Category;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Lütfen ürün adını giriniz.", "Hata", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Lütfen geçerli bir fiyat giriniz.", "Hata", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(txtStock.Text, out int stock))
            {
                MessageBox.Show("Lütfen geçerli bir stok miktarı giriniz.", "Hata", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!double.TryParse(txtPower.Text, out double power))
            {
                MessageBox.Show("Lütfen geçerli bir güç değeri giriniz.", "Hata", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                if (_product == null)
                {
                    _product = new Product();
                    _context.Products.Add(_product);
                }

                _product.Name = txtName.Text;
                _product.Description = txtDescription.Text;
                _product.Price = price;
                _product.StockQuantity = stock;
                _product.PowerOutput = power;
                _product.Manufacturer = txtManufacturer.Text;
                _product.Category = cmbCategory.Text;

                _context.SaveChanges();
                MessageBox.Show("Ürün başarıyla kaydedildi.", "Bilgi", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kayıt sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
} 