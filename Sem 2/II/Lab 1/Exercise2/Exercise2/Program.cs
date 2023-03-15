using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    internal class Program
    {
        static void Main(String[] args)
        {
            Operations numbers0 = new Operations(3, 5);
            Operations numbers1 = new Operations(10, 4);
            Operations numbers2 = new Operations(432, 5);

            numbers0.displayNumbersAndOperations(numbers0);
            numbers1.displayNumbersAndOperations(numbers1);
            numbers2.displayNumbersAndOperations(numbers2);
        }
    }
}
