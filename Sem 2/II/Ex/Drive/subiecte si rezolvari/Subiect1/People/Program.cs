using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace People
{
    class Program

    {
        private static readonly object balanceLock = new object();
        public static Person[] persons;
        public static List<int> list = new List<int>();
        public static int i;

        static void Main(string[] args)
        {
            int cnt = 1;
            persons = new Person[100];
            for (int i = 0; i < 100; i++)
            {
                if (i < 3)
                {
                    persons[i] = new Teacher();
                    if (cnt <= 10)
                    {
                        var teacher = (Teacher)persons[i]; //
                        Console.WriteLine(persons[i].Fname + " " + teacher.Lname + " " + teacher.Gender + " " + teacher.Age + " " + teacher.Position);
                        cnt++;
                    }
                }
                else
                {
                    persons[i] = new Student();
                    if (cnt <= 10)
                    {
                        var student = (Student)persons[i];
                        Console.WriteLine(student.Fname + " " + student.Lname + " " + student.Gender + " " + student.Age + " " + student.ID);
                        cnt++;
                    }
                }
            }


            var tasks = new Task[100];
            for (i = 3; i < tasks.Length; i++)
            {
                Thread sleepingThread = new Thread(Program.Routine);
                sleepingThread.Name = "Thread " + i;
                sleepingThread.Start();
                sleepingThread.Join();
            }
            Console.WriteLine("count: " + list.Count.ToString());
            Console.ReadLine();
        }
        private static void Routine()
        {
           // lock (balanceLock)
           // {
                Console.WriteLine(Thread.CurrentThread.Name + ": " + list.Count.ToString());
                var stud = (Student)persons[i];
                list.Add(stud.ID);
                Thread.Sleep(50);
            //}
        }

    }
    class Person
    {
        private string _fname;
        public string Fname
        {
            get { return _fname; }
            set { _fname = value; }
        }

        protected string _lname;
        public string Lname
        {
            get { return _lname; }
            set { _lname = value; }
        }

        internal string _gender;
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public int _age;
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