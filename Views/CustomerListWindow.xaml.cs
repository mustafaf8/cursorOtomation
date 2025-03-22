using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using SolarAutomation.Data;
using SolarAutomation.Models;

namespace SolarAutomation.Views
{
    public partial class CustomerListWindow : Window
    {
        private readonly ApplicationDbContext _context;

        public CustomerListWindow()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            LoadCustomers();
        }

        private void LoadCustomers(string? searchText = null)
        {
            var query = _context.Customers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                searchText = searchText.ToLower();
                query = query.Where(c => 
                    c.Name.ToLower().Contains(searchText) || 
                    c.Phone.ToLower().Contains(searchText));
            }

            dgCustomers.ItemsSource = query
                .OrderByDescending(c => c.CreatedDate)
                .ToList();
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadCustomers(txtSearch.Text);
        }

        private void BtnNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            var customerWindow = new CustomerWindow();
            if (customerWindow.ShowDialog() == true)
            {
                LoadCustomers();
            }
        }

        private void DgCustomers_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            EditSelectedCustomer();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            EditSelectedCustomer();
        }

        private void EditSelectedCustomer()
        {
            var selectedCustomer = dgCustomers.SelectedItem as Customer;
            if (selectedCustomer == null) return;

            var customerWindow = new CustomerWindow(selectedCustomer);
            if (customerWindow.ShowDialog() == true)
            {
                LoadCustomers();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var customer = (sender as Button)?.DataContext as Customer;
            if (customer == null) return;

            var result = MessageBox.Show(
                $"'{customer.Name}' müşterisini silmek istediğinizden emin misiniz?",
                "Müşteri Silme",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    _context.Customers.Remove(customer);
                    _context.SaveChanges();
                    LoadCustomers();
                }
                catch
                {
                    MessageBox.Show(
                        "Müşteri silinirken bir hata oluştu.",
                        "Hata",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
        }
    }
} 