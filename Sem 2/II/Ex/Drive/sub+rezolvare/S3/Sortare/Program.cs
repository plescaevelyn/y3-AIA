using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sortare
{
    class Program
    {
        static void Main(string[] args)
        {
            SirDeSiruri sds = new SirDeSiruri("marcu","ana","dani","vasile","gheorghe","ion","marius","beni","dani","ionica");

            Sortare.localhost.Service1 service = new Sortare.localhost.Service1();
            sds.Afis();
            Console.WriteLine();
            
            for(int i = 0 ; i<sds.siruri.Length;i++)
            {
                Console.WriteLine(service.Sorts(sds.siruri[i]));
            }

            Console.ReadKey();

            StackE st = new StackE();

            for (int i = 0; i < sds.siruri.Length; i++)
            {
                st.Push(sds.siruri[i]);
            }

            Console.WriteLine();
            Console.WriteLine("Stiva contine =>>");
            Console.WriteLine();

            for (int i = sds.siruri.Length-1; i >= 0; i--)
            {
                
                Console.WriteLine(st.items[i]);
            }

            Sortare.localhost.Service1 srv = new Sortare.localhost.Service1();

            Console.WriteLine();
            Console.WriteLine("Asteapta ...");
            srv.InsertDb(st.items);
            Console.WriteLine("Tabel populat !");



            Console.ReadKey();
        }
    }
}
