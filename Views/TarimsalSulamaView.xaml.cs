using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace SolarAutomation.Views
{
    public partial class TarimsalSulamaView : UserControl
    {
        public ObservableCollection<TarimsalSulamaSistem> Sistemler { get; set; }

        public TarimsalSulamaView()
        {
            InitializeComponent();
            Sistemler = new ObservableCollection<TarimsalSulamaSistem>();
            dgSistemler.ItemsSource = Sistemler;
            UpdateToplamSistem();
        }

        private void Ekle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var sistem = new TarimsalSulamaSistem
                {
                    HP = txtHP.Text,
                    Panel = txtPanel.Text,
                    Surucu = txtSurucu.Text,
                    KirmiziKablo = txtKirmiziKablo.Text,
                    SiyahKablo = txtSiyahKablo.Text,
                    Konnektor = txtKonnektor.Text
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
            if (sender is Button button && button.DataContext is TarimsalSulamaSistem sistem)
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
            txtHP.Clear();
            txtPanel.Clear();
            txtSurucu.Clear();
            txtKirmiziKablo.Clear();
            txtSiyahKablo.Clear();
            txtKonnektor.Clear();
        }

        private void UpdateToplamSistem()
        {
            txtToplamSistem.Text = Sistemler.Count.ToString();
        }
    }

    public class TarimsalSulamaSistem
    {
        public string? HP { get; set; }
        public string? Panel { get; set; }
        public string? Surucu { get; set; }
        public string? KirmiziKablo { get; set; }
        public string? SiyahKablo { get; set; }
        public string? Konnektor { get; set; }
    }
} 