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
using GestionMedicament.VueGael;

namespace GestionMedicament.VueEnzo
{
    /// <summary>
    /// Logique d'interaction pour ModifMedicamentEnzo.xaml
    /// </summary>
    public partial class ModifMedicamentEnzo : Window
    {
        private GstBDD gst;
        private int idMedoc;
        public ModifMedicamentEnzo(GstBDD unGst, int unId)
        {
            Gst = unGst;
            IdMedoc = unId;
            InitializeComponent();
        }

        public GstBDD Gst { get => gst; set => gst = value; }
        public int IdMedoc { get => idMedoc; set => idMedoc = value; }

        private void linkGstIdv_Click(object sender, RoutedEventArgs e)
        {
            GstIndividuYanis gstIndividu = new GstIndividuYanis(Gst);
            gstIndividu.Show();
        }

        private void linkgstMedoc_Click(object sender, RoutedEventArgs e)
        {
            GstMedicamentGael gstMedoc = new GstMedicamentGael(Gst);
            gstMedoc.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Medicament unMedoc = Gst.getMedicamentByIdGael(IdMedoc);
            lstNomCommercial.Text = unMedoc.NomMedicament.ToString();
            cboFamille.ItemsSource = gst.getLstFamilleGael();
            txtFamille.Text = unMedoc.NomFamille;
            cboFamille.SelectedItem = gst.getFamilleByName(unMedoc.NomFamille);
            lstPrixEchantillon.Text = unMedoc.PrixEchantillon.ToString();
            lstComposition.Text = unMedoc.Composition.ToString();
            lstEffetmedicament.Text = unMedoc.Effets.ToString();
            lstContreIndication.Text = unMedoc.ContreIndication.ToString();
        }

        private void btnModifierMedoc_Click(object sender, RoutedEventArgs e)
        {

            if (lstNomCommercial.Text == null)
            {
                MessageBox.Show("Veuillez entrer un nom de médicament", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (cboFamille.SelectedItem == null)
            {
                MessageBox.Show("Veuillez entrer un Nom de famille", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (lstComposition.Text == null)
            {
                MessageBox.Show("Veuillez entrer une composition", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (lstContreIndication.Text == null)
            {
                MessageBox.Show("Veuillez entrer une contre indication", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (lstEffetmedicament.Text == null)
            {
                MessageBox.Show("Veuillez entrer un effet", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (lstPrixEchantillon.Text == null)
            {
                MessageBox.Show("Veuillez entrer prix", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Famille unefam = cboFamille.SelectedItem as Famille;
                gst.UpdateMedicamentEnzo(idMedoc, lstNomCommercial.Text, unefam.IdFamille, lstComposition.Text, lstEffetmedicament.Text, lstContreIndication.Text, Convert.ToDouble(lstPrixEchantillon.Text));
                Close();
            }
        }
    }
}
