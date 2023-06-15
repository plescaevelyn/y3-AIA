using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubiectJudete
{
    class Judete
    {
        private int _id;
        private string _denumire;
        private float _suprafata;
        private float _densitatea;

        public int ID { get { return _id; } set { _id = value; } }
        public string Denumire { get { return _denumire; } set { _denumire = value; } }
        public float Suprafata { get { return _suprafata; } set { _suprafata = value; } }
        public float Densitatea { get { return _densitatea; } set { _densitatea = value; } }

        public Judete(int _id, string _denumire, float _suprafata, float _densitatea)
        {
            this._id = _id;
            this._denumire = _denumire;
            this._suprafata = _suprafata;
            this._densitatea = _densitatea;
        }
    }
}
