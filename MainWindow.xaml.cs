using System.Windows;
using System.Windows.Input;
using SolarAutomation.Views;
using SolarAutomation.Data;
using System;

namespace SolarAutomation
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            try
            {
                using var context = new ApplicationDbContext();

                // Recreate the database with current model
                context.MigrateDatabase();

                // Veritabanının başarıyla oluşturulduğunu kontrol et
                if (context.Database.CanConnect())
                {
                    Console.WriteLine("Veritabanı başarıyla oluşturuldu.");
                }
                else
                {
                    MessageBox.Show("Veritabanına bağlanılamadı.", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veritabanı oluşturulurken hata: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NewProduct_Click(object sender, RoutedEventArgs e)
        {
            OpenProductWindow();
        }

        private void NewProduct_Click(object sender, MouseButtonEventArgs e)
        {
            OpenProductWindow();
        }

        private void OpenProductWindow()
        {
            var productWindow = new ProductWindow();
            productWindow.Owner = this;
            productWindow.ShowDialog();
        }

        private void ProductList_Click(object sender, RoutedEventArgs e)
        {
            OpenProductListWindow();
        }

        private void ProductList_Click(object sender, MouseButtonEventArgs e)
        {
            OpenProductListWindow();
        }

        private void OpenProductListWindow()
        {
            var productListWindow = new ProductListWindow();
            productListWindow.Owner = this;
            productListWindow.ShowDialog();
        }

        private void QuoteList_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sistem listesi yakında eklenecek.", "Bilgi", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
} 