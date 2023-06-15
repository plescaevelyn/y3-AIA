using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ExamenII
{
    class Program
    {
        static void Main(string[] args)
        {
            Persoane[] person = new Persoane[100];
            int contor = 0;
            string nume;
            string prenume;
            int varsta;
            string sex;
            int id;
            string pozitie;

            for (int i = 0; i < 100; i++)
            {
                if (i > 2)
                {
                    if (contor < 10)
                    {
                        Console.Write("Nume:  ");
                        nume = Console.ReadLine();
                        Console.Write("Prenume:  ");
                        prenume = Console.ReadLine();
                        Console.Write("Sex:  ");
                        sex = Console.ReadLine();
                        Console.Write("Varsta:  ");
                        varsta = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Id:  ");
                        id = Convert.ToInt32(Console.ReadLine());
                        person[i] = new Student(nume,prenume,sex,varsta,id);
                        var student = (Student)person[i];

                        Console.WriteLine(student.nume + " " + student.prenume + " " + student.varsta.ToString() + " " + student.sex + " " + student.id.ToString());
                        Console.ReadLine();


                    }
                    else
                    {
                        person[i] = new Student();
                        var student = (Student)person[i];
                    }

                    contor++;
                }
                else
                {
                    Console.Write("Nume:  ");
                    nume = Console.ReadLine();
                    Console.Write("Prenume:  ");
                    prenume = Console.ReadLine();
                    Console.Write("Sex:  ");
                    sex = Console.ReadLine();
                    Console.Write("Varsta:  ");
                    varsta = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Pozitie:  ");
                    pozitie = Console.ReadLine();


                    person[i] = new Profesor(nume,prenume,sex,varsta,pozitie);
                    var teacher = (Profesor)person[i];
                    Console.WriteLine(teacher.nume + " " + teacher.prenume + " " + teacher.varsta.ToString() + " " + teacher.sex + " " + teacher.pozitie);
                    Console.ReadLine();
                    contor++;
                }
            }

            //List<int> list = new List<int>();
            Stiva stiva = new Stiva();
            Thread t= new Thread(() =>
            {
                Adding(person, stiva);

            });
            t.Start();
            Console.ReadLine();
            }

        static void Adding(Persoane[] person, Stiva stiva)
        {
            for (int i = 0; i < 100; i++)
            {
                bool result = ((person[i] as Student) != null);
                if (result)
                {
                    var student = (Student)person[i];
                    stiva.PUSH(student.id);
                    Console.Write(" "+stiva.get().ToString());
                }
            }

        }

    }
}
