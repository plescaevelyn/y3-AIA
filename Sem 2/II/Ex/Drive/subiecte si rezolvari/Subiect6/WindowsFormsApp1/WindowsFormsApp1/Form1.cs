using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Person[] persons;
            int cnt = 1;
            persons = new Person[100];
            for (int i = 0; i < 100; i++)
            {
                if (i < 3)
                {
                    persons[i] = new Teacher();
                    if (cnt <= 10)
                    {
                        var teacher = (Teacher)persons[i];
                        Random random = new Random();
                        teacher.Fname = "Teacher";
                        teacher.Lname = cnt.ToString();
                        teacher.Gender = "f";
                        teacher.Age = random.Next(1,50) * cnt;
                        teacher.Position = "p" + cnt;

                        MessageBox.Show(teacher. Fname + " " + teacher.Lname + " " + teacher.Gender + " " + teacher.Age + " " + teacher.Position);
                        cnt++;
                    }
                }
                else
                {
                    persons[i] = new Student();
                    if (cnt <= 10)
                    {
                        var student = (Student)persons[i];
                        Random random = new Random();
                        student.Fname = "Student";
                        student.Lname = cnt.ToString();
                        student.Gender = "f";
                        student.Age = random.Next(1, 20) * cnt;
                        student.ID = random.Next(2000);

                        MessageBox.Show(student.Fname + " " + student.Lname + " " + student.Gender + " " + student.Age + " " + student.ID);
                        cnt++;
                    }
                }
            }

            Coada c = new Coada();
            for(int i =3;i<10;i++)
            {
                var stud = (Student)persons[i];
                c.Push(stud);
            }
            for (int i = 3; i < 10; i++)
            {
                
                String stud = c.Pop();
                MessageBox.Show(stud);
            }

            FileStream fs = new FileStream("DataFile.dat", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, c);
            }
            catch (SerializationException ex)
            {
                Console.WriteLine("Failed to serialize. Reason: " + ex.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
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

    class Coada
    {
        public const int MaxSize = 10;
        public Student[] items = new Student[MaxSize];
        public int currentIndex = -1;

        public Coada()
        { }

        public bool IsEmpty()
        {
            if (currentIndex < 0)
                return true;
            else
                return false;

        }

        public void Push(Student item)
        {
            if (currentIndex >= MaxSize - 1)
                throw new InvalidOperationException("Coada este plina!");

            currentIndex++;
            for(int i = currentIndex; i>0 ; i--)
            {
                items[i] = items[i - 1];
            }
            items[0] = item;
        }

        public string Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Coada este goala!");

            Student item = items[currentIndex];
            items[currentIndex] = null;
            currentIndex--;
            return item;
        }

    }
}
