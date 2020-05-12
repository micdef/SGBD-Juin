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
    public partial class WPF_Login : Window
    {
        // Membres d'instanciation
        private bool loginState = false;
        private string username = null;
        private string userType = null;

        // Propriétés
        public bool LoginState
        {
            get { return this.loginState; }
        }

        public string Username
        {
            get { return this.username; }
        }

        public string UserType
        {
            get { return this.userType; }
        }

        // Constructeur par défaut
        public WPF_Login()
        {
            // Initialise les composants
            InitializeComponent();

            // Remet à zéro le formulaire
            RAZ();
        }
        
        // Méthode de remise à zéro du formulaire
        private void RAZ()
        {
            // Remet à zéro le formulaire et ferme le bouton de login
            this.TXT_Username.Text = null;
            this.PWD_Password.Password = null;
            this.BTN_Connection.IsEnabled = false;
        }

        // Fonction d'ouverture du bouton de connexion
        private bool OpenConnection()
        {
            // Vérification des champs pour ouvrir le bouton de login
            if ((this.TXT_Username.Text != null && this.TXT_Username.Text != "") && (this.PWD_Password.Password != null && this.PWD_Password.Password != ""))
                return true;
            else
                return false;
        }

        // Evènement de changement de texte du Username
        private void TXT_Username_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Appel à la méthode qui vérifie si on peut ouvrir le bouton connexion
            this.BTN_Connection.IsEnabled = OpenConnection();
        }

        // Evènement de changement de password du password
        private void PWD_Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Appel à la méthode qui vérifie si on peut ouvrir le bouton connexion
            this.BTN_Connection.IsEnabled = OpenConnection();
        }

        // Evènement de click du bouton d'annulation
        private void BTN_Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Mise des variables a null ou faux
            this.loginState = false;
            this.username = null;
            this.userType = null;
            this.Close();
        }

        // Evènement de click du bouton de connexion
        private void BTN_Connection_Click(object sender, RoutedEventArgs e)
        {
            // Déclaration des variables locales
            Class.C_User tmpUser = null;
            Class.C_Technical tmpTech = null;

            try
            {
                // Instanciation d'un utilisateur temporaire
                tmpUser = Class.C_Database.SelectUser(this.TXT_Username.Text);

                // Vérification que l'utilisateur à bien été instancié
                if (tmpUser.Username != null && tmpUser.Username != "")
                {
                    // Vérification si l'authentification se passe bien
                    if (tmpUser.Authentification(this.TXT_Username.Text, this.PWD_Password.Password))
                    {
                        // Mise en place du nom d'utilisateur et du passage du login
                        this.loginState = true;
                        this.username = tmpUser.Username;

                        // Instanciation d'un technicien temporaire
                        tmpTech = Class.C_Database.SelectTechnical(username);

                        // Vérification que le technicien à bien été instancié
                        if (tmpTech.Username != null)

                            // Mise en place du type d'utilisateur sur 'Technical'
                            this.userType = "Technical";
                        else

                            // Mise en place du type d'utilisateur sur 'Administrative'
                            this.userType = "Administrative";

                        // Remise à zéro des champs et fermeture de la fenêtre
                        RAZ();
                        this.Close();
                    }
                    else
                    {
                        // Message de mauvais USN ou PWD
                        MessageBox.Show("Le nom d'utilisateur et/ou le mot de passe n'est pas valide. Veuillez réessayer svp.");

                        // Mise des variables a null ou faux
                        this.loginState = false;
                        this.username = null;
                        this.userType = null;
                    }
                }
                else
                {
                    // Message de mauvais USN ou PWD
                    MessageBox.Show("Le nom d'utilisateur et/ou le mot de passe n'est pas valide. Veuillez réessayer svp.");
                }
            }
            catch (Exception ex)
            {
                // Affichage du message d'erreur en cas d'exception
                MessageBox.Show("Le programme a rencontré une ou plusieur(s) erreur(s) : \n\n" + ex.Message);
            }
        }
    }
}
