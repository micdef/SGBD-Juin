using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class WPF_ModifRMA : Window
    {
        // Membres d'instanciation
        private Class.C_Ticket ticket;
        private Class.C_Administrative adm;
        private Class.C_Technical tech;
        private DataTable dtDGV;

        // Constructeur de la classe
        public WPF_ModifRMA(Class.C_Ticket ticket, Class.C_Administrative adm = null, Class.C_Technical tech = null)
        {
            // Initialisation des composants
            InitializeComponent();

            // Récupération des paramètres
            this.ticket = ticket;
            this.adm = adm;
            this.tech = tech;

            // Remise à zéro du formulaire
            RAZ();

            // Mise en place des informations
            this.TXT_ClientCity.Text = ticket.Client.City;
            this.TXT_ClientFax.Text = ticket.Client.Fax;
            this.TXT_ClientMail.Text = ticket.Client.Mail;
            this.TXT_ClientName.Text = ticket.Client.Name;
            this.TXT_ClientStreet.Text = ticket.Client.Street;
            this.TXT_ClientStreetBox.Text = ticket.Client.StreetBox;
            this.TXT_ClientStreetNB.Text = ticket.Client.StreetNumber;
            this.TXT_ClientTel.Text = ticket.Client.Telephone;
            this.TXT_ClientZipCode.Text = ticket.Client.ZipCode;
            this.TXT_RMANote.Text = ticket.Note;
            this.TXT_RMAObjec.Text = ticket.Subject;

            // Préparation de la DataTable
            dtDGV = new DataTable();
            dtDGV.Clear();
            dtDGV.Columns.Add("ID");
            dtDGV.Columns.Add("Technicien");
            dtDGV.Columns.Add("Début");
            dtDGV.Columns.Add("Fin");
            dtDGV.Columns.Add("Sujet");
            this.DGV_InterventionList.ItemsSource = dtDGV.AsDataView();

            // Remplissage de la datagrid
            FillDataGrid();

            // Vérification du type d'utilisateur
            if (adm != null)
            {
                this.BTN_AddInterv.IsEnabled = false;
                this.BTN_RemoveInterv.IsEnabled = false;
                this.TXT_RMANote.IsEnabled = true;
                this.TXT_RMAObjec.IsEnabled = true;
                this.BTN_Accept.IsEnabled = true;
            }
            else
            {
                this.BTN_AddInterv.IsEnabled = true;
                this.BTN_RemoveInterv.IsEnabled = true;
                this.TXT_RMANote.IsEnabled = false;
                this.TXT_RMAObjec.IsEnabled = false;
                this.BTN_Accept.IsEnabled = false;
            }
        }

        // Méthode de remplissage de la DGV
        private void FillDataGrid()
        {
            // Déclaration des variables locales
            DataRow dr;
            object[] rowArray = new object[5];

            // Mise en place des informations dans la DataGrid
            foreach (Class.C_Intervention i in ticket.InterventionList)
            {
                // Définis la nouvelle ligne
                dr = dtDGV.NewRow();

                // Remplis les champs
                rowArray[0] = Class.C_Database.SelectIDIntervention(i, ticket).ToString();
                rowArray[1] = i.TechnicalUsername.ToString();
                rowArray[2] = i.DateBeg.ToString();
                rowArray[3] = i.DateEnd.ToString();
                rowArray[4] = i.Label.ToString();

                // Ajoute les champs à la nouvelle ligne
                dr.ItemArray = rowArray;

                // Ajoute la nouvelle ligne à la DataTable
                dtDGV.Rows.Add(dr);
            }
        }

        // Méthode de remise à zéro du formulaire
        private void RAZ()
        {
            // Mise à zéro des champs
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
        }

        // Evènement de Click du bouton BTN_Accept
        private void BTN_Accept_Click(object sender, RoutedEventArgs e)
        {
            // Modification du ticket
            this.ticket.ModifTicket(this.ticket.DateIN,
                                    this.TXT_RMAObjec.Text,
                                    this.TXT_RMANote.Text,
                                    this.ticket.Client);

            // Encodage dans la DB
            Class.C_Database.UpdateTicket(ticket, adm);

            // Remise à zéro du formulaire
            RAZ();

            // Fermeture du formulaire
            this.Close();
        }

        // Evènement de Click du bouton BTN_Cancel
        private void BTN_Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Fermeture du formulaire
            this.Close();
        }

        // Evènement de Click du bouton BTN_AddInterv
        private void BTN_AddInterv_Click(object sender, RoutedEventArgs e)
        {
            // Déclaration des variables locales
            WPF_AddInterv wpf_AI;
            object[] rowArray = new object[4];

            // Préparation et affichage du formulaire d'ajout d'intervention
            wpf_AI = new WPF_AddInterv(ticket, tech);
            wpf_AI.ShowDialog();

            // Vide la table
            dtDGV.Rows.Clear();

            // Mise en place des informations dans la DataGrid
            FillDataGrid();
        }

        // Evènement de Click du bouton BTN_RemoveInterv
        private void BTN_RemoveInterv_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tech != null)
                {
                    // Déclaration des variables locales
                    DataRowView dr;

                    // Récupération de la ligne de la DataGrid
                    dr = (DataRowView)this.DGV_InterventionList.SelectedItem;

                    // Vérification que c'est le bon technicien qui demande la suppression
                    if (dr.Row.ItemArray[1].ToString() == tech.Username)
                    {
                        // Demande à l'utilisateur
                        MessageBoxResult res = MessageBox.Show("Voulez-vous supprimer l'intervention sélectionnée", "SGBD-Juin - Suppression d'intervention", MessageBoxButton.YesNo);

                        // Vérificatoin de sa réponse
                        if (res == MessageBoxResult.Yes)
                        {
                            // Recherche dans la liste des intervention
                            foreach (Class.C_Intervention i in ticket.InterventionList)
                            {
                                // Vérification si l'intervention correspond
                                if (i.TechnicalUsername == dr.Row.ItemArray[1].ToString() && i.DateBeg.ToString() == dr.Row.ItemArray[2].ToString() && i.DateEnd.ToString() == dr.Row.ItemArray[3].ToString())
                                {
                                    // Retire l'intervention de la liste
                                    ticket.RemoveIntervFromList(i);

                                    // Retire l'intervention de la base de données
                                    Class.C_Database.DeleteIntervention(i, ticket);

                                    // Casse la boucle foreach
                                    break;
                                }
                            }

                            // Vide la table
                            dtDGV.Rows.Clear();

                            // Mise en place des informations dans la DataGrid
                            FillDataGrid();
                        }
                    }
                    else
                    {
                        // Affichage du message d'erreur
                        MessageBox.Show("Vous ne pouvez pas supprimer l'intervention d'un autre technicien");
                    }
                }
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur
                MessageBox.Show("Le programme a rencontré une ou plusieur(s) erreur(s) : \n\n" + ex.Message);
            }
        }

        // Evènement de MouseDoubleClick pour la DataGrid DGV_InterventionList
        private void DGV_InterventionList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (tech != null)
                {
                    // Déclaration des variables locales
                    Class.C_Intervention interv = null;
                    DataRowView dr;

                    // Récupération de la ligne de la DataGrid
                    dr = (DataRowView)this.DGV_InterventionList.SelectedItem;

                    // Vérification que c'est le bon technicien qui demande la modification
                    if (dr.Row.ItemArray[1].ToString() == tech.Username)
                    {
                        // Recherche dans la liste des intervention
                        foreach (Class.C_Intervention i in ticket.InterventionList)
                        {
                            // Vérification si l'intervention correspond
                            if (i.TechnicalUsername == dr.Row.ItemArray[1].ToString() && i.DateBeg.ToString() == dr.Row.ItemArray[2].ToString() && i.DateEnd.ToString() == dr.Row.ItemArray[3].ToString())
                            {
                                // Récupère l'intervention
                                interv = i;

                                // Casse la boucle foreach
                                break;
                            }
                        }

                        // Préparation et affichage de la fenêtre
                        WPF_ModifInterv wpf_MI = new WPF_ModifInterv(ticket, interv, tech);
                        wpf_MI.ShowDialog();

                        // Vide la table
                        dtDGV.Rows.Clear();

                        // Mise en place des informations dans la DataGrid
                        FillDataGrid();
                    }
                    else
                    {
                        // Affichage du message d'erreur
                        MessageBox.Show("Vous ne pouvez pas modifier l'intervention d'un autre technicien");
                    }
                }
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur
                MessageBox.Show("Le programme a rencontré une ou plusieur(s) erreur(s) : \n\n" + ex.Message);
            }
        }
    }
}