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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace App_front
{
    /// <summary>
    /// Logique d'interaction pour ListeMenus.xaml
    /// </summary>
    public partial class ListeMenus : Window
    {
        public ListeMenus()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await GetDataFromApi();
        }

        public class Menu
        {
            public string burger { get; set; }
            public string boisson { get; set; }
            public string dessert { get; set; }

        }

        private async Task GetDataFromApi()
        {
            using (HttpClient client = new HttpClient())
            {
                // Faites une requête à votre API pour obtenir toutes les données
                HttpResponseMessage response = await client.GetAsync("https://localhost:7262/api/Menu");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    // Convertissez la réponse JSON en une liste d'objets plats
                    List<Menu> menu = JsonConvert.DeserializeObject<List<Menu>>(data);
                    List<Menu> menuCollected = menu.ToList();

                    // Affecter les listes filtrées aux contrôles correspondants
                    menuList.ItemsSource = menuCollected;
                }
            }
        }
    }
}
