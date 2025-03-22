using System;
using System.Windows;
using SolarAutomation.Data;
using SolarAutomation.Models;

namespace SolarAutomation.Views
{
    public partial class CustomerWindow : Window
    {
        private readonly ApplicationDbContext _context;
        private Customer? _customer;

        public CustomerWindow(Customer? customer = null)
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            _customer = customer;

            if (_customer != null)
            {
                // Mevcut müşteri bilgilerini form alanlarına doldur
                LoadCustomerData();
            }
        }

        private void LoadCustomerData()
        {
            if (_customer == null) return;

            txtName.Text = _customer.Name;
            txtPhone.Text = _customer.Phone;
            txtEmail.Text = _customer.Email;
            txtAddress.Text = _customer.Address;
            txtNotes.Text = _customer.Notes;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Lütfen müşteri adını giriniz.", "Hata", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                if (_customer == null)
                {
                    // Yeni müşteri oluştur
                    _customer = new Customer
                    {
                        CreatedDate = DateTime.Now
                    };
                    _context.Customers.Add(_customer);
                }

                // Müşteri bilgilerini güncelle
                _customer.Name = txtName.Text;
                _customer.Phone = txtPhone.Text;
                _customer.Email = txtEmail.Text;
                _customer.Address = txtAddress.Text;
                _customer.Notes = txtNotes.Text;

                _context.SaveChanges();
                MessageBox.Show("Müşteri başarıyla kaydedildi.", "Bilgi", MessageBoxButton.OK, MessageBoxImage.Information);
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