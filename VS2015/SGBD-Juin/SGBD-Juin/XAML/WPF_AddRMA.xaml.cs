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
    public partial class WPF_AddRMA : Window
    {
        // Membres d'instanciation
        private Class.C_Administrative adm;

        // Constructeur de la classe
        public WPF_AddRMA(Class.C_Administrative adm)
        {
            // Initialisation des composants
            InitializeComponent();

            // Remise à zéto du formulaire
            RAZ();

            // Récupération de l'administratif encodeur
            this.adm = adm;
        }

        // Méthode de remise à zéro du formulaire
        private void RAZ()
        {
            // Mise à zéro du formulaire + ouverture du bouton d'ajout de client.
            this.TXT_ClientCity.Text = null;
            this.TXT_ClientFax.Text = null;
            this.TXT_ClientMail.Text = null;
            this.TXT_ClientName.Text = null;
            this.TXT_ClientStreet.Text = null;
            this.TXT_ClientStreetBox.Text = null;
            this.TXT_ClientStreetNB.Text = null;
            this.TXT_ClientTel.Text = null;
            this.TXT_ClientZipCode.Text = null;
            this.TXT_RMANote.Text = null;
            this.TXT_RMAObjec.Text = null;
            this.BTN_AddClient.IsEnabled = true;
        }

        // Evènement de click du bouton BTN_RAZ
        private void BTN_RAZ_Click(object sender, RoutedEventArgs e)
        {
            // Mise à zéro du formulaire
            RAZ();
        }

        // Evènement de MouseDoubleClick pour le champs TXT_ClientName
        private void TXT_ClientName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Préparation et affichage du formulaire de recherhces
            WPF_SearchClient wpf_SC = new WPF_SearchClient();
            wpf_SC.ShowDialog();

            // Récupération du client retrouvé
            Class.C_Client cli = wpf_SC.Client;

            // Vérification si un client à été retrouve
            if (cli != null)
            {
                // Remplissage par rapport au client trouvé et fermeture du bouton d'ajout.
                this.TXT_ClientCity.Text = cli.City;
                this.TXT_ClientFax.Text = cli.Fax;
                this.TXT_ClientMail.Text = cli.Mail;
                this.TXT_ClientName.Text = cli.Name;
                this.TXT_ClientStreet.Text = cli.Street;
                this.TXT_ClientStreetBox.Text = cli.StreetBox;
                this.TXT_ClientStreetNB.Text = cli.StreetNumber;
                this.TXT_ClientTel.Text = cli.Telephone;
                this.TXT_ClientZipCode.Text = cli.ZipCode;
                this.BTN_AddClient.IsEnabled = false;

                // Mise à null de la var utilisée
                cli = null;
            }
            else
            {
                // Mise à vide des champs et ouverture du bouton d'ajout.
                this.TXT_ClientCity.Text = null;
                this.TXT_ClientFax.Text = null;
                this.TXT_ClientMail.Text = null;
                this.TXT_ClientName.Text = null;
                this.TXT_ClientStreet.Text = null;
                this.TXT_ClientStreetBox.Text = null;
                this.TXT_ClientStreetNB.Text = null;
                this.TXT_ClientTel.Text = null;
                this.TXT_ClientZipCode.Text = null;
                this.BTN_AddClient.IsEnabled = true;
            }

            // Préparation des variables pour le GC
            wpf_SC = null;
        }

        // Evènement de click du bouton BTN_AddClient
        private void BTN_AddClient_Click(object sender, RoutedEventArgs e)
        {
            // Préparation et affichage du formulaire d'ajout
            WPF wpf_AddCli = new WPF();
            wpf_AddCli.ShowDialog();

            // Vérification que le client n'est pas null
            if (!(wpf_AddCli.Client == null))
            {
                // Remplissage des informations concernant le client et fermeture du bouton d'ajout
                this.TXT_ClientCity.Text = wpf_AddCli.Client.City;
                this.TXT_ClientFax.Text = wpf_AddCli.Client.Fax;
                this.TXT_ClientMail.Text = wpf_AddCli.Client.Mail;
                this.TXT_ClientName.Text = wpf_AddCli.Client.Name;
                this.TXT_ClientStreet.Text = wpf_AddCli.Client.Street;
                this.TXT_ClientStreetBox.Text = wpf_AddCli.Client.StreetBox;
                this.TXT_ClientStreetNB.Text = wpf_AddCli.Client.StreetNumber;
                this.TXT_ClientTel.Text = wpf_AddCli.Client.Telephone;
                this.TXT_ClientZipCode.Text = wpf_AddCli.Client.ZipCode;
                this.BTN_AddClient.IsEnabled = false;
            }
            else
            {
                // Mise à vide des champs et ouverture du bouton d'ajout.
                this.TXT_ClientCity.Text = null;
                this.TXT_ClientFax.Text = null;
                this.TXT_ClientMail.Text = null;
                this.TXT_ClientName.Text = null;
                this.TXT_ClientStreet.Text = null;
                this.TXT_ClientStreetBox.Text = null;
                this.TXT_ClientStreetNB.Text = null;
                this.TXT_ClientTel.Text = null;
                this.TXT_ClientZipCode.Text = null;
                this.BTN_AddClient.IsEnabled = true;
            }
        }

        // Evènement de click du bouton BTN_Cancel
        private void BTN_Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Remise à zéro du formulaire
            RAZ();

            // Fermeture du formulaire
            this.Close();
        }

        // Evènement de click du bouton BTN_Accept
        private void BTN_Accept_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Vérification si les champs sont bien remplis
                if ((this.TXT_ClientName.Text != null && this.TXT_ClientName.Text != "") && (this.TXT_RMAObjec.Text != null && this.TXT_RMAObjec.Text != ""))
                {
                    // Création du client
                    Class.C_Client cli = new Class.C_Client(this.TXT_ClientName.Text,
                                                            this.TXT_ClientZipCode.Text,
                                                            this.TXT_ClientCity.Text,
                                                            this.TXT_ClientStreet.Text,
                                                            this.TXT_ClientStreetNB.Text,
                                                            this.TXT_ClientTel.Text,
                                                            this.TXT_ClientMail.Text,
                                                            this.TXT_ClientStreetBox.Text,
                                                            this.TXT_ClientFax.Text);

                    // Création du ticket
                    Class.C_Ticket ticket = new Class.C_Ticket(DateTime.Now,
                                                               this.TXT_RMAObjec.Text,
                                                               this.TXT_RMANote.Text,
                                                               cli);

                    // Encodage dans la base de données
                    Class.C_Database.InsertTicket(ticket, adm);

                    // Message de réussite à l'utilisateur
                    MessageBox.Show("Le ticket suivant à bien été encodé : \n\n" +
                                    "Client     : " + cli.Name + "\n" + 
                                    "Sujet      : " + ticket.Subject + "\n" + 
                                    "Note       : " + ticket.Note + "\n" + 
                                    "En date du : " + ticket.DateIN);
                    // Remise à zéro du formulaire
                    RAZ();

                    // Fermeture du formulaire
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                // Message d'erreur
                MessageBox.Show("Le programme a rencontré une ou plusieur(s) erreur(s) : \n\n" + ex.Message);
            }
        }
    }
}
