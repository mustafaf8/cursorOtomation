using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace SolarAutomation.Views
{
    public partial class CatiView : UserControl
    {
        public ObservableCollection<CatiSistem> Sistemler { get; set; }

        public CatiView()
        {
            InitializeComponent();
            Sistemler = new ObservableCollection<CatiSistem>();
            dgSistemler.ItemsSource = Sistemler;
            UpdateToplamSistem();
        }

        private void Ekle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var sistem = new CatiSistem
                {
                    Panel = txtPanel.Text,
                    Inverter = txtInverter.Text,
                    Kablo = txtKablo.Text,
                    Konnektor = txtKonnektor.Text,
                    Montaj = txtMontaj.Text,
                    Sigorta = txtSigorta.Text
                };

                Sistemler.Add(sistem);
                ClearForm();
                UpdateToplamSistem();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Sil_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is CatiSistem sistem)
            {
                var result = MessageBox.Show("Bu sistemi silmek istediğinizden emin misiniz?", "Silme Onayı",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    Sistemler.Remove(sistem);
                    UpdateToplamSistem();
                }
            }
        }

        private void ClearForm()
        {
            txtPanel.Clear();
            txtInverter.Clear();
            txtKablo.Clear();
            txtKonnektor.Clear();
            txtMontaj.Clear();
            txtSigorta.Clear();
        }

        private void UpdateToplamSistem()
        {
            txtToplamSistem.Text = Sistemler.Count.ToString();
        }
    }

    public class CatiSistem
    {
        public string? Panel { get; set; }
        public string? Inverter { get; set; }
        public string? Kablo { get; set; }
        public string? Konnektor { get; set; }
        public string? Montaj { get; set; }
        public string? Sigorta { get; set; }
    }
} 