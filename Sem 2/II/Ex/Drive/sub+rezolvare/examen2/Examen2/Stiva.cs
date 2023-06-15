using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Examen2
{
    public class Stiva : Baza
    {
        public override void PUSH(int i)
        {
            Elem_lista ptr = new Elem_lista(i);
            ptr.urmatorul = cap;
            cap = ptr;
        }

        public override int POP()
        {
            int valret;
            if (cap == null)
            {
                Console.WriteLine("Stiva goala");
                return 0;
            }
            valret = cap.val;
            cap = cap.urmatorul;
            return valret;
           
            
        }

        public override void Afisez()
        {
            Console.WriteLine("Stiva contine");
            base.Afisez();
        }

        public override int returnNrElemente()
        {
            int v = 0;
            Elem_lista ptr = new Elem_lista(0);
            ptr = cap;
            if (ptr == null)
                return 0;
            while (ptr != null)
            {
                v++;
                ptr = ptr.urmatorul;
            }
            return v;
        }

        public override List<string> returnAsList()
        {
            Elem_lista ptr = new Elem_lista(0);
            List<string> x = new List<string>();

            ptr = cap;
            if (ptr == null)
                return null;
            while (ptr != null)
            {
                x.Add(ptr.val.ToString());
                ptr = ptr.urmatorul;
            }
            return x;
        }
    }
}
