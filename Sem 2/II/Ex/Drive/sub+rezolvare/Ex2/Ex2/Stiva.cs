using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;


namespace Ex2
{
    public class Stiva : Baza 
    {
        [WebMethod]
        public override void PUSH(int i)
        {
            Elem_lista ptr = new Elem_lista(i);
            ptr.urmatorul = cap;
            cap = ptr;
        }

        [WebMethod]
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
    }
}