using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KolkoKrzyrzyk_Proj
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {      
        public MainWindow()
        {
            ObsługaGry.ZarejestrujPlanszę();
            InitializeComponent();
        }

        // nowa gra
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // rozpoczynam nową grę
            ObsługaGry.NowaGra();

            // pokazuję planszę dla użytkownika
            Plansza.Visibility = Visibility.Visible;
        }

        // kliknięcie pola
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ObsługaGry.RuchWykonany(Convert.ToInt32((sender as FrameworkElement).Tag));
        }

        // załadowanie pola
        private void Button_Loaded(object sender, RoutedEventArgs e)
        {
            ObsługaGry.ZarejestrujPole(sender as Button);
        }
    }
}
