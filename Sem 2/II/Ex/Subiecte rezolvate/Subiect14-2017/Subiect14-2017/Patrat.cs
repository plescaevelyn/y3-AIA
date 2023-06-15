using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subiect14_2017
{
    [Serializable]
    class Patrat : FiguriGeometrice
    {
        private int _lungimeLatura;
        private string _culoare;

        public int LungimeLatura
        {
            get { return _lungimeLatura; }
            set { _lungimeLatura = value;}
        }

        public string Culoare
        {
            get { return _culoare; }
            set { _culoare = value; }
        }

        public Patrat(int _lungimeLatura)
        {
            this._lungimeLatura = _lungimeLatura;
            this._culoare = "alb";
        }

        public Patrat(int _lungimeLatura, string _culoare)
        {
            this._lungimeLatura = _lungimeLatura;
            this._culoare = _culoare;
        }

        public override int Aria()
        {
            return LungimeLatura ^ 2;
        }

        public override int Perim()
        {
            return 4 * LungimeLatura;
        }

        public override string ToString()
        {
            return "Patrat cu latura de lungimea: " + LungimeLatura + " si culoarea " + Culoare;
        }

        public static bool ComparaAria(object x, object y)
        {
            Patrat patrat1 = (Patrat)x;
            Patrat patrat2 = (Patrat)y;

            return (patrat1.Aria() < patrat2.Aria());
        }

        public static bool ComparaPerim(object x, object y)
        {
            Patrat patrat1 = (Patrat)x;
            Patrat patrat2 = (Patrat)y;

            return (patrat1.Perim() < patrat2.Perim());
        }
    }
}
