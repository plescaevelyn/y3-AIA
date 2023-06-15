using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program

    {
        static ConsoleApp1.ServiceReference1.SortingServiceSoapClient sortare = new ConsoleApp1.ServiceReference1.SortingServiceSoapClient();

        static void Main(string[] args)
        {
           
            List<String> l = new List<String>() { "hdfh", "dfv", "jbv", "yguy", "bvd", "bvd", "gfdgfdd", "hhsadf", "iidcdsdv", "jjagbbfd" };
            SirdeSiruri ss = new SirdeSiruri(l);
            for(int i = 0; i<ss.siruri.Count;i++)
            {
                ss.siruri[i] = sortare.Sort(ss.siruri[i]);
            }
            ss.Afis();

            newStack stack = new newStack();
            foreach (String ll in l)
                stack.Push(ll);
            foreach (String s in stack.items)
            {
                Console.WriteLine(s);
                sortare.insertInDB(s);
            }
            Console.WriteLine("Am terminat inserarea");
            Console.ReadLine();
        }

    }
    public class SirdeSiruri
    {
        public  List<String> siruri = new List<String>(10);
        public SirdeSiruri(List<String> l)
        {
            if (l.Count <= 10)
            {
                foreach (String s in l)
                {
                    siruri.Add(s);
                }
            }
            else
                Console.WriteLine("error");
            
        }
       


        public void Afis()
        {
            foreach (String s in siruri)
            {
                Console.WriteLine(s);
            }
        }
    }
    public class newStack
    {
        public const int MaxSize = 10;
        public String[] items = new String[MaxSize];
        public int currentIndex = -1;

        public newStack()
        { }

        public bool IsEmpty()
        {
            if (currentIndex < 0)
                return true;
            else
                return false;

        }

        public void Push(String item)
        {
            if (currentIndex >= MaxSize - 1)
                throw new InvalidOperationException("Stack is full!");

            currentIndex++;
            items[currentIndex] = item;
        }

        public string Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty!");

            string item = items[currentIndex];
            items[currentIndex] = null;
            currentIndex--;

            return item;


        }

    }
}
