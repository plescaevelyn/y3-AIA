using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subiect14_2017
{
    class Sortare
    {
        public delegate bool Comparare(object x, object y);

        static public void Sort(object[] sir, Comparare comp)
        {
            for (int i = 0; i < sir.Length; i++)
            {
                for (int j = i + 1; j < sir.Length; j++)
                {
                    if (comp(sir[j], sir[i]))
                    {
                        object temp = sir[i];
                        sir[i] = sir[j];
                        sir[j] = temp;
                    }
                }
            }
        }
    }
}
