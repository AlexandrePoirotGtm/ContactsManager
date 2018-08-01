using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManager
{
    class Program
    {
        static List<string> contact = new List<string>();

        static void Main(string[] args)
        {
            string Choix;
            do
            {
                AffichageMenu();
                Choix = Console.ReadLine();
                ChoixMenu(Choix,contact);
                
            } while(Choix!="4");
        }
        static void AffichageMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Menu\n1. Liste des Contacts\n2. Ajout des contacts\n3. Suppresion d'un contact\n4. Quitter\nTapez votre choix, puis validez avec entrer:");
        }
        
        static void ChoixMenu(string Choix,List<string> ListContact)
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

                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Mauvais choix");
                    break;
            }
        }
        static void AjouterContact(List<string> ListContact)
        {
            Console.Clear();
            Console.WriteLine("Rentrez le nom du contact à ajouter");
            ListContact.Add(Console.ReadLine());
            Console.Clear();
        }

        static void ListerContacts(List<string> ListContact)
        {
            Console.Clear();
            foreach (String LeContact in contact)
            {
                Console.WriteLine(LeContact);
                Console.WriteLine("\n");
            }
            Console.ReadKey();
            Console.Clear();
        }
        static void SupprimerContact(List<string> ListContact)
        {
            Console.Clear();
            Console.WriteLine("Rentrez le nom du contact à supprimer");
            ListContact.Remove((Console.ReadLine()));
            Console.Clear();
        }

    }
}
