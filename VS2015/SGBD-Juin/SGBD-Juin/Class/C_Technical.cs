using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBD_Juin.Class
{
    public class C_Technical : C_User
    {
        // Membres d'instanciation
        private double hourRate;
        private string gsm;

        // Constructeur par défaut
        public C_Technical()
        {
            this.hourRate = float.MinValue;
            this.gsm = null;
        }

        // Constructeur par paramètres
        public C_Technical(string usn, string pwd, string fname, string lname, string mail, bool fadmin, bool factive, bool fdelete, double hourRate, string gsm) :
            base (usn, pwd, fname, lname, mail, fadmin, factive, fdelete)
        {
            this.hourRate = hourRate;
            this.gsm = gsm;
        }

        // Propriétés
        public double HourRate
        {
            get { return this.hourRate; }
            set { this.hourRate = value; }
        }

        public string GSM
        {
            get { return this.gsm; }
            set { this.gsm = value; }
        }
    }
}
