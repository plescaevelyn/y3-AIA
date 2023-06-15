using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Examen2
{
    public abstract class Baza
    {
        private Elem_lista _cap;
        public Baza()
        {
            _cap = null;
        }

        public virtual void PUSH(int i)
        {
            
        }

        public virtual int POP()
        {
            return 0;
        }

        public virtual int returnNrElemente()
        {
            return 0;
        }
        public virtual List<string> returnAsList()
        {
            return null;
        }
        public virtual void Afisez()
        {
            Elem_lista ptr = new Elem_lista(0);
            ptr = _cap;
            if (ptr == null)
                Console.WriteLine("-");
            while (ptr != null)
            {
                Console.WriteLine(ptr.val);
                ptr = ptr.urmatorul;
            }
            Console.WriteLine();
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
