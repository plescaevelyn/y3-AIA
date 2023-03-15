// See https://aka.ms/new-console-template for more information
/* Sa se introduca un sir de numere intregi de la tastatura si sa se calculeze media geometrica si aritmetica a numerelor */

using System;

namespace Exercise5 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int product = 1;

            Console.WriteLine("Introdu lungimea sirului de numere:\t");
            int sequenceLength = int.Parse(Console.ReadLine());
            int[] sequence = new int[sequenceLength];

            Console.WriteLine("Introdu sirul de numere:\t");
            for (int i = 0; i < sequenceLength; i++)
            {
                sequence[i] = int.Parse(Console.ReadLine());
                sum += sequence[i];
                product *= sequence[i];
            }

            Console.WriteLine("Media aritmetica a numerelor este:\t{0}\n" +
                "Media geometrica a numerelor este:\t{1}\n",
                sum / sequenceLength, Math.Sqrt(product));
        }
    }
}