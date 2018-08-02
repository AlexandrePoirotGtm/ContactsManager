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
            List<string> contact = new List<string>();
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
            Console.WriteLine("Menu\n 1- Liste des Contacts\n 2- Ajout des contacts\n 3- Suppresion d'un contact\n 4- Quitter\nTapez votre choix, puis validez avec entrer:");
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
                    Console.ForegroundColor = ConsoleColor.Red;
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
            foreach (String LeContact in ListContact)
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
            return int.Parse(PosezQuestion("Veuillez saisir un entier : "));
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
    }
}
