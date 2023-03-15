// See https://aka.ms/new-console-template for more information
/*
 * Cititi doua numere reale de la tastatura si apoi, utilizand operatorii binari +,-,/,*, sa se execute cateva calcule
 * Sa se creeze o clasa care sa contine metode pentru operatiile matematice cat si o metoda pentru afisare
 */

using System.Globalization;

namespace Exercise2
{
    class Operations
    {
        private int firstNumber;
        private int secondNumber;

        public Operations(int firstNumber, int secondNumber)
        {
            this.firstNumber = firstNumber;
            this.secondNumber = secondNumber;
        }

        // setter methods
        public void setFirstNumber(int firstNumber)
        {
            this.firstNumber = firstNumber;
        }
        public void setSecondNumber(int secondNumber)
        {
            this.secondNumber = secondNumber;
        }

        // getter methods
        public int getFirstNumber() { return firstNumber; }
        public int getSecondNumber() { return secondNumber; }

        // method used for adding two numbers
        public int addNumbers(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }

        // method used for substracting two numbers
        // the second number given as a parameter to the method is substracted from the first one
        public int substractNumbers(int firstNumber, int secondNumber)
        {
            return firstNumber - secondNumber;
        }

        // method used for multiplying two numbers
        public int multiplyNumbers(int firstNumber, int secondNumber)
        {
            return (firstNumber * secondNumber);
        }

        // method used for dividing two numbers
        // the second number given as a parameter to the method is divided from the first one
        public float divideNumbers(int firstNumber, int secondNumber)
        {
            return firstNumber / secondNumber;
        }

        // method used for displaying the initial numbers and the results of the operations applied to them
        public void displayNumbersAndOperations(Operations numbers)
        {
            int firstNumber = numbers.getFirstNumber();
            int secondNumber = numbers.getSecondNumber();

            Console.WriteLine(firstNumber + "\t" + secondNumber);
            Console.WriteLine("The result of adding the two numbers:\t{0}" +
                              "The result of substracting the two numbers:\t{1}" +
                              "The result of multiplying the two numbers:\t{2}" +
                              "The result of dividing the two numbers:\t{3}",
                              addNumbers(firstNumber, secondNumber), substractNumbers(firstNumber, secondNumber), multiplyNumbers(firstNumber, secondNumber), divideNumbers(firstNumber, secondNumber));
        }
    }
}