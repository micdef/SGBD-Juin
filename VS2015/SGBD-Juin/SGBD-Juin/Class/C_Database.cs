using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBD_Juin.Class
{
    public static class C_Database
    {
        // Membre statiques
        private static SGBD_JuinDataContext db = new SGBD_JuinDataContext();

        // Select ID

        // Méthode de récupération de l'ID d'un administratif
        private static int SelectIDAdministrative(C_Administrative adm)
        {
            Administrative adm1;
            try
            {
                adm1 = db.Administratives.Single(a => a.User.Usn == adm.Username);
                return adm1.ID;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Méthode de récupération de l'ID d'un client
        private static int SelectIDClient(C_Client cli)
        {
            Customer cli1;
            try
            {
                cli1 = db.Customers.Single(c => c.Name == cli.Name);
                return cli1.ID;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Méthode de récupération de l'ID d'une intervention
        public static int SelectIDIntervention(C_Intervention interv, C_Ticket ticket)
        {
            Intervention interv1;
            try
            {
                interv1 = db.Interventions.Single(i => i.Technical.User.Usn == interv.TechnicalUsername &&
                                                       i.Ticket.Customer.Name == ticket.Client.Name &&
                                                       i.DateBegin == interv.DateBeg &&
                                                       i.DateEnd == interv.DateEnd);
                return interv1.ID;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Méthode de récupération de l'ID d'un technicien
        private static int SelectIDTechnical(C_Technical tech = null, string usn = null)
        {
            Technical tech1 = null;
            try
            {
                if (tech != null)
                    tech1 = db.Technicals.Single(t => t.User.Usn == tech.Username);
                else if (usn != null)
                    tech1 = db.Technicals.Single(t => t.User.Usn == usn);
                else
                    new Exception("Pas de variables passées");
                return tech1.ID;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Méthode de récupération de l'ID d'un ticket
        public static int SelectIDTicket(C_Ticket ticket)
        {
            Ticket ticket1;
            try
            {
                ticket1 = db.Tickets.Single(t => t.Customer.Name == ticket.Client.Name && t.DateIN == ticket.DateIN);
                return ticket1.ID;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Méthode de récupération de l'ID d'un utilisateur
        private static int SelectIDUser(C_User user)
        {
            User user1;
            try
            {
                user1 = db.Users.Single(u => u.Usn == user.Username);
                return user1.ID;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Insert INTO

        // Méthode d'insertion d'un administratif
        public static void InsertAdministrative(C_Administrative adm)
        {
            int idUser;
            try
            {
                idUser = SelectIDUser(adm);
                db.PS_Insert_Administrative(idUser, 
                                            adm.Salary, 
                                            adm.InternPhone);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Méthode d'insertion d'un client
        public static void InsertClient(C_Client cli)
        {
            try
            {
                db.PS_Insert_Customer(cli.Name,
                                      cli.ZipCode,
                                      cli.City,
                                      cli.Street,
                                      cli.StreetNumber,
                                      (cli.StreetBox != null) ? cli.StreetBox : DBNull.Value.ToString(),
                                      cli.Telephone,
                                      (cli.Fax != null) ? cli.Fax : DBNull.Value.ToString(),
                                      cli.Mail);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Méthode d'insertion d'une intervention
        public static void InsertIntervention(C_Intervention interv, C_Ticket ticket)
        {
            int idTech, idTicket;
            try
            {
                idTech = SelectIDTechnical(usn: interv.TechnicalUsername);
                idTicket = SelectIDTicket(ticket);
                db.PS_Insert_Intervention(idTicket,
                                          idTech,
                                          interv.DateBeg,
                                          interv.DateEnd,
                                          interv.Label,
                                          (interv.Note != null) ? interv.Note : DBNull.Value.ToString());
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Méthode d'insertion d'un technicien
        public static void InsertTechnical(C_Technical tech)
        {
            int idUser;
            try
            {
                idUser = SelectIDUser(tech);
                db.PS_Insert_Technical(idUser,
                                       tech.HourRate,
                                       tech.GSM);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Méthode d'insertion d'un ticket
        public static void InsertTicket(C_Ticket ticket, C_Administrative adm)
        {
            int idCustomer, idAdmin;
            try
            {
                idCustomer = SelectIDClient(ticket.Client);
                idAdmin = SelectIDAdministrative(adm);
                db.PS_Insert_Ticket(idCustomer,
                                    idAdmin,
                                    ticket.Subject,
                                    ticket.DateIN,
                                    (ticket.Note != null) ? ticket.Note : DBNull.Value.ToString());
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Méthode d'insertion d'un utilisateur
        public static void InsertUser(C_User user)
        {
            try
            {
                db.PS_Insert_User(user.Username,
                                  user.Password,
                                  user.FirstName,
                                  user.LastName,
                                  user.Mail,
                                  user.FlagAdmin);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Update

        // Méthode de mise à jour d'un administratif
        public static void UpdateAdministrative(C_Administrative admin)
        {
            int idUser;
            try
            {
                idUser = SelectIDUser(admin);
                db.PS_Update_Administrative(idUser,
                                            admin.Salary,
                                            admin.InternPhone);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Méthode de mise à jour d'un client
        public static void UpdateClient(C_Client cli)
        {
            try
            {
                db.PS_Update_Customer(cli.Name,
                                      cli.ZipCode,
                                      cli.City,
                                      cli.Street,
                                      cli.StreetNumber,
                                      (cli.StreetBox != null) ? cli.StreetBox : DBNull.Value.ToString(),
                                      cli.Telephone,
                                      (cli.Fax != null) ? cli.Fax : DBNull.Value.ToString(),
                                      cli.Mail);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Méthode de mise à jour d'une intervention
        public static void UpdateIntervention(C_Intervention interv, C_Ticket ticket)
        {
            int idInterv, idTicket, idTech;
            try
            {
                idInterv = SelectIDIntervention(interv, ticket);
                idTicket = SelectIDTicket(ticket);
                idTech = SelectIDTechnical(usn: interv.TechnicalUsername);
                db.PS_Update_Intervention(idInterv,
                                          idTicket,
                                          idTech,
                                          interv.DateBeg,
                                          interv.DateEnd,
                                          interv.Label,
                                          (interv.Note != null) ? interv.Note : DBNull.Value.ToString());
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Méthode de mise à jour d'un technicien
        public static void UpdateTechnical(C_Technical tech)
        {
            int idUser;
            try
            {
                idUser = SelectIDUser(tech);
                db.PS_Update_Technical(idUser,
                                       tech.HourRate,
                                       tech.GSM);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Méthode de mise à jour d'un ticket
        public static void UpdateTicket(C_Ticket ticket, C_Administrative admin)
        {
            int idTicket, idClient, idAdmin;
            try
            {
                idTicket = SelectIDTicket(ticket);
                idClient = SelectIDClient(ticket.Client);
                idAdmin = SelectIDAdministrative(admin);
                db.PS_Update_Ticket(idTicket,
                                    idClient,
                                    idAdmin,
                                    ticket.Subject,
                                    ticket.DateIN,
                                    (ticket.Note != null) ? ticket.Note : DBNull.Value.ToString(),
                                    ticket.FlagFinished);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Méthode de mise à jour d'un utilisateur
        public static void UpdateUser(C_User user)
        {
            int idUser;
            try
            {
                idUser = SelectIDUser(user);
                db.PS_Update_User(idUser,
                                  user.Username,
                                  user.Password,
                                  user.FirstName,
                                  user.LastName,
                                  user.Mail,
                                  user.FlagAdmin,
                                  user.FlagActive,
                                  user.FlagDelete);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Delete / Undelete

        // Méthode de suppression d'une intervention
        public static void DeleteIntervention(C_Intervention interv, C_Ticket ticket)
        {
            int idInterv;
            try
            {
                idInterv = SelectIDIntervention(interv, ticket);
                db.PS_Delete_Intervention(idInterv);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Méthode de suppression d'un ticket
        public static void DeleteTicket(C_Ticket ticket)
        {
            int idTicket;
            try
            {
                idTicket = SelectIDTicket(ticket);
                db.PS_Delete_Ticket(idTicket);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Méthode de suppression d'un utilisateur
        public static void DeleteUser(C_User user)
        {
            try
            {
                db.PS_Delete_User(user.Username);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Méthode de réhabilitation d'un utilisateur
        public static void UndeleteUser(C_User user)
        {
            try
            {
                db.PS_Undelete_User(user.Username);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Other Update

        // Méthode d'activation d'un utilisateur
        public static void ActivateUser(C_User user)
        {
            try
            {
                db.PS_Other_ActivateUser(user.Username);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Méthode d'ajout d'une note à l'intervention
        public static void AddInterventionNote(C_Intervention interv, C_Ticket ticket)
        {
            int idInterv;
            try
            {
                idInterv = SelectIDIntervention(interv, ticket);
                db.PS_Other_AddInterventionNote(idInterv, interv.Note);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Méthode d'ajout d'une note à un ticket
        public static void AddTicketNote(C_Ticket ticket)
        {
            int idTicket;
            try
            {
                idTicket = SelectIDTicket(ticket);
                db.PS_Other_AddTicketNote(idTicket, ticket.Note);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Méthode de changement de mot de passe d'un utilisateur
        public static void ChangeUserPassword(C_User user)
        {
            try
            {
                db.PS_Other_ChangeUserPassword(user.Username, user.Password);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Méthode de fermeture d'un ticket
        public static void ConcludeTicket(C_Ticket ticket)
        {
            int idTicket;
            try
            {
                idTicket = SelectIDTicket(ticket);
                db.PS_Other_ConcludeTicket(idTicket);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Méthode de désactivation d'un utilisateur
        public static void DeactivateUser(C_User user)
        {
            try
            {
                db.PS_Other_DeactivateUser(user.Username);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Méthode de réouverture d'un ticket
        public static void ReopenTicket(C_Ticket ticket)
        {
            int idTicket;
            try
            {
                idTicket = SelectIDTicket(ticket);
                db.PS_Other_ReopenTicket(idTicket);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Select

        // Méthode de récupération d'un utilisateur
        public static C_User SelectUser(string usn)
        {
            C_User user;
            try
            {
                var usr = from u in db.Users
                          where u.Usn == usn && u.FDelete == false
                          select u;
                if (usr.Count() > 0)
                {
                    user = new C_User(usr.First().Usn,
                                      usr.First().Pwd,
                                      usr.First().FName,
                                      usr.First().LName,
                                      usr.First().Mail,
                                      usr.First().FAdmin,
                                      usr.First().FActive,
                                      usr.First().FDelete);
                }
                else
                {
                    user = new C_User();
                }
                return user;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Méthode de récupération d'un administratif
        public static C_Administrative SelectAdministrative(string usn)
        {
            try
            {
                var admin = from a in db.Administratives
                            where a.User.Usn == usn
                            select a;

                if (admin.Count() > 0)
                {
                    return new C_Administrative(admin.First().User.Usn,
                                                admin.First().User.Pwd,
                                                admin.First().User.FName,
                                                admin.First().User.LName,
                                                admin.First().User.Mail,
                                                admin.First().User.FAdmin,
                                                admin.First().User.FActive,
                                                admin.First().User.FDelete,
                                                admin.First().Salary,
                                                admin.First().InternPhone);
                }
                else
                {
                    return new C_Administrative();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Méthode de récupération d'un technicien
        public static C_Technical SelectTechnical(string usn)
        {
            try
            {
                var tech = from t in db.Technicals
                           where t.User.Usn == usn
                           select t;

                if (tech.Count() > 0)
                {
                    return new C_Technical(tech.First().User.Usn,
                                           tech.First().User.Pwd,
                                           tech.First().User.FName,
                                           tech.First().User.LName,
                                           tech.First().User.Mail,
                                           tech.First().User.FAdmin,
                                           tech.First().User.FActive,
                                           tech.First().User.FDelete,
                                           tech.First().HourRate,
                                           tech.First().GSM);
                }
                else
                {
                    return new C_Technical();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Méthode de récupération d'un client
        public static C_Client SelectClient(string name)
        {
            try
            {
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.Customers);
                var cli = from c in db.Customers
                          where c.Name == name
                          select c;
                if (cli.Count() > 0)
                {
                    return new C_Client(cli.First().Name,
                                        cli.First().ZipCode,
                                        cli.First().City,
                                        cli.First().Street,
                                        cli.First().StreetNB,
                                        cli.First().Tel,
                                        cli.First().Mail,
                                        cli.First().StreetBOX,
                                        cli.First().Fax);
                }
                else
                {
                    return new C_Client();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static C_Client SelectClient(int num)
        {
            try
            {
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.Customers);
                var cli = from c in db.Customers
                          where c.ID == num
                          select c;
                if (cli.Count() > 0)
                {
                    return new C_Client(cli.First().Name,
                                        cli.First().ZipCode,
                                        cli.First().City,
                                        cli.First().Street,
                                        cli.First().StreetNB,
                                        cli.First().Tel,
                                        cli.First().Mail,
                                        cli.First().StreetBOX,
                                        cli.First().Fax);
                }
                else
                {
                    return new C_Client();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Méthode de récupération d'un ticket
        public static C_Ticket SelectTicket(int num)
        {
            try
            {
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.Tickets);
                var ticket = from t in db.Tickets
                             where t.ID == num
                             select t;
                if (ticket.Count() > 0)
                {
                    C_Client tmpClient = SelectClient(ticket.First().IDCustomer);
                    C_Ticket tick = new C_Ticket(ticket.First().DateIN,
                                                 ticket.First().Subject,
                                                 (ticket.First().Note == null ? null : ticket.First().Note),
                                                 tmpClient);
                    var interv = from i in db.Interventions
                                 where i.IDTicket == ticket.First().ID
                                 select i;
                    foreach (Intervention i in interv)
                    {
                        C_Technical tech = SelectTechnical(i.Technical.User.Usn);
                        C_Intervention inter = new C_Intervention(i.DateBegin,
                                                                  i.DateEnd,
                                                                  i.Subject,
                                                                  i.TechnicalNote,
                                                                  tech);
                        tick.AddIntervInList(inter);
                    }
                    return tick;
                }
                else
                {
                    return new C_Ticket();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Méthode de vérification si un client existe
        public static bool CheckClientExists(string nameCli)
        {
            try
            {
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.Customers);
                bool inDB;
                var cli = from c in db.Customers
                          where c.Name == nameCli
                          select c;
                if (cli.Count() > 0)
                    inDB = true;
                else
                    inDB = false;
                return inDB;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Méthode de récup des clients dans la DB
        public static DataTable RetrieveAllClients()
        {
            DataTable dt;
            try
            {
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, db.Customers);
                dt = new DataTable();
                dt.Columns.Add("Name");
                dt.Columns.Add("ZipCode");
                dt.Columns.Add("City");
                dt.Columns.Add("Street");
                dt.Columns.Add("StreetNB");
                dt.Columns.Add("StreetBOX");
                var clients = from c in db.Customers
                              select c;
                foreach (Customer c in clients)
                {
                    string[] itemarray = new string[6];
                    itemarray[0] = c.Name.ToString();
                    itemarray[1] = c.ZipCode.ToString();
                    itemarray[2] = c.City.ToString();
                    itemarray[3] = c.Street.ToString();
                    itemarray[4] = c.StreetNB.ToString();
                    itemarray[5] = (c.StreetBOX == null ? null : c.StreetBOX.ToString());
                    dt.Rows.Add(itemarray);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // SELECT VUES

        // Méthode de récup de la vue V_OpenedTickets
        public static DataTable RetrieveOpenedTickets()
        {
            DataTable dt;
            try
            {
                dt = new DataTable();
                dt.Columns.Add("Numero");
                dt.Columns.Add("Date");
                dt.Columns.Add("Client");
                dt.Columns.Add("Sujet");

                var vue = from ot in db.V_OpenedTickets
                          select ot;
                foreach (V_OpenedTicket v in vue)
                {
                    string[] itemarray = new string[4];
                    itemarray[0] = v.ID.ToString();
                    itemarray[1] = v.DateIN.ToString();
                    itemarray[2] = v.Name.ToString();
                    itemarray[3] = v.Subject.ToString();
                    dt.Rows.Add(itemarray);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        // Méthode de récup de la vue V_AllTickets
        public static DataTable RetrieveAllTickets()
        {
            DataTable dt;
            try
            {
                dt = new DataTable();
                dt.Columns.Add("Numero");
                dt.Columns.Add("Date");
                dt.Columns.Add("Client");
                dt.Columns.Add("Sujet");
                var vue = from at in db.V_AllTickets
                          select at;
                foreach (V_AllTicket v in vue)
                {
                    string[] itemarray = new string[4];
                    itemarray[0] = v.ID.ToString();
                    itemarray[1] = v.DateIN.ToString();
                    itemarray[2] = v.Name.ToString();
                    itemarray[3] = v.Subject.ToString();
                    dt.Rows.Add(itemarray);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}