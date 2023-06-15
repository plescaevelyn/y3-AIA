using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamenII
{
    class Stiva
    {
        private Elem_lista _cap;

        public Stiva()
        {
            _cap = null;
        }

        public void PUSH(int i)
        {
            Elem_lista ptr = new Elem_lista(i);
            ptr.urmatorul = _cap;
            _cap = ptr;
        }

        public int POP()
        {
            int valret;
            if (_cap == null)
            {
                Console.WriteLine("Stiva goala");
                return 0;
            }
            valret = _cap.val;
            _cap = _cap.urmatorul;
            return valret;
        }

        public int get()
        {
            return _cap.val;
        }
    }
}
