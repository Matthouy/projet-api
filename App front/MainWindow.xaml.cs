using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using static App_front.ListeMenus;

namespace App_front
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    /// 

    public class Menu
    {
        public string burger { get; set; }
        public string boisson { get; set; }
        public string dessert { get; set; }

    }

    public class Plats
    {
        public string Id { get; set; }
        public string nomPlat { get; set; }
        public int prix { get; set; }
        public string categorie { get; set; }

    }


    public partial class MainWindow : Window
    {
        Plats selectedPlat;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AjouterMenu_Click()
        {
            // Logique pour ajouter un menu
            FormulaireAjoutMenu formulaire = new FormulaireAjoutMenu();
            formulaire.ShowDialog();

            // Vérifier si le formulaire a été soumis avec succès
            if (formulaire.DialogResult == true)
            {
                // Récupérer les valeurs saisies dans le formulaire
                string boisson = formulaire.Boisson;
                string burger = formulaire.Burger;
                string dessert = formulaire.Dessert;

                // Appeler la méthode POST pour ajouter le plat à la base de données
                AjouterMenu(boisson, burger, dessert);
            }
        }

        private void AjouterPlat_Click()
        {
            // Créer et afficher un formulaire de saisie pour le nouveau plat
            FormulaireAjoutPlat formulaire = new FormulaireAjoutPlat();
            formulaire.ShowDialog();

            // Vérifier si le formulaire a été soumis avec succès
            if (formulaire.DialogResult == true)
            {
                // Récupérer les valeurs saisies dans le formulaire
                string nom = formulaire.Nom;
                string categorie = formulaire.Categorie;
                int prix = formulaire.Prix;

                // Appeler la méthode POST pour ajouter le plat à la base de données
                AjouterPlat(nom, categorie, prix);
            }
        }

        private void VoirMenus_Click()
        {
            // Logique pour voir les menus
            ListeMenus listeMenus = new ListeMenus();
            listeMenus.ShowDialog();
        }

        private void ListBoxburger_SelectionChanged(object sender)
        {
            ListBox listBox = (ListBox)sender;
            Plats selectedItem1 = (Plats)listBox.SelectedItem;

            selectedPlat = selectedItem1;
        }
        private void ListBoxboisson_SelectionChanged(object sender)
        {
            ListBox listBox = (ListBox)sender;
            Plats selectedItem2 = (Plats)listBox.SelectedItem;

            selectedPlat = selectedItem2;
        }



        private async void MainWindow_Loaded()
        {
            await GetDataFromApi();
        }

        private async Task GetDataFromApi()
        {

            using (HttpClient client = new HttpClient())
            {
                // Faites une requête à votre API pour obtenir toutes les données
                HttpResponseMessage response = await client.GetAsync("https://localhost:7262/api/Plats");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    // Convertissez la réponse JSON en une liste d'objets plats
                    List<Plats> plats = JsonConvert.DeserializeObject<List<Plats>>(data);

                    // Filtrer les plats par catégorie
                    List<Plats> burgers = plats.Where(p => p.categorie == "Burger").ToList();
                    List<Plats> boissons = plats.Where(p => p.categorie == "Boisson").ToList();
                    List<Plats> desserts = plats.Where(p => p.categorie == "Dessert").ToList();

                    // Affecter les listes filtrées aux contrôles correspondants
                    burgersList.ItemsSource = burgers;
                    boissonsList.ItemsSource = boissons;
                    dessertsList.ItemsSource = desserts;
                }
            }
        }

        private async void AjouterPlat(string nom, string categorie, int varPrix)
        {
            using (HttpClient client = new HttpClient())
            {
                Plats plat = new Plats { nomPlat = nom, categorie = categorie, prix = varPrix };

                HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:7262/api/Plats", plat);
                if (response.IsSuccessStatusCode)
                {
                    await GetDataFromApi();
                }
                else
                {
                    Debug.WriteLine("Erreur ajout plat");
                }
            }
        }
        private async void AjouterMenu(string boisson, string burger, string dessert)
        {
            using (HttpClient client = new HttpClient())
            {
                Menu menu = new Menu { burger = burger, boisson = boisson, dessert = dessert };
                Debug.WriteLine(burger);
                Debug.WriteLine(boisson);
                Debug.WriteLine(dessert);

                HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:7262/api/Menu", menu);
                if (response.IsSuccessStatusCode)
                {
                    await GetDataFromApi();
                }
                else
                {
                    Debug.WriteLine("Erreur ajout menu");
                }
            }
        }

        private async void put_Click()
        {
            // Logique pour put
            Plats putItem = new Plats
            {
                nomPlat = "Nouveau nom du plat",
                prix = 100,
                categorie = "Boisson"
            };

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PutAsJsonAsync("https://localhost:7262/api/Plats/" + selectedPlat.Id, putItem);
                if (response.IsSuccessStatusCode)
                {
                    await GetDataFromApi();
                }
                else
                {
                    Debug.WriteLine("Erreur put");
                }
            }
        }

        private async void delete_Click()
        {
            // Logique pour delete un plat
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync("https://localhost:7262/api/Plats/" + selectedPlat.Id);
                if (response.IsSuccessStatusCode)
                {
                    await GetDataFromApi();
                }
                else
                {
                    Debug.WriteLine("Erreur delete");
                }
            }
        }

    }
}
