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
                ChoixMenu(Choix, contact);
            } while (Choix != "4");
        }
        static void AffichageMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Menu\n\n1- Liste des Contacts\n2- Ajout des contacts\n3- Suppresion d'un contact\n4- Quitter\n\nTapez votre choix, puis validez avec entrer:");
        }
        static void ChoixMenu(string Choix, List<Contact> ListContact)
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
            Contact leContact = new Contact();
            leContact.Nom = SaisirChampsObligatoire("Rentrez le nom");
            leContact.Prenom = SaisirChampsObligatoire("Rentrez le prenom");
            
            leContact.Numéro = (PosezQuestion("Rentrez le numéro"));
            leContact.Email = (PosezQuestion("Rentrez le email"));
            leContact.date = (SaisirDate("Rentrez la date de naissance"));
            ListContact.Add(leContact);

            
            /*string prenom, nom, email;
            int num;
            DateTime date;
            prenom = SaisirChampsObligatoire("Rentrez le prénom du contact à ajouter");
            nom = SaisirChampsObligatoire("Rentrez le nom du contact à ajouter");
            num = SaisirInt("Rentrez le numéro du contact à ajouter");
            email = PosezQuestion("Rentrez l'émail du contact à ajouter");
            date = SaisirDate("Rentrez la date de naissance du contact à ajouter");
            ListContact.Add(new Contact(nom, prenom, num, date, email));*/
            Console.Clear();
        }
        static void ListerContacts(List<Contact> ListContact)
        {
            Console.Clear();
            foreach (Contact LeContact in ListContact)
            {
                Console.WriteLine("Prenom: " + LeContact.Prenom + "\nNom: " + LeContact.Nom + "\nNumero: " + LeContact.Numéro + "\nEmail: " + LeContact.Email + "\nDate de naissance: " + LeContact.date.ToShortDateString());
                Console.WriteLine("\n");
            }
            Console.ReadKey();
            Console.Clear();
        }
        static void SupprimerContact(List<Contact> ListContact)
        {
            Console.Clear();
            string g = PosezQuestion("Rentrez le nom du contact à supprimer");
            foreach (Contact leContact in ListContact)
            {
                if (g == leContact.Nom)
                {
                    ListContact.Remove(leContact);
                    break;
                }
            }

            Console.Clear();
        }

        static int RentrezInt(string entier)
        {
            return (int.Parse(entier));
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
            return (bool.Parse(bobol));
        }
        static DateTime RentrezDate(string date)
        {
            return (DateTime.Parse(date));
        }

        static string PosezQuestion(string question)
        {
            Console.WriteLine(question);
            return (Console.ReadLine());
        }

        static string SaisirChampsObligatoire(string question)
        {
            string saisie;
            saisie = PosezQuestion(question);
            while (string.IsNullOrWhiteSpace(saisie))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Champs requis. recommence:");
                Console.ForegroundColor = ConsoleColor.Green;
                saisie = Console.ReadLine();
            }
            return saisie;
        }

        static int SaisirInt(string entier)
        {
            return int.Parse(PosezQuestion(entier));
        }
        static double SaisirDouble(string dooble)
        {
            return double.Parse(PosezQuestion(dooble));
        }
        static bool Saisirbool(string bobol)
        {
            return bool.Parse(PosezQuestion(bobol));
        }
        static DateTime SaisirDate(string date)
        {
            return DateTime.Parse(PosezQuestion(date));
        }
        static decimal SaisirDécimal(string entier)
        {
            return decimal.Parse(PosezQuestion("Veuillez saisir un décimal : "));
        }


    }
}
