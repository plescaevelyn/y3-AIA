using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace SubiectPersoaneStiva
{
    class Person
    {
        private string _fname;
        protected string _lname;
        internal string _gender;
        public int _age;

        public string Fname
        {
            get { return _fname; }
            set { _fname = value; }
        }

        public string Lname
        {
            get { return _lname; }
            set { _lname = value; }
        }

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        public Person()
        {
            this.Fname = "Jane";
            this.Lname = "Doe";
            this.Gender = "f";
            this.Age = 21;
        }
        Person(string _fname, string _lname, string _gender, int _age)
        {
            this.Fname = _fname;
            this.Lname = _lname;
            this.Gender = _gender;
            this.Age = _age;
        }
    }
}
