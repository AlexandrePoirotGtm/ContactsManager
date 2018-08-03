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
        public string Nom { get; set; }
        //public string Nom{ get;private set;}
        public string Prenom { get; set; }
        public string Numéro;
        public string Email { get; set; }
        public DateTime date { get; set; }

        public Contact()
        {

        }

        public Contact(string nom, string prenom)
        {
            Nom = nom;
            this.Prenom = prenom;
            Numéro = "";
            Email = "";
            
        }

        public Contact(string leNom, string lePrenom, string leNum,DateTime date,string Email)
        {
            Nom = leNom;
            Prenom = lePrenom;
            Numéro = leNum;
            this.Email = Email;
            this.date = date;
        }

        /*public DateTime GetDate()
        {
            return date;
        }
        public string Nom
        {
            get { return nom; }
            private set { nom = value; }
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
        }*/
    }
}
