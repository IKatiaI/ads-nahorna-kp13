using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praktuchna_3
{
    public class User
    {
        private string name;
        private string surname;
        private string login;
        private string password;
        private bool status;
        private bool restriction;

        public User(string name, string surname, string login, string password, bool status, bool restriction)
        {
            this.name = name;
            this.surname = surname;
            this.login = login;
            this.password = password;
            this.status = status;
            this.restriction = restriction;
        }

        /*
        public string getName() => name;    // tomName = user.getName("Tomas");
        public string setName(string value) => name = value;    // user.setName("Tomas");
        */

        public string Name  // proprty to handle the field 'name'
        {
            get { return name; }    // tomName = user.Name;
            set { name = value; }   // user.Name = "Tomas";
        }
        public string Surname  // proprty to handle the field 'surname'
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Login  // proprty to handle the field 'login'
        {
            get { return login; }
        }
        public string Password  // proprty to handle the field 'password'
        {
            get { return password; }
            set { password = value; }
        }
        public bool Status  // proprty to handle the field 'status'
        {
            get { return status; }
            set { status = value; }
        }
        public bool Restriction  // proprty to handle the field 'restriction'
        {
            get { return restriction; }
            set { restriction = value; }
        }
    }
}
