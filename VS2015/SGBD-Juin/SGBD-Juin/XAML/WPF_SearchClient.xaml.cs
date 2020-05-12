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
    public partial class WPF_SearchClient : Window
    {
        // Membres d'instanciation
        private DataTable dt;
        private DataTable dtDGV;

        // Propriété
        public Class.C_Client Client { get; set; }

        // Constructeur par défaut
        public WPF_SearchClient()
        {
            try
            {
                // Initialisation des composants
                InitializeComponent();

                // Mise à zéro des variables
                Client = null;
                dt = null;

                // Mise à zéro du formulaire
                RAZ();

                // Préparation de la DataTable
                this.dt = new DataTable();
                this.dt = Class.C_Database.RetrieveAllClients(); // Récupération depuis la DB

                // Mise en place de la DGV
                this.dtDGV = new DataTable();
                this.dtDGV.Columns.Add("Nom");
                this.dtDGV.Columns.Add("Code Postal");
                this.dtDGV.Columns.Add("Ville");
                this.dtDGV.Columns.Add("Rue");
                this.dtDGV.Columns.Add("Numéro");
                this.dtDGV.Columns.Add("Boîte");
                this.DGV_Client.ItemsSource = dtDGV.AsDataView();

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
            if (this.DGV_Client.Items.Count > 0) this.DGV_Client.Items.Clear();
            if (this.DGV_Client.Columns.Count > 0) this.DGV_Client.Columns.Clear();
            this.TXT_ClientName.Text = null;
        }

        // Méthode de remplissage de la DataGrid
        private void FillDGV(DataRow[] dataR)
        {
            // Définition des variables locales
            object[] rowArray = new object[6];
            DataRow dr;

            // Vide la table
            dtDGV.Rows.Clear();

            // Remplis la table
            foreach(DataRow r in dataR)
            {
                // Définis la nouvelle ligne
                dr = dtDGV.NewRow();

                // Remplis les champs
                rowArray[0] = r.ItemArray[0];
                rowArray[1] = r.ItemArray[1];
                rowArray[2] = r.ItemArray[2];
                rowArray[3] = r.ItemArray[3];
                rowArray[4] = r.ItemArray[4];
                rowArray[5] = r.ItemArray[5];

                // Ajoute les champs à la nouvelle ligne
                dr.ItemArray = rowArray;

                // Ajoute la nouvelle ligne à la DataTable
                dtDGV.Rows.Add(dr);
            }
        }

        // Evènement de changement de texte pour le champs TXT_ClientName
        private void TXT_ClientName_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Vide la table
            dtDGV.Rows.Clear();

            // Vérification si le champs de recherche est vide
            if (TXT_ClientName.Text == null || TXT_ClientName.Text == "")
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
                FillDGV(dt.Select("name like '%" + this.TXT_ClientName.Text + "%'"));
            }
        }

        // Evènement de MouseDoubleClick pour la DataGrid DGV_Client
        private void DGV_Client_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                // Récupération de la ligne de la DataGrid
                DataRowView dr = (DataRowView)this.DGV_Client.SelectedItem;

                // Instanciation du client
                Client = Class.C_Database.SelectClient(dr.Row.ItemArray[0].ToString());

                // Fermeture du formulaire
                this.Close();
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur
                MessageBox.Show("Le programme a rencontré une ou plusieur(s) erreur(s) : \n\n" + ex.Message);
            }
        }

        // Evènement de Click pour le bouton BTN_Close
        private void BTN_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Client = null;
            this.Close();
        }
    }
}
