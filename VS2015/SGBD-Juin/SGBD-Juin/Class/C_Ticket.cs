using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBD_Juin.Class
{
    public class C_Ticket
    {
        // Membres d'instanciation
        private DateTime dateIN;
        private string subject;
        private string note;
        private bool flagFinished;
        private List<C_Intervention> listInterv;
        private C_Client cli;
        
        // Constructeur par défaut
        public C_Ticket()
        {
            this.dateIN = DateTime.MinValue;
            this.subject = null;
            this.note = null;
            this.flagFinished = false;
            this.listInterv = null;
            this.cli = null;
        }

        // Constructeur par paramètres
        public C_Ticket(DateTime dateIN, string subject, string note, C_Client client)
        {
            this.dateIN = dateIN;
            this.subject = subject;
            this.note = note;
            this.flagFinished = false;
            this.listInterv = new List<C_Intervention>();
            this.cli = client;
        }

        // Propriétés
        public DateTime DateIN
        {
            get { return this.dateIN; }
            set { this.dateIN = value; }
        }

        public string Note
        {
            get { return this.note; }
            set { this.note = value; }
        }

        public bool FlagFinished
        {
            get { return this.flagFinished; }
        }

        public List<C_Intervention> InterventionList
        {
            get { return this.listInterv; }
        }

        public C_Client Client
        {
            get { return this.cli; }
            set { this.cli = value; }
        }

        public string Subject
        {
            get { return this.subject; }
            set { this.subject = value; }
        }

        // Méthode de modification du ticket
        public void ModifTicket(DateTime dateIN, string subject, string note, C_Client client)
        {
            this.dateIN = dateIN;
            this.subject = subject;
            this.note = note;
            this.cli = client;
        }

        // Méthode de réouverture du ticket
        public void ReopenTicket()
        {
            this.flagFinished = false;
        }

        // Méthode de fermeture du ticket
        public void CloseTicket()
        {
            this.flagFinished = true;
        }

        // Méthode d'ajout d'une intervention dans la liste
        public bool AddIntervInList(C_Intervention interv)
        {
            bool OK = true;

            // Vérifie que l'intervention ne chevauche pas une autre ou n'est pas un double encodage parmis toutes les interventions.
            foreach (C_Intervention i in this.listInterv)
            {
                if (i.TechnicalUsername == interv.TechnicalUsername)
                {
                    if (i.DateBeg == interv.DateBeg && i.DateEnd == interv.DateEnd)
                        OK = false;
                    else
                    {
                        if (i.DateEnd > interv.DateBeg || interv.DateBeg < i.DateEnd)
                            OK = false;
                    }   
                }
            }

            // Si l'intervention passe la recherche de dessus et ne pose aucun problème, on l'encode dans la liste
            if (OK)
            {
                listInterv.Add(interv);
            }

            return OK;
        }

        // Méthode de suppression d'une intervention dans la liste
        public void RemoveIntervFromList(C_Intervention interv)
        {
            foreach (C_Intervention i in this.listInterv)
            {
                if (i.DateBeg == interv.DateBeg && i.DateEnd == interv.DateEnd && i.Label == interv.Label && i.Note == interv.Note && i.TechnicalUsername == interv.TechnicalUsername)
                {
                    this.listInterv.Remove(i);
                    break;
                }
            }
        }
    }
}