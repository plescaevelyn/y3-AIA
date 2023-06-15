using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubiectRomDB
{
    class Localitati
    {
        private int _id;
        private string _denumire;
        private int _Judete_FK;

        public Localitati(int id, string denumire, int Judete_FK)
        {
            _id = id;
            _denumire = denumire;
            _Judete_FK = Judete_FK; 

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

        public int Judete_FK
        {
            get
            {
                return _Judete_FK;
            }
        }



    }
}
