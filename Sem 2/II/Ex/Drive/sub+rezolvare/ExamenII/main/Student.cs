using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamenII
{
    class Student:Persoane
    {
        private int _id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public Student()
        {
            this.nume = "Nume";
            this.prenume = "Pnume";
            this.sex = "Gen";
            this.varsta = 32;
            this.id = 12345;

        }

         public Student(string _fname, string _lname, string _gender, int _age, int id)
        {
            this.nume = _fname;
            this.prenume = _lname;
            this.sex = _gender;
            this.varsta = _age;
            this.id = id;
        }
    }
}
