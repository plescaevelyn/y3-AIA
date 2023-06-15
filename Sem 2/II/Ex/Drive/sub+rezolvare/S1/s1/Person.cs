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
        protected string _lname;
        internal string _gender;
        public int _age;

        public string Fname
        {
            get {return _fname; }
            set { _fname = value; }
        }

        protected string Lname
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
                        if(contor < 10)
                        {
                            Console.WriteLine(teacher.Fname+ " "+teacher.Lname+ " "+teacher.Age.ToString()+ " " +teacher.Gender+ " "+teacher.Position);
                            Console.ReadLine();
                        }
                        contor++;
                    }
                }

            List<int> list = new List<int>();

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
                    Console.Write(" "+list.Count.ToString());
                }
            }

        }

        }
        
    }

