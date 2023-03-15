// See https://aka.ms/new-console-template for more information
/*
    Sa se calculeze greutatea ideala (kg) in functie de inaltime (cm), varsta (ani) si sex (f sau m).
    Sa se creeze o clasa noua care sa contina trei metode: 
    doua pentru calculul greutatii si una pentru afisarea greutatii ideale utilizand metodele date.
    Parametri sunt cititi de la tastatura.
 */

using Exercise_4;
using System;

namespace Exercise_4 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float height;
            float age;
            char gender;

            Console.WriteLine("Please enter your gender [f/m], age and height in this order!");

            Console.WriteLine("Please enter your gender [f/m]:\t"); gender = Console.ReadLine()[0];
            Console.WriteLine("Please enter your age:\t"); age = float.Parse(Console.ReadLine());
            Console.WriteLine("Please enter your height:\t"); height = float.Parse(Console.ReadLine());

            IdealWeight person = new IdealWeight(gender, height, age);

            person.displayIdealWeight(gender, height, age);
        }
    }
}