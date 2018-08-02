using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacto
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Contact
    {
        private string nom;
        private string prenom;
        private int num;
        private DateTime date;

        public Contact(string leNom, string lePrenom, int leNum)
        {
            nom = leNom;
            prenom = lePrenom;
            num = leNum;
            date = DateTime.Now;
        }

        public DateTime GetDate()
        {
            return date;
        }
        public string Nom
        {
            get {return nom;}
            private set {nom = value;}
        }
        public string Prenom
        {
            get { return prenom; }
            private set { prenom = value; }
        }      
        public int Numéro
        {
            get { return num; }
            private set { num = value; }
        }
    }
}
