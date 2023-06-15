using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subiect8_Stiva
{
    public class ElementeLista
    {
        private int _val;
        private ElementeLista _urmatorul;

        public ElementeLista(int i)
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
        public ElementeLista urmatorul
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
