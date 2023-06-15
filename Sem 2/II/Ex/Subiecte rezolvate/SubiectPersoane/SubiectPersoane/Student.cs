using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People
{
    class Student : Person
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public Student(string _fname, string _lname, string _gender, int _age, int _id)
        {
            this.Fname = _fname;
            this.Lname = _lname;
            this.Gender = _gender;
            this.Age = _age;
            this.ID = _id;
        }
        public Student()
        {
            this.Fname = "fname";
            this.Lname = "lname";
            this.Gender = "gender";
            this.Age = 0;
            this.ID = 0;
        }
    }
}