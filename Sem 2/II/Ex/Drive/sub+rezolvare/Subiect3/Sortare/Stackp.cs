using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sortare
{
    public class Stackp
    {
       public const int MaxSize = 10;
       public string[] items = new string[MaxSize];
       public int currentIndex = -1;

        public Stackp()
        { }

        public bool IsEmpty()
        {
            if (currentIndex < 0)
                return true;
            else
                return false;

        }

        public void Push(string item)
        {
            if (currentIndex >= MaxSize - 1)
                throw new InvalidOperationException("Stack is full!");

            currentIndex++;
            items[currentIndex] = item;
        }

        public string Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty!");

            string item = items[currentIndex];
            items[currentIndex] = null;
            currentIndex--;

            return item;


        }

    }
}
