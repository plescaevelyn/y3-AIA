// See https://aka.ms/new-console-template for more information
// Sa se determine si sa se afiseze primii n termeni ai secventei Fibonacci. 
// F0 = 0, F1 = 1, dupa care se utilizeaza formula recursiva Fn = Fn-1 + Fn-2

int f0 = 0;
int f1 = 1;
int n, i;

Console.WriteLine("Please enter the number of elements of the Fibonacci sequence you want to generate:\t");
n = int.Parse(Console.ReadLine());  

if (n <= 0)
{
    Console.WriteLine("Null sequence");
} else if (n == 1)
{
    Console.WriteLine(f0);
} else if (n == 2)
{
    Console.WriteLine(f0 + "\t" + f1);
} else
{
    Console.Write("\n" + f0 + "\t" + f1 + "\t");

    for (i = 2; i < n; i++)
    {
        int fi = f0 + f1;
        f0 = f1;
        f1 = fi;
        Console.Write(fi + "\t");
    }
}