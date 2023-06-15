using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubiectPersoaneStiva
{
    class Teacher : Person
    {
        private string _position;
        public string Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public Teacher()
        {
            this.Fname = "fname";
            this.Lname = "lname";
            this.Gender = "gender";
            this.Age = 0;
            this.Position = "position";

        }
        public Teacher(string _fname, string _lname, string _gender, int _age, string _position)
        {
            this.Fname = _fname;
            this.Lname = _lname;
            this.Gender = _gender;
            this.Age = _age;
            this.Position = _position;

        }
    }
}
