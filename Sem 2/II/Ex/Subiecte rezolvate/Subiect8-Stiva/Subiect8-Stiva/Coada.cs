using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subiect8_Stiva
{
    public class Coada : Baza
    {
        public override void PUSH(int i)
        {
            ElementeLista elem_nou = new ElementeLista(i);
            ElementeLista ptr = new ElementeLista(0);
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
        public int NrElementeImpare()
        {
            int NrElementeImpare = 0;
            ElementeLista ptr = new ElementeLista(0);
            ptr = _cap;
            if (ptr == null)
                return 0;
            while (ptr != null)
            {
                if (ptr.val % 2 == 1) NrElementeImpare++;
                Console.WriteLine(ptr.val);
                ptr = ptr.urmatorul;
            }
            return NrElementeImpare;
        }
    }
}
