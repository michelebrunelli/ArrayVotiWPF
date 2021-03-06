﻿using System;
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
using System.IO;
using System.Threading;

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
            UxTipoComboBox.ItemsSource = Enum.GetValues(typeof(TipoVoto)).Cast<TipoVoto>();
            UxMediaComboBox.ItemsSource = Enum.GetValues(typeof(Materia)).Cast<Materia>();
            UxMateriaComboBox.ItemsSource = Enum.GetValues(typeof(Materia)).Cast<Materia>();
            Voti = new Voti();
            UxDatiListView.ItemsSource = null;
            UxDatiListView.ItemsSource = ReadCSV();
        }

        public IEnumerable<Voto> ReadCSV()
        {
            if (File.Exists("dati.csv"))
            {
                string[] lines = File.ReadAllLines("dati.csv");
                return lines.Select(line => 
                {
                    string[] data = line.Split(';');
                    return new Voto((Materia)Enum.Parse(typeof(Materia), data[0]), (TipoVoto)Enum.Parse(typeof(TipoVoto), data[1]), Convert.ToInt32(data[2]), Convert.ToDateTime(data[3]));
                });
            }
            else
                File.Create("dati.csv");
            return null;
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
            File.AppendAllText("dati.csv", Convert.ToString((Materia)UxMateriaComboBox.SelectedItem) + ";" + Convert.ToString((TipoVoto)UxTipoComboBox.SelectedItem) + ";" + Convert.ToString(voto) + ";" + Convert.ToString(DateTime.Now) + "\n");
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

        private void UxMediaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

