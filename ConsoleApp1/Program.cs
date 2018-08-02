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

        public DateTime GetDate()
        {
            return date;
        }
    }
}
