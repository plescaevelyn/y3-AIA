using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subiect8_Stiva
{
    public abstract class Baza
    {
        public ElementeLista _cap;
        public ElementeLista cap
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
        public virtual void Afisez()
        {
            ElementeLista ptr = new ElementeLista(0);
            ptr = _cap;
            if (ptr == null)
                Console.WriteLine(" Structura vida");
            while (ptr != null)
            {
                Console.WriteLine(ptr.val);
                ptr = ptr.urmatorul;
            }
        }
    }
}
