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
    /// Interaction logic for WPF_ModifInterv.xaml
    /// </summary>
    public partial class WPF_ModifInterv : Window
    {
        // Membres d'instanciation
        private Class.C_Ticket ticket;
        private Class.C_Intervention interv;
        private Class.C_Technical tech;

        // Constructeur de la classe
        public WPF_ModifInterv(Class.C_Ticket ticket, Class.C_Intervention interv, Class.C_Technical tech)
        {
            // Initialisation des composants
            InitializeComponent();

            // Récupération des informaitons
            this.ticket = ticket;
            this.interv = interv;
            this.tech = tech;

            // Remise à zéro du fomulaire
            RAZ();

            // Mise en place des informations
            this.TXT_HeureBeg.Text = interv.DateBeg.Hour.ToString();
            this.TXT_HeureFin.Text = interv.DateEnd.Hour.ToString();
            this.TXT_MinuteBeg.Text = interv.DateBeg.Minute.ToString();
            this.TXT_MinuteFin.Text = interv.DateEnd.Minute.ToString();
            this.TXT_Note.Text = interv.Note;
            this.TXT_Object.Text = interv.Label;
            this.TXT_RMANumber.Text = Class.C_Database.SelectIDTicket(ticket).ToString();
            this.DTP_DateBeg.SelectedDate = interv.DateBeg.Date;
            this.DTP_DateFin.SelectedDate = interv.DateEnd.Date;
        }

        // Méthode de remise à zéro du formulaire
        public void RAZ()
        {
            // Mise à zéro des champs
            this.TXT_HeureBeg.Text = null;
            this.TXT_HeureFin.Text = null;
            this.TXT_MinuteBeg.Text = null;
            this.TXT_MinuteFin.Text = null;
            this.TXT_Note.Text = null;
            this.TXT_Object.Text = null;
            this.TXT_RMANumber.Text = null;
            this.DTP_DateBeg.SelectedDate = DateTime.Now.Date;
            this.DTP_DateFin.SelectedDate = DateTime.Now.Date;
        }

        // Evènement Click du bouton BTN_Cancel
        private void BTN_Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Remise à zéro du formulaire
            RAZ();

            // Fermeture du formulaire
            this.Close();
        }

        // Evènement Click du bouton BTN_Accept
        private void BTN_Accept_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Déclaration des variables locales
                Class.C_Intervention oldInterv;
                DateTime tmpDate, dateBeg, dateEnd;

                // Récupération de l'ancienne intervention
                oldInterv = new Class.C_Intervention(interv.DateBeg, interv.DateEnd, interv.Label, interv.Note, Class.C_Database.SelectTechnical(interv.TechnicalUsername));

                //  Retire l'intervention de la liste
                ticket.RemoveIntervFromList(oldInterv);

                // Préparation des dates
                tmpDate = (DateTime)this.DTP_DateBeg.SelectedDate;
                dateBeg = new DateTime(tmpDate.Year, tmpDate.Month, tmpDate.Day, int.Parse(this.TXT_HeureBeg.Text), int.Parse(this.TXT_MinuteBeg.Text), 0);
                tmpDate = (DateTime)this.DTP_DateFin.SelectedDate;
                dateEnd = new DateTime(tmpDate.Year, tmpDate.Month, tmpDate.Day, int.Parse(this.TXT_HeureFin.Text), int.Parse(this.TXT_MinuteFin.Text), 0);

                // Vérification que la date de fin est plus grande que la date de début
                if (dateBeg < dateEnd)
                {
                    // Modificatoin de l'ancienne intervention
                    interv.ModifyIntervention(dateBeg, dateEnd, this.TXT_Object.Text, this.TXT_Note.Text);

                    // Essai d'ajout de cette intervention à la liste
                    if (ticket.AddIntervInList(interv))
                    {
                        // Modification en base de données
                        Class.C_Database.UpdateIntervention(interv, ticket);

                        // Remise à zéro du formulaire
                        RAZ();

                        // Fermeture du formulaire
                        this.Close();
                    }
                    else
                    {
                        // Remise de l'ancienne intervention
                        ticket.AddIntervInList(oldInterv);

                        // Affichage du message d'erreur
                        MessageBox.Show("L'intervention que vous souhaitez entrer entre en conflit avec une autre que vous avez effectué.");
                    }
                }
                else
                {
                    // Remise de l'ancienne intervention
                    ticket.AddIntervInList(oldInterv);

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
                if (!(test > -1 && test < 24))
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