using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBD_Juin.Class
{
    public class C_User
    {
        // Membres d'instanciation
        private string username;
        private string password;
        private string firstname;
        private string lastname;
        private string mail;
        private bool flagAdmin;
        private bool flagActive;
        private bool flagDelete;

        // Constructeur par défaut
        public C_User()
        {
            this.username = null;
            this.password = null;
            this.firstname = null;
            this.lastname = null;
            this.mail = null;
            this.flagAdmin = false;
            this.flagActive = false;
            this.flagDelete = false;
        }
        
        // Constructeur par paramètres
        public C_User(string usn, string pwd, string fname, string lname, string mail, bool fadmin, bool factive, bool fdelete)
        {
            this.username = usn;
            this.password = pwd;
            this.firstname = fname;
            this.lastname = lname;
            this.mail = mail;
            this.flagAdmin = fadmin;
            this.flagActive = factive;
            this.flagDelete = fdelete;
        }

        // Propriétés
        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public string FirstName
        {
            get { return this.firstname; }
            set { this.firstname = value; }
        }

        public string LastName
        {
            get { return this.lastname; }
            set { this.lastname = value; }
        }

        public string Mail
        {
            get { return this.mail; }
            set { this.mail = value; }
        }

        public bool FlagAdmin
        {
            get { return this.flagAdmin; }
            set { this.flagAdmin = value; }
        }

        public bool FlagActive
        {
            get { return this.flagActive; }
            set { this.flagActive = value; }
        }

        public bool FlagDelete
        {
            get { return this.flagDelete; }
            set { this.flagDelete = value; }
        }

        // Méthode de modification de l'utilisateur
        public void ModifUser(string usn, string pwd, string fname, string lname, string mail, bool fadmin, bool factive, bool fdelete)
        {
            this.username = usn;
            this.password = pwd;
            this.firstname = fname;
            this.lastname = lname;
            this.mail = mail;
            this.flagAdmin = fadmin;
            this.flagActive = factive;
            this.flagDelete = fdelete;
        }

        // Méthode de suppression de l'utilisateur
        public void DeleteUser()
        {
            this.flagDelete = true;
        }

        // Méthode de réhabilitation de l'utilisateur
        public void UndeleteUser()
        {
            this.flagDelete = false;
        }

        // Méthode d'authentification
        public bool Authentification(string usn, string pwd)
        {
            bool OK = false;
            if (this.username == usn && this.password == pwd)
                OK = true;
            return OK;
        }

        // Méthode de vérification du mot de passe
        public bool CheckPWD(string pwd)
        {
            bool OK = false;
            if (this.password == pwd)
                OK = true;
            return OK;
        }

        //// Méthode de cryptage du mot de passe
        //private string CryptPassword(string pwd)
        //{
        //    StringBuilder passwd = null;
        //    foreach (char c in pwd)
        //    {
        //        int asc = c;
        //        asc = 255 - asc;
        //        char chr = (char)asc;
        //        passwd.Append(chr);
        //    }
        //    return passwd.ToString();
        //}
    }
}
