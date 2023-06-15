using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Ex2
{
    public class Coada : Baza
    {
        
        public override void PUSH(int i)
        {
            Elem_lista elem_nou = new Elem_lista(i);
            Elem_lista ptr = new Elem_lista(0);
            if (cap == null)
                cap = elem_nou;
            else
            {
                ptr = cap;
                while (ptr.urmatorul != null)
                    ptr = ptr.urmatorul;

                ptr.urmatorul = elem_nou;
            }
        }

       
        public override int POP()
        {
            int valret;
            if (cap == null)
            {
                Console.WriteLine("Coada goala");
                return 0;
            }
            valret = cap.val;
            cap = cap.urmatorul;
            return valret;
        }

        public override void Afisez()
        {
            Console.WriteLine("Coada contine");
            base.Afisez();
        }
    }
}