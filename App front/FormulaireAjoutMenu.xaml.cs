using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace App_front
{
    /// <summary>
    /// Logique d'interaction pour FormulaireAjoutMenu.xaml
    /// </summary>
    public partial class FormulaireAjoutMenu : Window
    {
        public string Boisson { get; set; }
        public string Burger { get; set; }
        public string Dessert { get; set; }

        public FormulaireAjoutMenu()
        {
            InitializeComponent();
            ChargerElementsComboBox();
        }
        public class Plats
        {
            public string nomPlat { get; set; }
            public string categorie { get; set; }

        }

        private async void ChargerElementsComboBox()
        {
            // Effectuer une requête vers votre API pour obtenir la liste des éléments
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:7262/api/Plats");

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    List<Plats> plats = JsonConvert.DeserializeObject<List<Plats>>(data);

                    // Filtrer les éléments par catégorie (boissons, burgers, desserts)
                    List<string> boissons = plats.Where(p => p.categorie == "Boisson").Select(p => p.nomPlat).ToList();
                    List<string> burgers = plats.Where(p => p.categorie == "Burger").Select(p => p.nomPlat).ToList();
                    List<string> desserts = plats.Where(p => p.categorie == "Dessert").Select(p => p.nomPlat).ToList();

                    // Remplir les ComboBox avec les éléments correspondants
                    ComboBoxBoisson.ItemsSource = boissons;
                    ComboBoxBurger.ItemsSource = burgers;
                    ComboBoxDessert.ItemsSource = desserts;
                }
            }
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            string boisson = ComboBoxBoisson.SelectedItem?.ToString();
            string burger = ComboBoxBurger.SelectedItem?.ToString();
            string dessert = ComboBoxDessert.SelectedItem?.ToString();

            // Utilisez les valeurs sélectionnées pour construire l'objet de menu

            if (string.IsNullOrEmpty(boisson) || string.IsNullOrEmpty(burger) || string.IsNullOrEmpty(dessert))
            {
                MessageBox.Show("Veuillez sélectionner une valeur pour chaque élément du menu.", "Erreur de formulaire");
                return;
            }

            
            Boisson = boisson;
            Burger = burger;
            Dessert = dessert;

            DialogResult = true;
            // Fermez la fenêtre
            Close();
        }
    }
}
