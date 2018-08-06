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
        public string Prenom { get; set; }
        public string Num { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public Contact()

        {
        }
        public Contact(string leNom, string lePrenom, string leNum, DateTime date, string Email)
        {

            this.Nom = leNom;
            Prenom = lePrenom;
            Num = leNum;
            this.Email = Email;
            Date = date;

    }
}