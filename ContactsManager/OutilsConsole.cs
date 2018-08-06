using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ContactsManager
{
    public static class OutilsConsole
    {
         public static string PosezQuestion(string question)
        {
            Console.WriteLine(question);
            return (Console.ReadLine());
        }
        public static string PosezQuestionObligatoire(string question)
        {
            string laQuestion = PosezQuestion(question);
            while (string.IsNullOrWhiteSpace(laQuestion))
            {
                laQuestion = PosezQuestion(question);
            }
            return laQuestion;
        }
        public static int SaisirInt(string entier)
        {
            return int.Parse(PosezQuestion(entier));
        }
        public static double SaisirDouble(string dooble)
        {
            return double.Parse(PosezQuestion(dooble));
        }
        static bool Saisirbool(string bobol)
        {
            return bool.Parse(PosezQuestion(bobol));
        }
        public static DateTime SaisirDate(string date)
        {
            bool trying;
            DateTime datee = DateTime.Parse("25/04/1995");
            trying = DateTime.TryParse(PosezQuestion(date), out datee);
            return datee;
        }
        public static DateTime SaisirDateObligatoire(string date)
        {
            bool trying;
            DateTime datee = DateTime.Parse("25/04/1995");
            do
            {
                trying = DateTime.TryParse(PosezQuestion(date), out datee);
                Console.ForegroundColor = ConsoleColor.Red;
            } while (!trying);
            Console.ForegroundColor = ConsoleColor.Green;
            return datee;
        }
        static decimal SaisirDécimal(string entier)
        {
            return decimal.Parse(PosezQuestion("Veuillez saisir un décimal : "));
        }
    }
}