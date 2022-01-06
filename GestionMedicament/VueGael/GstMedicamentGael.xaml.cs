using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GstBdd;
using ClassMetier;
using GestionMedicament.VueYanis;
using GestionMedicament.VueEnzo;

namespace GestionMedicament.VueGael
{
    /// <summary>
    /// Logique d'interaction pour GstMedicamentGael.xaml
    /// </summary>
    public partial class GstMedicamentGael : Window
    {
        private GstBDD gst;
        public GstMedicamentGael(GstBDD ungst)
        {
            Gst = ungst;
            InitializeComponent();
        }
        public GstBDD Gst { get => gst; set => gst = value; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Gst = new GstBDD();
            lstTotalMedoc.ItemsSource = Gst.getLstMedicamentGael();
            cboFamille.ItemsSource = Gst.getLstFamilleGael();
        }

        private void linkGstIdv_Click(object sender, RoutedEventArgs e)
        {
            GstIndividuYanis gstIndividu = new GstIndividuYanis(Gst);
            gstIndividu.Show();
        }

        private void btnLinkDescription_Click(object sender, RoutedEventArgs e)
        {
            if (lstTotalMedoc.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélecctionner un medicament", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                int idMedoc = (lstTotalMedoc.SelectedItem as Medicament).IdMedicament;
                ModifMedicamentEnzo modifMedoc = new ModifMedicamentEnzo(Gst, idMedoc);
                modifMedoc.Show();
            }
        }
        
        private void btnLinkPrescription_Click(object sender, RoutedEventArgs e)
        {
            if (lstTotalMedoc.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélecctionner un medicament", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                int idMed = (lstTotalMedoc.SelectedItem as Medicament).IdMedicament;
                CreerPrescriptionGael creerPrescription = new CreerPrescriptionGael(Gst, idMed);
                creerPrescription.Show();
            }
        }
        private void btnCreerMedoc_Click(object sender, RoutedEventArgs e)
        {
            if (txtNom.Text == null)
            {
                MessageBox.Show("Veuillez entrer un nom ", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (cboFamille.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner une famille ", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (txtComposition.Text == null)
            {
                MessageBox.Show("Veuillez entrer une composition ", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (txtContreIndic.Text == null)
            {
                MessageBox.Show("Veuillez entrer une contre Indication ", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (txtEffet.Text == null)
            {
                MessageBox.Show("Veuillez entrer un effet ", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (txtPrix.Text == null)
            {
                MessageBox.Show("Veuillez entrer un prix ", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                string nom = txtNom.Text;
                int idFam = (cboFamille.SelectedItem as Famille).IdFamille;
                string composition = txtComposition.Text;
                string effet = txtEffet.Text;
                string contreIndic = txtContreIndic.Text;
                string unPrix = txtPrix.Text;
                double prix = Convert.ToDouble(unPrix);

                Gst.addMedicamentGael(nom, idFam, composition, effet, contreIndic, prix);
                lstTotalMedoc.ItemsSource = Gst.getLstMedicamentGael();
            }

        }

        private void btnLinkPerturbateur_Click(object sender, RoutedEventArgs e)
        {
            Perturbateur vuePerturbateur = new Perturbateur(Gst);
            vuePerturbateur.Show();
        }
    }
}
