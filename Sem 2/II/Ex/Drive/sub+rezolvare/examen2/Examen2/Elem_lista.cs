using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Examen2
{
    public class Elem_lista
    {
        private int _val;
        private Elem_lista _urmatorul;
        public Elem_lista(int i)
        {
            _val = i;
            _urmatorul = null;
        }
        public int val
        {
            get
            {
                return _val;
            }
            set
            {
                _val = value;
            }
        }
        public Elem_lista urmatorul
        {
            get
            {
                return _urmatorul;
            }
            set
            {
                _urmatorul = value;
            }
        }

    }
}
