using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace App_front
{
    /// <summary>
    /// Logique d'interaction pour FormulaireAjoutPlat.xaml
    /// </summary>
    public partial class FormulaireAjoutPlat : Window
    {
        public string Nom { get; set; }
        public string Categorie { get; set; }
        public int Prix { get; set; }

        public FormulaireAjoutPlat()
        {
            InitializeComponent();
        }

        public string CategoriePicker
        {
            get { return cmbCategorie.SelectedItem?.ToString(); }
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer les valeurs saisies dans le formulaire
            Nom = txtNom.Text;
            Prix = int.Parse(txtPrix.Text);
            Categorie = CategoriePicker;


            if (string.IsNullOrEmpty(CategoriePicker))
            {
                MessageBox.Show("Veuillez sélectionner une catégorie.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                Categorie = cmbCategorie.Text;
            }

            // Définir le DialogResult sur true pour indiquer que le formulaire a été soumis avec succès
            DialogResult = true;
            Close();
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            // Définir le DialogResult sur false pour indiquer que le formulaire a été annulé
            DialogResult = false;
            Close();
        }
    }
}
