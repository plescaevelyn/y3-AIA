using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubiectJudete
{
    internal class Localitati
    {
        private int _id;
        private string _denumire;
        private float _latitudine;
        private float _longitudine;
        private int _judete_fk;
        private float _suprafata;
        private float _densitate;
    
        public int Id { get { return _id; } set { _id = value; } }
        public string Denumire { get { return _denumire; } set { _denumire = value; } }
        public float Latitudine { get {  return _latitudine; } set { _latitudine = value; } }
        public float Longitudine { get { return _longitudine; } set { _longitudine = value; } }
        public int Judete_FK { get {  return _judete_fk; } }
        public float Suprafata { get { return _suprafata; } set { _suprafata = value; } }
        public float Densitate { get { return _densitate; } set { _densitate = value; } }

        public Localitati(int _id,  string _denumire, float _latitudine, float _longitudine, int _judete_fk, float _suprafata, float _densitate)
        {
            this._id = _id;
            this._denumire = _denumire;
            this._latitudine = _latitudine;
            this._longitudine = _longitudine;
            this._judete_fk = _judete_fk;
            this._suprafata = _suprafata;
            this._densitate = _densitate;
        }
    }
}
