using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Contacto;
namespace ContactsManager
{
    class Program
    {
        

        static void Main(string[] args)
        {
            List<Contact> contacts = new List<Contact>();
            var cheminFichier = @"S:\contact.txt";
            if (File.Exists(cheminFichier))
            {
                IEnumerable<string> lignesFichiers = File.ReadLines(cheminFichier);
                foreach(var  lignesFichier in lignesFichiers)
                {
                    string[] champs = lignesFichier.Split(';');
                    var contact = new Contact();
                    contact.Prenom = champs[0];
                    contact.Nom = champs[1];
                    contact.Num = champs[2];
                    contact.Email = champs[3];
                    contact.Date = DateTime.Parse(champs[4]);
                    contacts.Add(contact);
                }
            }
            else
            {
            }
            string Choix;
            do
            {
                AffichageMenu();
                Choix = Console.ReadLine();
                ChoixMenu(Choix,contacts);          
            } while(Choix!="Q" && Choix !="q");
            var contenueFichier = new StringBuilder();
            foreach (var contact in contacts)
            {
                contenueFichier.AppendLine($"{contact.Prenom};{contact.Nom};{contact.Num};{contact.Email};{contact.Date}");
            }
            File.WriteAllText(cheminFichier,contenueFichier.ToString());
        }

        static void AffichageMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Menu\n\n1- Liste des Contacts\n2- Ajout des contacts\n3- Suppresion d'un contact\n4- Changer un Contact\n5- Trier les contacts\n6- Filtrer les contacts\nQ- Quitter\n\nTapez votre choix, puis validez avec entrer:");
        }
        static void ChoixMenu(string Choix,List<Contact> ListContact)
        {
            switch (Choix)
            {
                case "1":
                    ListerContacts(ListContact);
                    break;

                case "2":
                    AjouterContact(ListContact);
                    break;

                case "3":
                    SupprimerContact(ListContact);
                    break;

                case "4":
                    ChangerContact(ListContact);
                    break;

                case "5":
                    TrierContact(ListContact);
                    break;

                case ("6"):
                    FiltrerContact(ListContact);
                    break;

                case ("Q"):
                case ("q"):

                    break;

                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Mauvais choix");
                    break;
            }
        }

