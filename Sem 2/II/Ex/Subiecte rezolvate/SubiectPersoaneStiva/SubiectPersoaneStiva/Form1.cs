using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System;

namespace SubiectPersoaneStiva
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
                        teacher.Age = random.Next(1, 50) * cnt;
                        teacher.Position = "p" + cnt;

                        MessageBox.Show(teacher.Fname + " " + teacher.Lname + " " + teacher.Gender + " " + teacher.Age + " " + teacher.Position);
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
            for (int i = 3; i < 10; i++)
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
}