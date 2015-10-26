using System;
using System.Collections;
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
using GestioneVoti;

namespace ArrayVotiWPF
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public GestioneVoti.Voti Voti { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            //uxTipoComboBox.Items.Clear(); 
            //foreach (var tipo in Enum.GetNames(typeof(TipoVoto)))
            //{
            //    uxTipoComboBox.Items.Add(tipo);

            //}
            UxTipoComboBox.ItemsSource = Enum.GetValues(typeof(TipoVoto)).Cast<TipoVoto>();
            UxMediaComboBox.ItemsSource = Enum.GetValues(typeof(Materia)).Cast<Materia>();
            UxMateriaComboBox.ItemsSource = Enum.GetValues(typeof(Materia)).Cast<Materia>();



            Voti = new Voti();
            UxDatiListView.ItemsSource = Voti.DammiIVoti();
            //var items = new Voto[3];
            //            items[0] = new Voto(TipoVoto.Orale, 5, DateTime.Now );
            //            items[1] = new Voto(TipoVoto.Orale, 6, DateTime.Now );
            //            items[2] = new Voto(TipoVoto.Scritto, 7, DateTime.Now );
            //items = this.Voti.DammiIVoti();
            //            UxDatiListView.ItemsSource = items;

        }

        private void VisualizzaVoti(Voti voti)
        {

        }

        private void MenuNuovo_Click(object sender, RoutedEventArgs e)
        {
            UxInserisciVotoButton.IsEnabled = true;
        }

        private void MenuAiuto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UxInserisciVotoButton_Click(object sender, RoutedEventArgs e)
        {
            float voto;
            float.TryParse(UxVotoTextBox.Text, out voto);
            Voti.InserisciVoto((Materia)UxMateriaComboBox.SelectedItem, (TipoVoto)UxTipoComboBox.SelectedItem, voto, DateTime.Now);
            Voto[] voti = this.Voti.DammiIVoti();
            UxDatiListView.ItemsSource = null;
            UxDatiListView.ItemsSource = voti;
        }

        private void MenuNuovoRegistro_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UxVoto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
            }
        }


        private void UxDatiListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UxVotoHeader_Click(object sender, RoutedEventArgs e)
        {
            Voti.Ordina(TipoVoce.Voto);
            UxDatiListView.ItemsSource = null;
            UxDatiListView.ItemsSource = Voti.DammiIVoti();
        }

        private void UxDataHeader_Click(object sender, RoutedEventArgs e)
        {
            Voti.Ordina(TipoVoce.Data);
            UxDatiListView.ItemsSource = null;
            UxDatiListView.ItemsSource = Voti.DammiIVoti();

        }

        private void UxTipoHeader_Click(object sender, RoutedEventArgs e)
        {
            Voti.Ordina(TipoVoce.Data);
            UxDatiListView.ItemsSource = null;
            UxDatiListView.ItemsSource = Voti.DammiIVoti();

        }

        private void UxMateriaHeader_Click(object sender, RoutedEventArgs e)
        {
            Voti.Ordina(TipoVoce.Materia);
            UxDatiListView.ItemsSource = null;
            UxDatiListView.ItemsSource = Voti.DammiIVoti();

        }

        private void BottoneMedia_Click(object sender, RoutedEventArgs e)
        {
            float valore = 0;
            Materia media = (Materia)UxMediaComboBox.SelectedItem;
            valore = this.Voti.Media(media);
            MediaTextBox.Text = Convert.ToString(valore);
        }

        private void UxDatiListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

