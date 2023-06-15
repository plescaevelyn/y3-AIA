using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubiectPersoaneStiva
{
    class Coada
    {
        public const int MaxSize = 10;
        public Student[] items = new Student[MaxSize];
        public int currentIndex = -1;

        public Coada() { }

        public bool IsEmpty()
        {
            if (currentIndex < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Push(Student item)
        {
            if (currentIndex >= MaxSize - 1)
            {
                throw new InvalidOperationException("Coada este plina!");
            }
            
            currentIndex++;
            for (int i = currentIndex; i > 0; i--)
            {
                items[i] = items[i - 1];
            }

            items[0] = item;
        }

        public string Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Coada este goala!");

            Student item = items[currentIndex];

            items[currentIndex] = null;
            currentIndex--;
            return item.ToString();
        }
    }
}
