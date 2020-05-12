using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBD_Juin.Class
{
    public class C_Client
    {
        // Membres d'instanciation
        private string name;
        private string zipCode;
        private string city;
        private string street;
        private string streetNB;
        private string streetBOX;
        private string tel;
        private string fax;
        private string mail;

        // Constructeur par défaut
        public C_Client()
        {
            this.name = null;
            this.zipCode = null;
            this.city = null;
            this.street = null;
            this.streetNB = null;
            this.streetBOX = null;
            this.tel = null;
            this.fax = null;
            this.mail = null;
        }

        // Constructeur par paramètres
        public C_Client(string name, string zipCode, string city, string street, string streetNB, string tel, string mail, string streetBOX = null, string fax = null)
        {
            this.name = name;
            this.zipCode = zipCode;
            this.city = city;
            this.street = street;
            this.streetNB = streetNB;
            this.streetBOX = streetBOX;
            this.tel = tel;
            this.fax = fax;
            this.mail = mail;
        }

        // Propriétés
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string ZipCode
        {
            get { return this.zipCode; }
            set { this.zipCode = value; }
        }

        public string City
        {
            get { return this.city; }
            set { this.city = value; }
        }

        public string Street
        {
            get { return this.street; }
            set { this.street = value; }
        }

        public string StreetNumber
        {
            get { return this.streetNB; }
            set { this.streetNB = value; }
        }

        public string StreetBox
        {
            get { return this.streetBOX; }
            set { this.streetBOX = value; }
        }

        public string Telephone
        {
            get { return this.tel; }
            set { this.tel = value; }
        }

        public string Fax
        {
            get { return this.fax; }
            set { this.fax = value; }
        }

        public string Mail
        {
            get { return this.mail; }
            set { this.mail = value; }
        }

        // Méthode de modification d'un client
        public void ModifClient(string name, string zipCode, string city, string street, string streetNB, string tel, string mail, string streetBOX = null, string fax = null)
        {
            this.name = name;
            this.zipCode = zipCode;
            this.city = city;
            this.street = street;
            this.streetNB = streetNB;
            this.tel = tel;
            this.mail = mail;
            this.streetBOX = streetBOX;
            this.fax = fax;
        }
    }
}
