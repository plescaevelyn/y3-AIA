using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Ex2
{
    public class Baza
    {
        private Elem_lista _cap;

        public Baza()
        {
            _cap = null;
        }

        public virtual void PUSH(int i)
        {
            // nu stiu cum se defineste
        }

        public virtual int POP()
        {
            // nu stiu cum se defineste
            return 0;
        }

        [WebMethod]
        public virtual void Afisez()
        {
            Elem_lista ptr = new Elem_lista(0);
            ptr = _cap;
            if (ptr == null)
                Console.WriteLine(" Structura vida");
            while (ptr != null)
            {
                Console.WriteLine(ptr.val);
                ptr = ptr.urmatorul;
            }
        }
        public Elem_lista cap
        {
            get
            {
                return _cap;
            }
            set
            {
                _cap = value;
            }
        }
    }
}