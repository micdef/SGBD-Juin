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
    public partial class WPF : Window
    {
        // Membres d'instanciation
        private bool nameOK;
        public Class.C_Client Client { get; set; }

        // Constructeur par défaut
        public WPF()
        {
            // Initialise les composants
            InitializeComponent();

            // Remet à zéro le formulaire
            RAZ();

            // Mise à faux du booléen d'encodage
            nameOK = false;
        }

        // Evènement de click pour le bouton BTN_RAZ
        private void BTN_RAZ_Click(object sender, RoutedEventArgs e)
        {
            // Remet à zéro le formulaire
            RAZ();
        }

        // Méthode de remise à zéro du formulaire
        private void RAZ()
        {
            // Remet à zéro les champs du formulaire
            this.TXT_City.Text = null;
            this.TXT_eMail.Text = null;
            this.TXT_Fax.Text = null;
            this.TXT_Name.Text = null;
            this.TXT_Street.Text = null;
            this.TXT_StreetBox.Text = null;
            this.TXT_StreetNB.Text = null;
            this.TXT_Telephone.Text = null;
            this.TXT_ZipCode.Text = null;
        }

        // Evènement de click pour le bouton BTN_Cancel
        private void BTN_Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Remise à zéro du formulaire
            RAZ();

            // Fermeture du formulaire
            this.Close();
        }

        // Evènement de click pour le bouton BTN_Accept
        private void BTN_Accept_Click(object sender, RoutedEventArgs e)
        {
            // Vérification du booléen d'encodage
            if (this.nameOK)
            {
                try
                {
                    // Création du client
                    Class.C_Client tmpClient = new Class.C_Client(this.TXT_Name.Text, this.TXT_ZipCode.Text, this.TXT_City.Text, this.TXT_Street.Text, this.TXT_StreetNB.Text, this.TXT_Telephone.Text,
                        this.TXT_eMail.Text, this.TXT_StreetBox.Text, this.TXT_Fax.Text);

                    // Encodage du client dans la base de données.
                    Class.C_Database.InsertClient(tmpClient);

                    // Message de réussite
                    MessageBox.Show("Le client à bien été encodé.");

                    // Mise en place de la propriétés
                    this.Client = tmpClient;

                    // Fermeture du formulaire
                    this.Close();
                }
                catch (Exception ex)
                {
                    // Message d'erreur
                    MessageBox.Show("Le programme a rencontré une ou plusieur(s) erreur(s) : \n\n" + ex.Message);

                    // Mise à null de la propriété
                    this.Client = null;
                }
            }
        }

        // Evènement de perte de focus pour le champs TXT_Name
        private void TXT_Name_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                // Vérification que le nom du client ne se trouve pas dans la base de données
                if (!(Class.C_Database.CheckClientExists(this.TXT_Name.Text)))
                {
                    // Mise en place du booléen d'encodage
                    this.nameOK = true;
                }
                else
                {
                    // Message de présence dans la base de données
                    MessageBox.Show("Le nom choisi pour le client existe déjà dans la base de données. Veuillez en choisir un autre svp.");

                    // Mise en place du booléen d'encodage
                    this.nameOK = false;
                }
            }
            catch (Exception ex)
            {
                // Message d'erreur
                MessageBox.Show("Le programme a rencontré une ou plusieur(s) erreur(s) : \n\n" + ex.Message);

                // Mise en place du booléen d'encodage
                this.nameOK = false;
            }
        }

        // Evènement de changement de texte pour le champs TXT_ZipCode
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
                this.TXT_ZipCode.Text = "1000";
            }
        }

        // Evènement de changement de texte pour le champs TXT_StreetNB
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
                this.TXT_StreetNB.Text = "1";
            }
        }
    }
}
