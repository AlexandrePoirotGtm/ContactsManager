using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Contacto;
namespace ContactsManager
{
    class Program
    {
        

        static void Main(string[] args)
        {
            List<Contact> contact = new List<Contact>();
            string Choix;
            do
            {
                AffichageMenu();
                Choix = Console.ReadLine();
                ChoixMenu(Choix,contact);          
            } while(Choix!="5");
        }
        static void AffichageMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Menu\n\n1- Liste des Contacts\n2- Ajout des contacts\n3- Suppresion d'un contact\n4- Changer un Contact\n5- Quitter\n\nTapez votre choix, puis validez avec entrer:");
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
            foreach (Contact LeContact in ListContact)
            {
                Console.WriteLine("Prenom: "+LeContact.Prenom+ "\nNom: " + LeContact.Nom + "\nNumero: " +LeContact.Num+"\nEmail: "+LeContact.Email+"\nDate de naissance: "+ LeContact.Date.ToShortDateString());
                Console.WriteLine("\n");
            }
            Console.ReadKey();
            Console.Clear();
        }
        static void SupprimerContact(List<Contact> ListContact)
        {
            Console.Clear();
            string g = OutilsConsole.PosezQuestion("Rentrez le Nom du contact à supprimer");
            foreach(Contact leContact in ListContact)
            {
                if (g == leContact.Nom)
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
            string nom = OutilsConsole.PosezQuestion("Appeler le nom du contact a changer");
            foreach(Contact leContact in ListContact)
            {
                if (nom == leContact.Nom)
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
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Pas de Contact correspondant à ce Nom");
            Console.ForegroundColor = ConsoleColor.Green;
        }


    
        
        
    }
}
