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
using System.Windows.Shapes;

namespace SGBD_Juin.XAML
{
    /// <summary>
    /// Interaction logic for WPF_ModifClient.xaml
    /// </summary>
    public partial class WPF_ModifClient : Window
    {
        // Membre d'instanciation
        private Class.C_Client cli;

        // Constructeur par défaut
        public WPF_ModifClient()
        {
            // Initialisation des composants
            InitializeComponent();

            // Remise à zéro des champs
            RAZ();
        }

        // Méthode de remise à zéro
        public void RAZ()
        {
            // Remet à zéro tout le formulaire
            this.TXT_City.Text = null;
            this.TXT_eMail.Text = null;
            this.TXT_Fax.Text = null;
            this.TXT_Name.Text = null;
            this.TXT_Street.Text = null;
            this.TXT_StreetBox.Text = null;
            this.TXT_StreetNB.Text = null;
            this.TXT_Telephone.Text = null;
            this.TXT_ZipCode.Text = null;

            // Fermeture des champs
            this.TXT_City.IsEnabled = false;
            this.TXT_eMail.IsEnabled = false;
            this.TXT_Fax.IsEnabled = false;
            this.TXT_Street.IsEnabled = false;
            this.TXT_StreetBox.IsEnabled = false;
            this.TXT_StreetNB.IsEnabled = false;
            this.TXT_Telephone.IsEnabled = false;
            this.TXT_ZipCode.IsEnabled = false;

            // Fermeture du bouton d'encodage
            this.BTN_Accept.IsEnabled = false;
        }

        // Evènement de MouseDoubleCLick sur le champs TXT_Name
        private void TXT_Name_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Préparation et affichage de l'écran de recherche de client
            WPF_SearchClient wpf_SC = new WPF_SearchClient();
            wpf_SC.ShowDialog();

            // Vérification que l'on a choisi un client
            if (wpf_SC.Client != null)
            {
                // Remplissage des champs
                this.TXT_City.Text = wpf_SC.Client.City;
                this.TXT_eMail.Text = wpf_SC.Client.Mail;
                this.TXT_Fax.Text = wpf_SC.Client.Fax;
                this.TXT_Name.Text = wpf_SC.Client.Name;
                this.TXT_Street.Text = wpf_SC.Client.Street;
                this.TXT_StreetBox.Text = wpf_SC.Client.StreetBox;
                this.TXT_StreetNB.Text = wpf_SC.Client.StreetNumber;
                this.TXT_Telephone.Text = wpf_SC.Client.Telephone;
                this.TXT_ZipCode.Text = wpf_SC.Client.ZipCode;

                // Ouverture des champs
                this.TXT_City.IsEnabled = true;
                this.TXT_eMail.IsEnabled = true;
                this.TXT_Fax.IsEnabled = true;
                this.TXT_Street.IsEnabled = true;
                this.TXT_StreetBox.IsEnabled = true;
                this.TXT_StreetNB.IsEnabled = true;
                this.TXT_Telephone.IsEnabled = true;
                this.TXT_ZipCode.IsEnabled = true;

                // Récupération du client
                cli = wpf_SC.Client;

                // Fermeture du bouton d'encodage
                this.BTN_Accept.IsEnabled = true;
            }
            else
            {
                // Remet à zéro tout le formulaire
                this.TXT_City.Text = null;
                this.TXT_eMail.Text = null;
                this.TXT_Fax.Text = null;
                this.TXT_Name.Text = null;
                this.TXT_Street.Text = null;
                this.TXT_StreetBox.Text = null;
                this.TXT_StreetNB.Text = null;
                this.TXT_Telephone.Text = null;
                this.TXT_ZipCode.Text = null;

                // Fermeture des champs
                this.TXT_City.IsEnabled = false;
                this.TXT_eMail.IsEnabled = false;
                this.TXT_Fax.IsEnabled = false;
                this.TXT_Street.IsEnabled = false;
                this.TXT_StreetBox.IsEnabled = false;
                this.TXT_StreetNB.IsEnabled = false;
                this.TXT_Telephone.IsEnabled = false;
                this.TXT_ZipCode.IsEnabled = false;

                // Fermeture du bouton d'encodage
                this.BTN_Accept.IsEnabled = false;
            }
        }

        // Evènement de Changement de texte pour le champs TXT_ZipCode
        private void TXT_ZipCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                // Teste que le texte entré est bien un entier
                int.Parse(this.TXT_ZipCode.Text);
            }
            catch
            {
                // Si pas, il est mis a 1000 (BXL)
                this.TXT_ZipCode.Text = cli.ZipCode;
            }
        }

        // Evènement de Changement de texte pour le champs TXT_StreetNB
        private void TXT_StreetNB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                // Teste que le texte entré est bien un entier
                int.Parse(this.TXT_StreetNB.Text);
            }
            catch
            {
                // Si pas, il est mis a 1
                this.TXT_StreetNB.Text = cli.StreetNumber;
            }
        }

        // Evènement de Click du bouton BTN_RAZ
        private void BTN_RAZ_Click(object sender, RoutedEventArgs e)
        {
            // Remise à zéro du formulaire
            RAZ();
        }

        // Evènement de Click du bouton BTN_Accept
        private void BTN_Accept_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Modification du client
                cli.ModifClient(this.TXT_Name.Text,
                                this.TXT_ZipCode.Text,
                                this.TXT_City.Text,
                                this.TXT_Street.Text,
                                this.TXT_StreetNB.Text,
                                this.TXT_Telephone.Text,
                                this.TXT_eMail.Text,
                                this.TXT_StreetBox.Text,
                                this.TXT_Fax.Text);

                // Encodage des modification dans la DB
                Class.C_Database.UpdateClient(cli);

                // Message de réussite
                MessageBox.Show("Les modifications ont bien été enregistrées.");

                // Remise à zéro du formulaire
                RAZ();

                // Fermeture du formulaire
                this.Close();
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur
                MessageBox.Show("Le programme a rencontré une ou plusieur(s) erreur(s) : \n\n" + ex.Message);
            }
        }

        // Evènement de Click du bouton BTN_Cancel
        private void BTN_Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Remise à zéro du formulaire
            RAZ();

            // Fermeture du formulaire
            this.Close();
        }
    }
}
