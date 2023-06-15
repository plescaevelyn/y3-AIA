using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace People
{
    public class Person
    {
        private string _fname;

        public string Fname
        {
            get { return _fname; }
            set { _fname = value; }
        }
        private string _lname;

        protected string Lname
        {
            get { return _lname; }
            set { _lname = value; }
        }
        private string _gender;

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        private int _age;

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }


        static void Main(string[] args)
        {
            Person[] person = new Person[100];
            int contor = 0;
            for (int i = 0; i < 100; i++)
            {

                if (i > 2)
                {
                    person[i] = new Student();
                    var student = (Student)person[i];
                    if (contor < 10)
                    {
                        Console.WriteLine(student.Fname + " " + student.Lname + " " + student.Age.ToString() + " " + student.Gender + " " + student.Id.ToString());
                        Console.ReadLine();
                    }
                    contor++;
                }


                else
                {
                    person[i] = new Teacher();
                    var teacher = (Teacher)person[i];
                    if (contor < 10)
                    {
                        Console.WriteLine(teacher.Fname + " " + teacher.Lname + " " + teacher.Age.ToString() + " " + teacher.Gender + " " + teacher.Position);
                        Console.ReadLine();
                    }
                    contor++;
                }

            }

            List<int> list = new List<int>();


            //Thread t1 = new Thread(() => Adding(person, list));
            //t1.Start();

            Task.Factory.StartNew(() =>
            {
                Adding(person, list);

            });


            Console.ReadLine();
        }


        static void Adding(Person[] person, List<int> list)
        
        {

            for (int i = 0; i < 100; i++)
            {
                bool result = ((person[i] as Student) != null);
                if (result)
                {
                    var student = (Student)person[i];
                    list.Add(student.Id);
                    Console.WriteLine(list.Count.ToString());
                    // Console.ReadLine();
                }
            }
        }

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
                this.Fname = "Fname";
                this.Lname = "lname";
                this.Gender = "_gender";
                this.Age = 20;
                this.Position = "rector";

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

        class Student : Person
        {
            private int _id;

            public int Id
            {
                get { return _id; }
                set { _id = value; }
            }

            public Student()
            {
                this.Fname = "student_name";
                this.Lname = "student_lname";
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
}
