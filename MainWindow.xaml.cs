using System.Windows;
using System.Windows.Input;
using SolarAutomation.Views;
using SolarAutomation.Data;

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
            using var context = new ApplicationDbContext();
            context.Database.EnsureCreated();
        }

        private void NewCustomer_Click(object sender, RoutedEventArgs e)
        {
            OpenCustomerWindow();
        }

        private void NewCustomer_Click(object sender, MouseButtonEventArgs e)
        {
            OpenCustomerWindow();
        }

        private void OpenCustomerWindow()
        {
            var customerWindow = new CustomerWindow();
            customerWindow.Owner = this;
            customerWindow.ShowDialog();
        }

        private void CustomerList_Click(object sender, RoutedEventArgs e)
        {
            var customerListWindow = new CustomerListWindow();
            customerListWindow.Owner = this;
            customerListWindow.ShowDialog();
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

        private void NewQuote_Click(object sender, RoutedEventArgs e)
        {
            OpenQuoteWindow();
        }

        private void NewQuote_Click(object sender, MouseButtonEventArgs e)
        {
            OpenQuoteWindow();
        }

        private void OpenQuoteWindow()
        {
            var quoteWindow = new QuoteWindow();
            quoteWindow.Owner = this;
            quoteWindow.ShowDialog();
        }

        private void QuoteList_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sistem listesi yakında eklenecek.", "Bilgi", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
} 