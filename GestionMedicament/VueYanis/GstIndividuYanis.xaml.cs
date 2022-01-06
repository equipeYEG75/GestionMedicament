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
using GestionMedicament.VueGael;

namespace GestionMedicament.VueYanis
{
    /// <summary>
    /// Logique d'interaction pour GstIndividuYanis.xaml
    /// </summary>
    public partial class GstIndividuYanis : Window
    {
        private GstBDD gst;

        public GstIndividuYanis(GstBDD unGst)
        {
            Gst = unGst;
            InitializeComponent();
        }

        public GstBDD Gst { get => gst; set => gst = value; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gst = new GstBDD();
            lstTotalTypeIndividu.ItemsSource = gst.GetTypeIndividusYanis();
        }

        private void linkgstMedoc_Click(object sender, RoutedEventArgs e)
        {
            GstMedicamentGael gstMedoc = new GstMedicamentGael(Gst);
            gstMedoc.Show();
        }

        private void linkStatique_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCreerMedoc_Click(object sender, RoutedEventArgs e)
        {
            if (txtTypeIndividu.Text == null)
            {
                MessageBox.Show("Veuillez entrer un type d'individu", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                gst.InsertIndividuYanis(Convert.ToInt16(gst.getLastIdIndividuYanis()), txtTypeIndividu.Text);
                lstTotalTypeIndividu.ItemsSource = gst.GetTypeIndividusYanis();
            }
           
        }
        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            {
                {
                    if (lstTotalTypeIndividu.SelectedItem != null)
                    {
                        if (txtTypeIndividu.Text != "")
                        {

                            int codeTin = (lstTotalTypeIndividu.SelectedItem as TypeIndividu).IdType;

                            string libelle = txtTypeIndividu.Text;
                            gst.UpdateIndividuYanis(codeTin, libelle);
                            lstTotalTypeIndividu.ItemsSource = gst.GetTypeIndividusYanis();
                            MessageBox.Show("Le type d'individu à bien été mis à jour !");
                        }
                        else
                        {
                            MessageBox.Show("Veuillez saisir un type d'individu.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Veuillez choisir un type d'individu.", "Erreur de choix", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void lstTotalTypeIndividu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstTotalTypeIndividu.SelectedItem != null)
            {
                string LibelleTin = (lstTotalTypeIndividu.SelectedItem as TypeIndividu).LibelleType;
                txtTypeIndividu.Text = LibelleTin;
            }
        }
    }
}
