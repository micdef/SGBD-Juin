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
    public partial class WPF_MySettings : Window
    {
        // Membres d'instanciation
        Class.C_User user;

        // Constructeur de la classe
        public WPF_MySettings(Class.C_User user)
        {
            // Initialisation des composants
            InitializeComponent();

            // Récupération de l'utilisateur
            this.user = user;

            // Remise à zéro du formulaire
            RAZ();
        }

        // Méthode de remise à zéro du formulaire
        private void RAZ()
        {
            // Remet à zéro le formulaire
            this.PWD_OldPWD.Password = null;
            this.PWD_NewPWD.Password = null;
            this.PWD_NewPWD1.Password = null;
            this.IMG_OldPWD.Source = null;
            this.IMG_NewPWD.Source = null;
            this.IMG_NewPWD1.Source = null;
        }

        // Evènement de changement de mot passe pour le champs PWD_OldPWD
        private void PWD_OldPWD_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Déclaration des variables locales
            string ImagePath;
            Uri uri;
            BitmapImage bmp;

            // Vérification que le password entré est bien le courant de l'utilisateur
            if (user.CheckPWD(this.PWD_OldPWD.Password))
            {
                // Préparation de l'image
                ImagePath = "pack://application:,,/SGBD-Juin;component/Image/SYS_OK.png";
                uri = new Uri(ImagePath, UriKind.RelativeOrAbsolute);
                bmp = new BitmapImage(uri);

                // Mise en place de l'image
                this.IMG_OldPWD.Source = bmp;
            }
            else
            {
                // Préparation de l'image
                ImagePath = "pack://application:,,/SGBD-Juin;component/Image/SYS_NOK.png";
                uri = new Uri(ImagePath, UriKind.RelativeOrAbsolute);
                bmp = new BitmapImage(uri);
                
                // Mise en place de l'image
                this.IMG_OldPWD.Source = bmp;
            }
        }

        // Evènement de changement de mot passe pour le champs PWD_NewPWD
        private void PWD_NewPWD_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Déclaration des variables locales
            string ImagePath;
            Uri uri;
            BitmapImage bmp;

            // Vérification que les nouveaux mots de passes sont les mêmes
            if (this.PWD_NewPWD.Password == this.PWD_NewPWD1.Password)
            {
                // Préparation de l'image
                ImagePath = "pack://application:,,/SGBD-Juin;component/Image/SYS_OK.png";
                uri = new Uri(ImagePath, UriKind.RelativeOrAbsolute);
                bmp = new BitmapImage(uri);

                // Mise en place de l'image
                this.IMG_OldPWD.Source = bmp;
                this.IMG_NewPWD1.Source = bmp;
            }
            else
            {
                // Préparation de l'image
                ImagePath = "pack://application:,,/SGBD-Juin;component/Image/SYS_NOK.png";
                uri = new Uri(ImagePath, UriKind.RelativeOrAbsolute);
                bmp = new BitmapImage(uri);

                // Mise en place de l'image
                this.IMG_OldPWD.Source = bmp;
                this.IMG_NewPWD1.Source = bmp;
            }
        }

        // Evènement de changement de mot passe pour le champs PWD_NewPWD1
        private void PWD_NewPWD1_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Déclaration des variables locales
            string ImagePath;
            Uri uri;
            BitmapImage bmp;

            // Vérification que les nouveaux mots de passes sont les mêmes
            if (this.PWD_NewPWD.Password == this.PWD_NewPWD1.Password)
            {
                // Préparation de l'image
                ImagePath = "pack://application:,,/SGBD-Juin;component/Image/SYS_OK.png";
                uri = new Uri(ImagePath, UriKind.RelativeOrAbsolute);
                bmp = new BitmapImage(uri);

                // Mise en place de l'image
                this.IMG_OldPWD.Source = bmp;
                this.IMG_NewPWD1.Source = bmp;
            }
            else
            {
                // Préparation de l'image
                ImagePath = "pack://application:,,/SGBD-Juin;component/Image/SYS_NOK.png";
                uri = new Uri(ImagePath, UriKind.RelativeOrAbsolute);
                bmp = new BitmapImage(uri);

                // Mise en place de l'image
                this.IMG_OldPWD.Source = bmp;
                this.IMG_NewPWD1.Source = bmp;
            }
        }

        // Evènement de click pour le bouton BTN_Cancel
        private void BTN_Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Mise à zéro du formulaire
            RAZ();

            // Fermeture du formulaire
            this.Close();
        }

        // Evènement de click pour le bouton BTN_Accept
        private void BTN_Accept_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Changement du mot de passe dans l'utilisateur
                user.Password = this.PWD_NewPWD.Password;

                // Encodage du changement dans la DB
                Class.C_Database.ChangeUserPassword(user);

                // Message de réussite
                MessageBox.Show("Votre mot de passe à bien été change.");

                // Remise à zéro du formulaire
                RAZ();

                // Fermeture du formulaire
                this.Close();
            }
            catch (Exception ex)
            {
                // Message d'erreur
                MessageBox.Show("Le programme a rencontré une ou plusieur(s) erreur(s) : \n\n" + ex.Message);
            }
        }
    }
}
