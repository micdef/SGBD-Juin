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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SGBD_Juin.UserControls
{
    public partial class UC_Administrative : UserControl
    {
        // Membres d'instanciation
        private Class.C_Administrative adm;
        private DataTable dt;
        private DataTable dtDGV;
        private DispatcherTimer timer;

        // Constructeur de la classe
        public UC_Administrative(Class.C_Administrative adm)
        {
            try
            {
                // Initialisation des composants
                InitializeComponent();

                // Mise en place des variables d'instanciation
                this.adm = adm;

                // Mise à zéro du formulaire
                RAZ();

                // Préparation de la DataTable
                dtDGV = new DataTable();
                dtDGV.Columns.Add("Numéro");
                dtDGV.Columns.Add("Date d'encodage");
                dtDGV.Columns.Add("Nom du client");
                dtDGV.Columns.Add("Sujet");
                this.DGV_RMAList.ItemsSource = dtDGV.AsDataView(); // Affècte la datatable en mode vue à la datagris

                // Préparation de la DataTable
                this.dt = new DataTable();
                this.dt = Class.C_Database.RetrieveOpenedTickets(); // Récupération depuis la DB

                // Création du timer
                timer = new DispatcherTimer(); // Instanciation du timer
                timer.Tick += new EventHandler(timer_Tick); // Abonnement à la méthode pour le Tick
                timer.Interval = new TimeSpan(0, 1, 0); // Définition du temps d'attente entre les Ticks
                timer.Start(); // Démarre le timer

                // Remplis la DataGrid
                FillDataGrid();
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur
                MessageBox.Show("Le programme a rencontré une ou plusieur(s) erreur(s) : \n\n" + ex.Message);

                // Fermeture de l'applicatif
                App.Current.Shutdown();
            }
        }
        
        // Méthode de remise à zéro du formulaire
        private void RAZ()
        {
            // Remise à zéro des lignes et colonnes de la DataGrid
            if (this.DGV_RMAList.Items.Count > 0) this.DGV_RMAList.Items.Clear();
            if (this.DGV_RMAList.Columns.Count > 0) this.DGV_RMAList.Columns.Clear();
        }

        // Méthode de rémplissage de la DataGrid
        private void FillDataGrid()
        {
            // Définition des variables locales
            object[] rowArray = new object[4];
            DataRow dr;

            // Vide la table
            dtDGV.Rows.Clear();

            // Remplis la table
            foreach (DataRow r in dt.Rows)
            {
                // Création de la nouvelle ligne
                dr = dtDGV.NewRow();

                // Préparation des champs
                rowArray[0] = r.ItemArray[0];
                rowArray[1] = r.ItemArray[1];
                rowArray[2] = r.ItemArray[2];
                rowArray[3] = r.ItemArray[3];

                // Ajout des champs à la nouvelle ligne
                dr.ItemArray = rowArray;

                // Ajout de la nouvelle ligne à la DataTable
                dtDGV.Rows.Add(dr);
            }
        }

        // Evènement de Tick du Timer
        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                // Récupération des tickets
                this.dt = Class.C_Database.RetrieveOpenedTickets();

                // Remplissage de la DataGrid
                FillDataGrid();
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur
                MessageBox.Show("Le programme a rencontré une ou plusieur(s) erreur(s) : \n\n" + ex.Message);
            }
        }

        // Evènement de Click du bouton BTN_Exit
        private void BTN_Exit_Click(object sender, RoutedEventArgs e)
        {
            // Fermeture de l'applicatif
            Application.Current.Shutdown();
        }

        // Evènement de Click du bouton BTN_Restart
        private void BTN_Restart_Click(object sender, RoutedEventArgs e)
        {
            // Redémarrage de l'applicatif
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        // Evènement de Click du bouton BTN_RMAAdd
        private void BTN_RMAAdd_Click(object sender, RoutedEventArgs e)
        {
            // Préparation et affiche de la fenêtre d'ajout de ticket
            XAML.WPF_AddRMA wpf_addRMA = new XAML.WPF_AddRMA(adm);
            wpf_addRMA.ShowDialog();

            // Déclenchement du tick
            timer_Tick(this, new EventArgs());
        }

        // Evènement de Click du bouton BTN_RMARemove
        private void BTN_RMARemove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Vérifie qu'une ligne à au moins été sélectionnée
                if (this.DGV_RMAList.SelectedItems.Count > 0)
                {
                    // Demande à l'utilisateur
                    MessageBoxResult res = MessageBox.Show("Voulez-vous supprimer le ticket sélectionnée", "SGBD-Juin - Suppression de ticket", MessageBoxButton.YesNo);

                    // Vérification de sa réponse
                    if (res == MessageBoxResult.Yes)
                    {
                        // Déclaration des variables locales
                        DataRowView dr;
                        Class.C_Ticket ticket;

                        // Récupération de la ligne de la DataGrid
                        dr = (DataRowView)this.DGV_RMAList.SelectedItem;

                        // Mise en place du ticket
                        ticket = Class.C_Database.SelectTicket(int.Parse(dr.Row.ItemArray[0].ToString()));

                        // Vérification si le ticket contient des interventions
                        if (ticket.InterventionList.Count() > 0)
                        {
                            // Message d'erreur
                            MessageBox.Show("Le ticket que vous avez sélectionné ne peut être supprimé car il contient des interventions.");
                        }
                        else
                        {
                            // Suppression du ticket dans la base de données
                            Class.C_Database.DeleteTicket(ticket);

                            // Message de réussite
                            MessageBox.Show("Le ticket que vous avez sélectionné à bien été supprimé.");

                            // Déclenchement du tick
                            timer_Tick(this, new EventArgs());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur
                MessageBox.Show("Le programme a rencontré une ou plusieur(s) erreur(s) : \n\n" + ex.Message);
            }
        }

        // Evènement de Click du bouton BTN_RAMSearch
        private void BTN_RMASearch_Click(object sender, RoutedEventArgs e)
        {
            // Préparation et affiche de la fenêtre de recherche de ticket
            XAML.WPF_SearchRMA wpf_searchRMA = new XAML.WPF_SearchRMA("Modify", adm: this.adm);
            wpf_searchRMA.ShowDialog();

            // Déclenchement du tick
            timer_Tick(this, new EventArgs());
        }

        // Evènement de Click du bouton BTN_RMAClose
        private void BTN_RMAClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Vérifie qu'une ligne à au moins été sélectionnée
                if (this.DGV_RMAList.SelectedItems.Count > 0)
                {
                    // Demande à l'utilisateur
                    MessageBoxResult res = MessageBox.Show("Voulez-vous clôturer le ticket sélectionnée", "SGBD-Juin - Clôture de ticket", MessageBoxButton.YesNo);

                    // Vérification de sa réponse
                    if (res == MessageBoxResult.Yes)
                    {
                        // Déclaration des variables locales
                        DataRowView dr;
                        Class.C_Ticket ticket;

                        // Récupération de la ligne de la DataGrid
                        dr = (DataRowView)this.DGV_RMAList.SelectedItem;

                        // Mise en place du ticket
                        ticket = Class.C_Database.SelectTicket(int.Parse(dr.Row.ItemArray[0].ToString()));

                        // Clôture du ticket
                        ticket.CloseTicket();

                        // Clôture du ticket dans la base de données
                        Class.C_Database.ConcludeTicket(ticket);

                        // Message de réussite
                        MessageBox.Show("Le ticket que vous avez sélectionné à bien été clôturé.");

                        // Déclenchement du tick
                        timer_Tick(this, new EventArgs());
                    }
                }
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur
                MessageBox.Show("Le programme a rencontré une ou plusieur(s) erreur(s) : \n\n" + ex.Message);
            }
        }

        // Evènement de Click du bouton BTN_RMAOpen
        private void BTN_RMAReopen_Click(object sender, RoutedEventArgs e)
        {
            // Préparation et affiche de la fenêtre de recherche de ticket
            XAML.WPF_SearchRMA wpf_searchRMA = new XAML.WPF_SearchRMA("Reopen");
            wpf_searchRMA.ShowDialog();

            // Déclenchement du tick
            timer_Tick(this, new EventArgs());
        }

        // Evènement de Click du bouton BTN_MySettings
        private void BTN_MySettings_Click(object sender, RoutedEventArgs e)
        {
            // Préparation et affiche de la fenêtre de modification du mot de passe
            XAML.WPF_MySettings wpf_mySettings = new XAML.WPF_MySettings(adm);
            wpf_mySettings.ShowDialog();
        }

        // Evènement de Click du bouton BTN_ClientAdd
        private void BTN_ClientAdd_Click(object sender, RoutedEventArgs e)
        {
            // Préparation et affiche de la fenêtre d'ajout de client
            XAML.WPF wpf_AddClient = new XAML.WPF();
            wpf_AddClient.ShowDialog();

            // Déclenchement du tick
            timer_Tick(this, new EventArgs());
        }

        // Evènement de Click du bouton BTN_ClientMod
        private void BTN_ClientMod_Click(object sender, RoutedEventArgs e)
        {
            // Préparation et affichage de la fenêtre de modification de client
            XAML.WPF_ModifClient wpf_MC = new XAML.WPF_ModifClient();
            wpf_MC.ShowDialog();

            // Déclenchement du tick
            timer_Tick(this, new EventArgs());
        }

        // Evènement de MouseDoubleClick de la DataGrid DGV_RMAList
        private void DGV_RMAList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Déclaration des variables locales
            DataRowView dr;
            Class.C_Ticket ticket;

            // Récupération de la ligne de la DataGrid
            dr = (DataRowView)this.DGV_RMAList.SelectedItem;

            // Mise en place du ticket
            ticket = Class.C_Database.SelectTicket(int.Parse(dr.Row.ItemArray[0].ToString()));

            // Préparation et affichage de la fenêtre de modification de ticket
            XAML.WPF_ModifRMA wpf_MT = new XAML.WPF_ModifRMA(ticket: ticket, adm: adm);
            wpf_MT.ShowDialog();

            // Déclenchement du tick
            timer_Tick(this, new EventArgs());
        }
    }
}