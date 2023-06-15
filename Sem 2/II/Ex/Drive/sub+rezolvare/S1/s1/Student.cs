using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace People
{
   public  class Student : Person
    {
        private int _id;

        public int  Id
        {
        get {return _id ;}
        set {_id = value ;}
        }

        public Student()
        {
            this.Fname = "student_name";
            this.Lname = "studen_lname";
            this.Gender = "student_gender";
            this.Age = 20;
            this.Id = 10;
        }

        public Student(string _fname, string _lname, string _gender, int _age, int _id)
        {
            this.Fname = _fname;
            this.Lname = _lname;
            this.Gender = _gender;
            this.Age = _age;
            this.Id = _id;
        }
    }
}
