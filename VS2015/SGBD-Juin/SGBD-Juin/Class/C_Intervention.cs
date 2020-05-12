using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBD_Juin.Class
{
    public class C_Intervention
    {

        // Membres d'instanciation
        private DateTime dateBeg;
        private DateTime dateEnd;
        private string label;
        private string note;
        private string usnTech;

        // Constructeur par défaut
        public C_Intervention()
        {
            this.dateBeg = DateTime.MinValue;
            this.dateEnd = DateTime.MinValue;
            this.label = null;
            this.note = null;
            this.usnTech = null;
        }

        // Constructeur par paramètres
        public C_Intervention(DateTime dateBeg, DateTime dateEnd, string label, string note, C_Technical tech)
        {
            this.dateBeg = dateBeg;
            this.dateEnd = dateEnd;
            this.label = label;
            this.note = note;
            this.usnTech = tech.Username;
        }

        // Propriétés
        public DateTime DateBeg
        {
            get { return this.dateBeg; }
            set { this.dateBeg = value; }
        }

        public DateTime DateEnd
        {
            get { return this.dateEnd; }
            set { this.dateEnd = value; }
        }

        public string Label
        {
            get { return this.label; }
            set { this.label = value; }
        }

        public string Note
        {
            get { return this.note; }
            set { this.note = value; }
        }

        public string TechnicalUsername
        {
            get { return this.usnTech; }
        }

        // Méthode de modification de l'intervention
        public void ModifyIntervention(DateTime dateBeg, DateTime dateEnd, string label, string note)
        {
            this.dateBeg = dateBeg;
            this.dateEnd = dateEnd;
            this.label = label;
            this.note = note;
        }
    }
}
