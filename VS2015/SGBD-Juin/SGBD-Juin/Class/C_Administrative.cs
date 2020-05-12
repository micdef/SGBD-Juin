using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBD_Juin.Class
{
    public class C_Administrative : C_User
    {

        // Membres d'instanciation
        private double salary;
        private string internPhone;
        private C_Ticket ticket;
        private C_Client client;

        // Constructeur par défaut
        public C_Administrative()
        {
            this.salary = float.MinValue;
            this.internPhone = null;
            this.ticket = null;
        }

        // Constructeur par paramètres
        public C_Administrative(string usn, string pwd, string fname, string lname, string mail, bool fadmin, bool factive, bool fdelete, double salary, string internPhone) :
            base(usn, pwd, fname, lname, mail, fadmin, factive, fdelete)
        {
            this.salary = salary;
            this.internPhone = internPhone;
            this.ticket = null;
        }

        // Propriétés
        public double Salary
        {
            get { return this.salary; }
            set { this.salary = value; }
        }

        public string InternPhone
        {
            get { return this.internPhone; }
            set { this.internPhone = value; }
        }

        public C_Ticket Ticket
        {
            get { return this.ticket; }
            set { this.ticket = value; }
        }

        public C_Client Client
        {
            get { return this.client; }
            set { this.client = value; }
        }
    }
}