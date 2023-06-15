using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sortare
{
    class SirdeSiruri
    {
        public string[] siruri = new string[10];

        public SirdeSiruri(string a, string b, string c, string d, string e, string f, string g, string h, string i, string j)
        {
            siruri[0] = a;
            siruri[1] = b;
            siruri[2] = c;
            siruri[3] = d;
            siruri[4] = e;
            siruri[5] = f;
            siruri[6] = g;
            siruri[7] = h;
            siruri[8] = i;
            siruri[9] = j;
            
        }

        public void Afis()
        {
            for (int i = 0; i < siruri.Length; i++)
                Console.WriteLine(siruri[i]);

        }

       
    }
}
