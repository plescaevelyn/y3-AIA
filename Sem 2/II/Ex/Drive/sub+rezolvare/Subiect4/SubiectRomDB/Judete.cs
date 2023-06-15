using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubiectRomDB
{
    class Judete
    {
        private int _id;
        private string _denumire;
        private int _suprafata;

        public Judete(int id, string den, int supr)
        {
            _id = id;
            _denumire = den;
            _suprafata = supr;

        }

        public int id
        {
            get
           {
            return _id;
           }
        }

        public string denumire
        {
            get
            {
                return _denumire;
            }

        }

        public int suprafata
        {
            get
            {
                return _suprafata;
            }

        }

    }
}
