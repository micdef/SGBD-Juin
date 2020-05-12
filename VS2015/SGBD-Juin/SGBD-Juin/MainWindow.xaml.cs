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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SGBD_Juin
{
    public partial class MainWindow : Window
    {
        // Membres d'instanciation
        Class.C_Administrative administrative = null;
        Class.C_Technical technical = null;

        // Constructeur par défaut
        public MainWindow()
        {
            // Initialise les composants
            InitializeComponent();

            // Préparation de la fenêtre de Login
            XAML.WPF_Login wpf_login = new XAML.WPF_Login();
            wpf_login.ShowDialog();

            // Vérification si le login s'est bien passé
            if (wpf_login.LoginState)
            {
                // Vérification du type d'utilisateur
                if (wpf_login.UserType == "Technical")
                {
                    // Instancie un technicien
                    technical = Class.C_Database.SelectTechnical(wpf_login.Username);

                    // Instancie le UserControl du technicien et l'affiche
                    UserControls.UC_Technical uc_tech = new UserControls.UC_Technical(technical);
                    GRD_uc.Children.Clear();
                    GRD_uc.Children.Add(uc_tech);
                }
                else
                {
                    // Instancie un administratif
                    administrative = Class.C_Database.SelectAdministrative(wpf_login.Username);

                    // Instancie le UserControl de l'administratif et l'affiche
                    UserControls.UC_Administrative uc_adm = new UserControls.UC_Administrative(administrative);
                    GRD_uc.Children.Clear();
                    GRD_uc.Children.Add(uc_adm);
                }
            }
            else
            {
                // Ferme l'application
                Application.Current.Shutdown();
            }
        }
    }
}