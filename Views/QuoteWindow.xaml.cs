using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SolarAutomation.Views
{
    public partial class QuoteWindow : Window
    {
        private UrunlerView? urunlerView;
        private TarimsalSulamaView? tarimsalSulamaView;
        private CatiView? catiView;

        public QuoteWindow()
        {
            InitializeComponent();
            InitializeViews();
            ShowTarimsalSulama();
        }

        private void InitializeViews()
        {
            urunlerView = new UrunlerView();
            tarimsalSulamaView = new TarimsalSulamaView();
            catiView = new CatiView();
        }

        private void UpdateButtonStyles(Button activeButton)
        {
            btnUrunler.Style = (Style)FindResource("CategoryButtonStyle");
            btnTarimsalSulama.Style = (Style)FindResource("CategoryButtonStyle");
            btnCati.Style = (Style)FindResource("CategoryButtonStyle");

            activeButton.Style = (Style)FindResource("ActiveCategoryButtonStyle");
        }

        private void ShowView(UserControl view)
        {
            contentGrid.Child = view;
        }

        private void Urunler_Click(object sender, RoutedEventArgs e)
        {
            if (urunlerView != null)
            {
                ShowView(urunlerView);
                UpdateButtonStyles(btnUrunler);
            }
        }

        private void TarimsalSulama_Click(object sender, RoutedEventArgs e)
        {
            if (tarimsalSulamaView != null)
            {
                ShowView(tarimsalSulamaView);
                UpdateButtonStyles(btnTarimsalSulama);
            }
        }

        private void Cati_Click(object sender, RoutedEventArgs e)
        {
            if (catiView != null)
            {
                ShowView(catiView);
                UpdateButtonStyles(btnCati);
            }
        }

        private void ShowTarimsalSulama()
        {
            if (tarimsalSulamaView != null)
            {
                ShowView(tarimsalSulamaView);
                UpdateButtonStyles(btnTarimsalSulama);
            }
        }

        private void Kaydet_Click(object sender, RoutedEventArgs e)
        {
            // Kaydetme işlemleri burada yapılacak
            DialogResult = true;
            Close();
        }

        private void Iptal_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
} 