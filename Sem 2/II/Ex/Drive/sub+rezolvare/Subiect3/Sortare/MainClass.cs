using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sortare
{
    class MainClass
    {
        static void Main(string[] args)
        {
            SirdeSiruri sds = new SirdeSiruri("alex", "ana", "manu", "paul", "andrei", "ioana", "diana", "daria", "ioan", "sergiu");

  /*          Sortare.localhost.Service1 srv = new Sortare.localhost.Service1();
            sds.Afis();
            Console.WriteLine();
            for (int i = 0; i < sds.siruri.Length; i++)
            {

                Console.WriteLine(srv.Sorts(sds.siruri[i]));
            } */
           
 
            Stackp st = new Stackp();

            for (int i = 0; i < sds.siruri.Length; i++)
            {
                st.Push(sds.siruri[i]);
                
                
            }

            
            Console.WriteLine();
            for (int i = sds.siruri.Length-1; i >= 0; i--)
                Console.WriteLine(st.items[i]);

                

            Sortare.localhost.Service1 srv = new Sortare.localhost.Service1();

            Console.WriteLine();
            Console.WriteLine("Please wait...");
            srv.InsertDb(st.items);
            Console.WriteLine("Table populated!");

            Console.ReadKey();
        }

        
        
    }
}
