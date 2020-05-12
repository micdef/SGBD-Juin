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
    public partial class UC_Technical : UserControl
    {
        // Membres d'instanciation
        private Class.C_Technical tech;
        private DataTable dt;
        private DataTable dtDGV;
        private DispatcherTimer timer;

        // Constructeur de la classe
        public UC_Technical(Class.C_Technical tech)
        {
            try
            {
                // Initialisation des composants
                InitializeComponent();

                // Mise en place des variables d'instanciation
                this.tech = tech;

                // Mise à zéro du formulaire
                RAZ();

                // Préparation de la DataTable
                dtDGV = new DataTable();
                dtDGV.Columns.Add("Numéro");
                dtDGV.Columns.Add("Date d'encodage");
                dtDGV.Columns.Add("Nom du client");
                dtDGV.Columns.Add("Sujet");
                this.DGV_RMAList.ItemsSource = dtDGV.AsDataView();

                // Préparation de la DataTable
                this.dt = new DataTable();
                this.dt = Class.C_Database.RetrieveOpenedTickets(); // Récupération depuis la DB

                // Création du timer
                timer = new DispatcherTimer(); // Instanciation du timer
                timer.Tick += new EventHandler(timer_Tick); // Abonnement à la méthode pour le Tick
                timer.Interval = new TimeSpan(0, 1, 0); // Définition du temps d'attente entre les Ticks
                timer.Start();

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

        // Méthode de remplissage de la DataGrid
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
                dr = dtDGV.NewRow();
                rowArray[0] = r.ItemArray[0];
                rowArray[1] = r.ItemArray[1];
                rowArray[2] = r.ItemArray[2];
                rowArray[3] = r.ItemArray[3];
                dr.ItemArray = rowArray;
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

        // Evènement de Click du bouton BTN_MySettings
        private void BTN_MySettings_Click(object sender, RoutedEventArgs e)
        {
            XAML.WPF_MySettings wpf_mySettings = new XAML.WPF_MySettings(tech);
            wpf_mySettings.ShowDialog();
        }

        // Evènement de Click du bouton BTN_RMASearch
        private void BTN_RMASearch_Click(object sender, RoutedEventArgs e)
        {
            // Préparation et affiche de la fenêtre de recherche de ticket
            XAML.WPF_SearchRMA wpf_searchRMA = new XAML.WPF_SearchRMA("Modify", tech: this.tech);
            wpf_searchRMA.ShowDialog();

            // Déclenchement du tick
            timer_Tick(this, new EventArgs());
        }

        // Evènement de MouseDoubleClic de la DataGrid DGV_RMAList
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
            XAML.WPF_ModifRMA wpf_MT = new XAML.WPF_ModifRMA(ticket: ticket, tech: tech);
            wpf_MT.ShowDialog();

            // Déclenchement du tick
            timer_Tick(this, new EventArgs());
        }
    }
}
