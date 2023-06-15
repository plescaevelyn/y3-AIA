using System;
using System.Collections.Generic;

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
}