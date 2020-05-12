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
    public partial class WPF_AddInterv : Window
    {
        // Méthode d'instanciation
        private Class.C_Ticket ticket;
        private Class.C_Technical tech;

        // Constructeur de la classe
        public WPF_AddInterv(Class.C_Ticket ticket, Class.C_Technical tech)
        {
            // Initialisation des composants
            InitializeComponent();

            // Remise à zéro du formulaire
            RAZ();

            // Récupération des variables
            this.ticket = ticket;
            this.tech = tech;

            // Chargement du numéro de ticket
            this.TXT_RMANumber.Text = Class.C_Database.SelectIDTicket(ticket).ToString();
        }

        // Méthode de remise à zéro du formulaire
        private void RAZ()
        {
            // Mise à zéro des champs
            this.TXT_HeureBeg.Text = "09";
            this.TXT_HeureFin.Text = "17";
            this.TXT_MinuteBeg.Text = "00";
            this.TXT_MinuteFin.Text = "00";
            this.TXT_Note.Text = null;
            this.TXT_Object.Text = null;
            this.TXT_RMANumber.Text = null;
            this.DTP_DateBeg.SelectedDate = DateTime.Now.Date;
            this.DTP_DateFin.SelectedDate = DateTime.Now.Date;
        }

        // Evènement de Click pour le bouton BTN_RAZ
        private void BTN_RAZ_Click(object sender, RoutedEventArgs e)
        {
            // Remise à zéro du formulaire
            RAZ();
        }

        // Evènement de Click pour le bouton BTN_Cancel
        private void BTN_Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Remise à zéro du formulaire
            RAZ();

            // Fermeture du formulaire
            this.Close();
        }

        // Evènement de Click pour le bouton BTN_Accept
        private void BTN_Accept_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((this.TXT_Object.Text != null && this.TXT_Object.Text != "") &&
                    (this.TXT_HeureBeg.Text != null && this.TXT_HeureBeg.Text != "") && (int.Parse(this.TXT_HeureBeg.Text) > -1 && int.Parse(this.TXT_HeureBeg.Text) < 24) &&
                    (this.TXT_HeureFin.Text != null && this.TXT_HeureFin.Text != "") && (int.Parse(this.TXT_HeureFin.Text) > -1 && int.Parse(this.TXT_HeureFin.Text) < 24) &&
                    (this.TXT_MinuteBeg.Text != null && this.TXT_MinuteBeg.Text != "") && (int.Parse(this.TXT_MinuteBeg.Text) > -1 && int.Parse(this.TXT_MinuteBeg.Text) < 60) &&
                    (this.TXT_MinuteFin.Text != null && this.TXT_MinuteFin.Text != "") && (int.Parse(this.TXT_MinuteFin.Text) > -1 && int.Parse(this.TXT_MinuteFin.Text) < 60) &&
                    (this.TXT_RMANumber.Text != null && this.TXT_RMANumber.Text != ""))
                {
                    // Déclaration des variables locales
                    Class.C_Intervention interv;
                    DateTime tmpDate, dateBeg, dateEnd;

                    // Préparation des dates
                    tmpDate = (DateTime)this.DTP_DateBeg.SelectedDate;
                    dateBeg = new DateTime(tmpDate.Year, tmpDate.Month, tmpDate.Day, int.Parse(this.TXT_HeureBeg.Text), int.Parse(this.TXT_MinuteBeg.Text), 0);
                    tmpDate = (DateTime)this.DTP_DateFin.SelectedDate;
                    dateEnd = new DateTime(tmpDate.Year, tmpDate.Month, tmpDate.Day, int.Parse(this.TXT_HeureFin.Text), int.Parse(this.TXT_MinuteFin.Text), 0);

                    // Vérification que la date de fin est plus grande que la date de début
                    if (dateBeg < dateEnd)
                    {
                        // Création de l'intervention
                        interv = new Class.C_Intervention(dateBeg, dateEnd, this.TXT_Object.Text, this.TXT_Note.Text, tech);

                        // Essai d'insertion dans la liste des intervention
                        if (ticket.AddIntervInList(interv))
                        {
                            // Endcodage dans la DB
                            Class.C_Database.InsertIntervention(interv, ticket);

                            // Remise à zéro du formulaire
                            RAZ();

                            // Fermeture du formulaire
                            this.Close();
                        }
                        else
                            // Affichage du message d'erreur
                            MessageBox.Show("L'intervention que vous souhaitez entrer entre en conflit avec une autre que vous avez effectué.");
                    }
                    else
                        // Affichage du message d'erreur
                        MessageBox.Show("La date et heure de fin doit être plus grande la date et heure de début");
                }
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur
                MessageBox.Show("Le programme a rencontré une ou plusieur(s) erreur(s) : \n\n" + ex.Message);
            }
        }

        // Evènement de LostFocus sur le champs TXT_HeureBeg
        private void TXT_HeureBeg_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                int test;
                test = int.Parse(this.TXT_HeureBeg.Text);
                if (!(test > -1 && test <24))
                {
                    // Remise du champs sur 09
                    this.TXT_HeureBeg.Text = "09";
                }
            }
            catch
            {
                // Remise du champs sur 09
                this.TXT_HeureBeg.Text = "09";
            }
        }

        // Evènement de LostFocus sur le champs TXT_MinuteBeg
        private void TXT_MinuteBeg_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                int test;
                test = int.Parse(this.TXT_MinuteBeg.Text);
                if (!(test > -1 && test < 60))
                {
                    // Remise du champs sur 00
                    this.TXT_MinuteBeg.Text = "00";
                }
            }
            catch
            {
                // Remise du champs sur 00
                this.TXT_MinuteBeg.Text = "00";
            }
        }

        // Evènement de LostFocus sur le champs TXT_HeureFin
        private void TXT_HeureFin_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                int test;
                test = int.Parse(this.TXT_HeureFin.Text);
                if (!(test > -1 && test < 24))
                {
                    // Remise du champs sur 17
                    this.TXT_HeureFin.Text = "17";
                }
            }
            catch
            {
                // Remise du champs sur 17
                this.TXT_HeureFin.Text = "17";
            }
        }

        // Evènement de LostFocus sur le champs TXT_MinuteFin
        private void TXT_MinuteFin_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                int test;
                test = int.Parse(this.TXT_MinuteFin.Text);
                if (!(test > -1 && test < 60))
                {
                    // Remise du champs sur 00
                    this.TXT_MinuteFin.Text = "00";
                }
            }
            catch
            {
                // Remise du champs sur 00
                this.TXT_MinuteFin.Text = "00";
            }
        }
    }
}