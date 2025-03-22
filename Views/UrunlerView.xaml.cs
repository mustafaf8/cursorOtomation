using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace SolarAutomation.Views
{
    public partial class UrunlerView : UserControl
    {
        public ObservableCollection<Urun> Urunler { get; set; }

        public UrunlerView()
        {
            InitializeComponent();
            Urunler = new ObservableCollection<Urun>();
            dgUrunler.ItemsSource = Urunler;
            UpdateToplamUrun();
        }

        private void Ekle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var urun = new Urun
                {
                    UrunAdi = txtUrunAdi.Text,
                    Marka = txtMarka.Text,
                    Model = txtModel.Text,
                    Fiyat = txtFiyat.Text,
                    Stok = txtStok.Text,
                    Birim = txtBirim.Text
                };

                Urunler.Add(urun);
                ClearForm();
                UpdateToplamUrun();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Sil_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Urun urun)
            {
                var result = MessageBox.Show("Bu ürünü silmek istediğinizden emin misiniz?", "Silme Onayı",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    Urunler.Remove(urun);
                    UpdateToplamUrun();
                }
            }
        }

        private void ClearForm()
        {
            txtUrunAdi.Clear();
            txtMarka.Clear();
            txtModel.Clear();
            txtFiyat.Clear();
            txtStok.Clear();
            txtBirim.Clear();
        }

        private void UpdateToplamUrun()
        {
            txtToplamUrun.Text = Urunler.Count.ToString();
        }
    }

    public class Urun
    {
        public string UrunAdi { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Fiyat { get; set; }
        public string Stok { get; set; }
        public string Birim { get; set; }
    }
} 