        static void AjouterContact(List<Contact> ListContact)
        {
            Console.Clear();
            Contact LeContact = new Contact();
            LeContact.Prenom = OutilsConsole.PosezQuestionObligatoire("Rentrez le prénom du contact à ajouter");
            LeContact.Nom = OutilsConsole.PosezQuestionObligatoire("Rentrez le nom du contact à ajouter");
            LeContact.Num = OutilsConsole.PosezQuestion("Rentrez le numéro du contact à ajouter");
            LeContact.Email = OutilsConsole.PosezQuestion("Rentrez l'émail du contact à ajouter");
            LeContact.Date = OutilsConsole.SaisirDate("Rentrez la date de naissance du contact à ajouter");
            ListContact.Add(LeContact);
            Console.Clear();
        }
        static void ListerContacts(List<Contact> ListContact)
        {
            Console.Clear();
            AfficherListContact(ListContact);
            Console.ReadKey();
            Console.Clear();
        }
        static void SupprimerContact(List<Contact> ListContact)
        {
            Console.Clear();
            AfficherListContact(ListContact);
            string g = OutilsConsole.PosezQuestion("\nRentrez le Nom du contact à supprimer:");
            foreach(Contact leContact in ListContact)
            {
                if (g.ToLower() == leContact.Nom.ToLower())
                {
                    ListContact.Remove(leContact);
                    break;
                }
            }
            
            Console.Clear();
        }
        static void ChangerContact(List<Contact> ListContact)
        {
            Console.Clear();
            AfficherListContact(ListContact);
            string nom = OutilsConsole.PosezQuestion("\nAppeler le nom du contact a changer");
            foreach(Contact leContact in ListContact)
            {
                if (nom.ToLower() == leContact.Nom.ToLower())
                {
                    Console.Clear();
                    string choix = OutilsConsole.PosezQuestion("Quel est l'élément du Contact que vous voulez Changer?\n1- Le nom\n2- Le prenom\n3- Le numéro\n4- L'émail\n5- La date de naissance");
                    switch(choix)
                    {
                        case "1":
                            Console.Clear();
                            leContact.Nom = OutilsConsole.PosezQuestionObligatoire("Quel Nouveau Nom voulez-vous?");
                            break;

                        case "2":

                            Console.Clear();
                            leContact.Prenom = OutilsConsole.PosezQuestionObligatoire("Quel Nouveau Prenom voulez-vous?");
                            break;

                        case "3":
                            Console.Clear();
                            leContact.Num = OutilsConsole.PosezQuestionObligatoire("Quel Nouveau Numéro voulez-vous?");
                            break;

                        case "4":
                            Console.Clear();
                            leContact.Email = OutilsConsole.PosezQuestionObligatoire("Quel Nouveau Email voulez-vous?");
                            break;

                        case "5":
                            Console.Clear();
                            leContact.Date = OutilsConsole.SaisirDate("Quel Nouvelle Date de Naissance voulez-vous?");
                            break;
                        default:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Mauvais choix");
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                    }
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Pas de Contact correspondant à ce Nom");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }
            
        }
        static void TrierContact(List<Contact> ListContact)
        {
            Console.Clear();
            string c = OutilsConsole.PosezQuestionObligatoire("Trier par :\n-1 Nom\n-2 Prenom");
            var requete = from Contact in ListContact
                          select Contact;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            if (c == "1")
            {
                 requete = from Contact in ListContact
                              orderby Contact.Nom ascending
                              select Contact;
                foreach (var Resultat in requete)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    AfficherChamps("Nom",10);
                    AfficherChamps("Prenom",10);
                    AfficherChamps("Numéro",11);
                    AfficherChamps("Email",15);
                    AfficherChamps("Date",6);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Green;
                    AfficherChamps(Resultat.Nom, 10);
                    AfficherChamps(Resultat.Prenom, 10);
                    AfficherChamps(Resultat.Num, 11);
                    AfficherChamps(Resultat.Email, 15);
                    AfficherChamps(Resultat.Date.ToString(),10);
                    Console.WriteLine("");

                }
                Console.WriteLine("");
            }
            else
            {
                 requete = from Contact in ListContact
                              orderby Contact.Prenom ascending
                              select Contact;
                foreach (var Resultat in requete)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    AfficherChamps("Prenom", 10);
                    AfficherChamps("Nom", 10);
                    AfficherChamps("Numéro", 11);
                    AfficherChamps("Email", 15);
                    AfficherChamps("Date", 6);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Green;
                    AfficherChamps(Resultat.Prenom, 10);
                    AfficherChamps(Resultat.Nom, 10);
                    AfficherChamps(Resultat.Num, 11);
                    AfficherChamps(Resultat.Email, 15);
                    AfficherChamps(Resultat.Date.ToString(), 10);
                    Console.WriteLine("");
                }
            }
        }
        static void FiltrerContact(List<Contact> ListContact)
        {
            Console.Clear();
            Console.WriteLine("Un début de nom ou prénom?");
            var saisie = Console.ReadLine();
            var contactsTrouves = ListContact 
                .Where(x => x.Prenom.StartsWith(saisie, StringComparison.OrdinalIgnoreCase)
                            || x.Nom.StartsWith(saisie, StringComparison.OrdinalIgnoreCase))
                .ToList();
            foreach (var Resultat in contactsTrouves)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                AfficherChamps("Nom", 10);
                AfficherChamps("Prenom", 10);
                AfficherChamps("Numéro", 11);
                AfficherChamps("Email", 15);
                AfficherChamps("Date", 6);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                AfficherChamps(Resultat.Nom, 10);
                AfficherChamps(Resultat.Prenom, 10);
                AfficherChamps(Resultat.Num, 11);
                AfficherChamps(Resultat.Email, 15);
                AfficherChamps(Resultat.Date.ToString(), 10);
                Console.WriteLine("");
            }

            Console.WriteLine();
            Console.WriteLine("\nAppuie sur une touche pour revenir au menu...");
            Console.ReadKey();
            Console.Clear();
        }
        static void AfficherChamps(string leChamps,int longeur)
        {
            leChamps = (leChamps ?? string.Empty);
           // Console.ForegroundColor = ConsoleColor.Blue;
            leChamps = leChamps.Substring(0, Math.Min(leChamps.Length,longeur));
            Console.Write($"{leChamps.PadRight(longeur)} | ");
            //Console.ForegroundColor = ConsoleColor.Green;
        }
        static void AfficherListContact(List<Contact> ListContact)
        {
            foreach (Contact LeContact in ListContact)
            {

                Console.ForegroundColor = ConsoleColor.Blue;
                AfficherChamps("Nom", 10);
                AfficherChamps("Prenom", 10);
                AfficherChamps("Numéro", 11);
                AfficherChamps("Email", 15);
                AfficherChamps("Date", 6);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                AfficherChamps(LeContact.Nom, 10);
                AfficherChamps(LeContact.Prenom, 10);
                AfficherChamps(LeContact.Num, 11);
                AfficherChamps(LeContact.Email, 15);
                AfficherChamps(LeContact.Date.ToString(), 10);
                Console.WriteLine("");
            }
        }
    }
}
