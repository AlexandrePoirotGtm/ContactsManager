using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            } while(Choix!="4");
        }
        static void AffichageMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Menu\n\n1- Liste des Contacts\n2- Ajout des contacts\n3- Suppresion d'un contact\n4- Quitter\n\nTapez votre choix, puis validez avec entrer:");
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
            string prenom, nom;
            int num;
            nom = PosezQuestion("Rentrez le nom du contact à ajouter");
            prenom = PosezQuestion("Rentrez le nom du contact à ajouter");
            num = SaisirInt("Rentrez le numéro du contact à ajouter");
            ListContact.Add(new Contact(nom,prenom,num));
            Console.Clear();
        }
        static void ListerContacts(List<Contact> ListContact)
        {
            Console.Clear();
            foreach (Contact LeContact in ListContact)
            {
                Console.WriteLine("Nom: "+LeContact.GetName()+"\nPrenom: "+LeContact.GetFirstName()+"\nNumero: "+LeContact.GetNum());
                Console.WriteLine("\n");
            }
            Console.ReadKey();
            Console.Clear();
        }
        static void SupprimerContact(List<Contact> ListContact)
        {
            Console.Clear();
            int g = SaisirInt("Rentrez le numéro du contact à supprimer");
            foreach(Contact leContact in ListContact)
            {
                if (g == leContact.GetNum())
                {
                    ListContact.Remove(leContact);
                    break;
                }
            }
            
            Console.Clear();
        }

        static int RentrezInt(string entier)
        {
            return(int.Parse(entier));
        }
        static double RentrezDouble(string dooble)
        {
            return (double.Parse(dooble));
        }
        static decimal RentrezDecimal(string DeciMal)
        {
            return (decimal.Parse(DeciMal));
        }
        static bool RentrezBool(string bobol)
        {
            return(bool.Parse(bobol));
        }
        static DateTime RentrezDate(string date)
        {
            return (DateTime.Parse(date));
        }

        static string PosezQuestion(string question)
        {
            Console.WriteLine(question);
            return(Console.ReadLine());
        }

        static int SaisirInt(string entier)
        {
            return int.Parse(PosezQuestion(entier));
        }
        static double SaisirDouble(string dooble)
        {
            return double.Parse(PosezQuestion("Veuillez saisir un double : "));
        }
        static bool Saisirbool(string bobol)
        {
            return bool.Parse(PosezQuestion("Veuillez saisir un bool : "));
        }
        static DateTime SaisirDate(string date)
        {
            return DateTime.Parse(PosezQuestion("Veuillez saisir une Date : "));
        }
        static decimal SaisirDécimal(string entier)
        {
            return decimal.Parse(PosezQuestion("Veuillez saisir un décimal : "));
        }
        
        class Contact
        {
            string nom;
            string prenom;
            int num;

            public Contact(string leNom,string lePrenom,int leNum)
            {
                nom = leNom;
                prenom = lePrenom;
                num = leNum;
            }

            public string GetName()
            {
                return nom;
            }
            public string GetFirstName()
            {
                return prenom;
            }
            public int GetNum()
            {
                return num;
            }
        }
    }
}
