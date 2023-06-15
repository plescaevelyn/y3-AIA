using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamenII
{
    class Persoane
    {
        private string _nume;
        protected string _prenume;
        internal string _sex;
        public int _varsta;

        public string nume
        {
            get { return _nume; }
            set { _nume = value; }
        }

        public string prenume
        {
            get { return _prenume; }
            set { _prenume = value; }
        }

        public string sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        public int varsta
        {
            get { return _varsta; }
            set { _varsta = value; }
        }
    }
}
