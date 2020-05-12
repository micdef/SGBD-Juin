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
    /// <summary>
    /// Interaction logic for WPF_SearchRMA.xaml
    /// </summary>
    public partial class WPF_SearchRMA : Window
    {
        // Membres d'instanciation
        private DataTable dt = null;
        private DataTable dtDGV = null;
        private string call;
        private Class.C_Technical tech;
        private Class.C_Administrative adm;

        // Constructeur de la classe
        public WPF_SearchRMA(string call, Class.C_Technical tech = null, Class.C_Administrative adm = null)
        {
            try
            {
                // Initialisation des composants
                InitializeComponent();

                // Mise à zéro des variables
                dt = null;

                // Remise à zéro du formulaire
                RAZ();

                // Récupération du type de formulaire appelant
                this.call = call;
                this.adm = adm;
                this.tech = tech;

                // Préparation de la DataTable
                this.dt = new DataTable();
                this.dt = Class.C_Database.RetrieveOpenedTickets(); // Récupération depuis la DB

                // Préparation de la DataTable
                dtDGV = new DataTable();
                dtDGV.Columns.Add("Numéro");
                dtDGV.Columns.Add("Date d'encodage");
                dtDGV.Columns.Add("Nom du client");
                dtDGV.Columns.Add("Sujet");
                this.DGV_Search.ItemsSource = dtDGV.AsDataView();

                // Premier remplissage de la DGV
                DataRow[] dr = new DataRow[dt.Rows.Count];
                int i = 0;
                foreach (DataRow r in dt.Rows)
                {
                    dr[i] = r;
                    i++;
                }
                FillDGV(dr);
            }
            catch (Exception ex)
            {
                // Message d'erreur
                MessageBox.Show("Le programme a rencontré une ou plusieur(s) erreur(s) : \n\n" + ex.Message);

                // Fermeture du formulaire
                this.Close();
            }
        }

        // Méthode de remise à zéro du formulaire
        private void RAZ()
        {
            // Mise à zéro des champs et membres d'instanciation
            if (this.DGV_Search.Items.Count > 0) this.DGV_Search.Items.Clear();
            if (this.DGV_Search.Columns.Count > 0) this.DGV_Search.Columns.Clear();
            this.TXT_NomClient.Text = null;
            this.TXT_NumRMA.Text = null;
            this.CHK_ClosedRMA.IsChecked = false;
            this.RDB_NomClient.IsChecked = false;
            this.RDB_NumRMA.IsChecked = false;
            this.TXT_NomClient.IsEnabled = false;
            this.TXT_NumRMA.IsEnabled = false;
        }

        // Méthode de remplissage de la DataGrid
        private void FillDGV(DataRow[] dataR)
        {
            // Définition des variables locales
            object[] rowArray = new object[4];
            DataRow dr;

            // Vide la table
            dtDGV.Rows.Clear();

            // Remplis la table
            foreach (DataRow r in dataR)
            {
                // Définis la nouvelle ligne
                dr = dtDGV.NewRow();

                // Remplis les champs
                rowArray[0] = r.ItemArray[0];
                rowArray[1] = r.ItemArray[1];
                rowArray[2] = r.ItemArray[2];
                rowArray[3] = r.ItemArray[3];

                // Ajoute les champs à la nouvelle ligne
                dr.ItemArray = rowArray;

                // Ajoute la nouvelle ligne à la DataTable
                dtDGV.Rows.Add(dr);
            }
        }

        // Evènement de Click pour le bouton BTN_Close
        private void BTN_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Evènement de Changement de texte pour le champs TXT_NumRMA
        private void TXT_NumRMA_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Vide la table
            dtDGV.Rows.Clear();

            // Vérification si le champs de recherche est vide
            if (this.TXT_NumRMA.Text == null || this.TXT_NumRMA.Text == "")
            {
                // Remplissage de la DataGrid avec tous les clients.
                DataRow[] dr = new DataRow[dt.Rows.Count];
                int i = 0;
                foreach (DataRow r in dt.Rows)
                {
                    dr[i] = r;
                    i++;
                }

                // Remplissage de la DataGrid
                FillDGV(dr);
            }
            else
            {
                // Remplissage de la DataGrid avec les clients correspondant au critère de recherche
                FillDGV(dt.Select("Numero like '%" + this.TXT_NumRMA.Text + "%'"));
            }
        }

        // Evènement de Changement de texte pour le champs TXT_NomClient
        private void TXT_NomClient_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Vide la table
            dtDGV.Rows.Clear();

            // Vérification si le champs de recherche est vide
            if (this.TXT_NomClient.Text == null || this.TXT_NomClient.Text == "")
            {
                // Remplissage de la DataGrid avec tous les clients.
                DataRow[] dr = new DataRow[dt.Rows.Count];
                int i = 0;
                foreach (DataRow r in dt.Rows)
                {
                    dr[i] = r;
                    i++;
                }

                // Remplissage de la DataGrid
                FillDGV(dr);
            }
            else
            {
                // Remplissage de la DataGrid avec les clients correspondant au critère de recherche
                FillDGV(dt.Select("Client like '%" + this.TXT_NomClient.Text + "%'"));
            }
        }

        // Evènement de Changement d'état pour le champs CHK_CloseRMA
        private void CHK_ClosedRMA_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                // Vérification si il est checké
                if (this.CHK_ClosedRMA.IsChecked == true)
                {
                    // Préparation de la DataTable
                    this.dt = new DataTable();
                    this.dt = Class.C_Database.RetrieveAllTickets(); // Récupération depuis la DB
                }
                else
                {
                    // Préparation de la DataTable
                    this.dt = new DataTable();
                    this.dt = Class.C_Database.RetrieveOpenedTickets(); // Récupération depuis la DB
                }

                // Vérification si un champs a été remplis
                if ((this.TXT_NomClient.Text != null && this.TXT_NomClient.Text != "") || (this.TXT_NumRMA.Text != null && this.TXT_NumRMA.Text != ""))
                {
                    if (this.TXT_NomClient.Text != null && this.TXT_NomClient.Text != "")
                    {
                        // Remplissage de la DataGrid avec les clients correspondant au critère de recherche
                        FillDGV(dt.Select("Numero like '%" + this.TXT_NumRMA.Text + "%'"));
                    }
                    else
                    {
                        // Remplissage de la DataGrid avec les clients correspondant au critère de recherche
                        FillDGV(dt.Select("Client like '%" + this.TXT_NomClient.Text + "%'"));
                    }
                }
                else
                {
                    // Remplissage de la DGV
                    DataRow[] dr = new DataRow[dt.Rows.Count];
                    int i = 0;
                    foreach (DataRow r in dt.Rows)
                    {
                        dr[i] = r;
                        i++;
                    }
                    FillDGV(dr);
                }
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur
                MessageBox.Show("Le programme a rencontré une ou plusieur(s) erreur(s) : \n\n" + ex.Message);
            }
        }

        // Evènement de MouseDoubleClick pour la DataGrid DGV_Search
        private void DGV_Search_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                // Récupération de la ligne de la DataGrid
                DataRowView dr = (DataRowView)this.DGV_Search.SelectedItem;

                // Création du ticket choisi
                Class.C_Ticket tmpTicket = Class.C_Database.SelectTicket(int.Parse(dr.Row.ItemArray[0].ToString()));

                // Vérification de l'action
                if (this.call == "Reopen")
                {
                    // Réouverture du ticket
                    tmpTicket.ReopenTicket();

                    // Encodage dans la DB de la modificaton
                    Class.C_Database.ReopenTicket(tmpTicket);
                }
                else if (this.call == "Modify")
                {
                    // Déclaration des variables locales
                    WPF_ModifRMA wpf_ModifRMA;

                    // Préparation et affiche du formulaire de mofidication
                    if (tech == null)
                        wpf_ModifRMA = new WPF_ModifRMA(ticket: tmpTicket, adm: this.adm);
                    else
                        wpf_ModifRMA = new WPF_ModifRMA(ticket: tmpTicket, tech: this.tech);
                    wpf_ModifRMA.ShowDialog();
                }

                // Fermeture du formulaire
                this.Close();
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur
                MessageBox.Show("Le programme a rencontré une ou plusieur(s) erreur(s) : \n\n" + ex.Message);
            }
        }

        private void CHK_ClosedRMA_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                // Vérification si il est checké
                if (this.CHK_ClosedRMA.IsChecked == true)
                {
                    // Préparation de la DataTable
                    this.dt = new DataTable();
                    this.dt = Class.C_Database.RetrieveAllTickets(); // Récupération depuis la DB
                }
                else
                {
                    // Préparation de la DataTable
                    this.dt = new DataTable();
                    this.dt = Class.C_Database.RetrieveOpenedTickets(); // Récupération depuis la DB
                }

                // Vérification si un champs a été remplis
                if ((this.TXT_NomClient.Text != null && this.TXT_NomClient.Text != "") || (this.TXT_NumRMA.Text != null && this.TXT_NumRMA.Text != ""))
                {
                    if (this.TXT_NomClient.Text != null && this.TXT_NomClient.Text != "")
                    {
                        // Remplissage de la DataGrid avec les clients correspondant au critère de recherche
                        FillDGV(dt.Select("Numero like '%" + this.TXT_NumRMA.Text + "%'"));
                    }
                    else
                    {
                        // Remplissage de la DataGrid avec les clients correspondant au critère de recherche
                        FillDGV(dt.Select("Client like '%" + this.TXT_NomClient.Text + "%'"));
                    }
                }
                else
                {
                    // Remplissage de la DGV
                    DataRow[] dr = new DataRow[dt.Rows.Count];
                    int i = 0;
                    foreach (DataRow r in dt.Rows)
                    {
                        dr[i] = r;
                        i++;
                    }
                    FillDGV(dr);
                }
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur
                MessageBox.Show("Le programme a rencontré une ou plusieur(s) erreur(s) : \n\n" + ex.Message);
            }
        }

        //Evènement de Changement de check sur le RadioButton RDB_NumRMA
        private void RDB_NumRMA_Checked(object sender, RoutedEventArgs e)
        {
            // Mise à vide des champs de recherche
            this.TXT_NomClient.Text = null;
            this.TXT_NumRMA.Text = null;

            // Vérification que le RDB est checké
            if (this.RDB_NumRMA.IsChecked == true)
            {
                // Fermeture/Ouverture des champs
                this.TXT_NomClient.IsEnabled = false;
                this.TXT_NumRMA.IsEnabled = true;
            }
            else
            {
                // Fermeture/Ouverture des champs
                this.TXT_NomClient.IsEnabled = true;
                this.TXT_NumRMA.IsEnabled = false;
            }

            // Remplissage de la DGV
            DataRow[] dr = new DataRow[dt.Rows.Count];
            int i = 0;
            foreach (DataRow r in dt.Rows)
            {
                dr[i] = r;
                i++;
            }
            FillDGV(dr);
        }

        //Evènement de Changement de check sur le RadioButton RDB_NomClient
        private void RDB_NomClient_Checked(object sender, RoutedEventArgs e)
        {
            // Mise à vide des champs de recherche
            this.TXT_NomClient.Text = null;
            this.TXT_NumRMA.Text = null;

            // Vérification que le RDB est checké
            if (this.RDB_NomClient.IsChecked == true)
            {
                // Fermeture/Ouverture des champs
                this.TXT_NomClient.IsEnabled = true;
                this.TXT_NumRMA.IsEnabled = false;
            }
            else
            {
                // Fermeture/Ouverture des champs
                this.TXT_NomClient.IsEnabled = false;
                this.TXT_NumRMA.IsEnabled = true;
            }

            // Remplissage de la DGV
            DataRow[] dr = new DataRow[dt.Rows.Count];
            int i = 0;
            foreach (DataRow r in dt.Rows)
            {
                dr[i] = r;
                i++;
            }
            FillDGV(dr);
        }
    }
}