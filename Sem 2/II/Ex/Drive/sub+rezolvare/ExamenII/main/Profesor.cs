using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamenII
{
    class Profesor:Persoane
    {
        private string _pozitie;

        public string pozitie
        {
            get { return _pozitie; }
            set { _pozitie = value; }
        }

             public Profesor()
        {
            this.nume = "Nume";
            this.prenume = "Pnume";
            this.sex = "Gen";
            this.varsta = 32;
            this.pozitie = "pozitie";

        }

         public Profesor(string _fname, string _lname, string _gender, int _age, string _position)
        {
            this.nume = _fname;
            this.prenume = _lname;
            this.sex = _gender;
            this.varsta = _age;
            this.pozitie = _position;
        }
    }
}
