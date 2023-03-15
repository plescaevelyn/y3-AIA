using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_4
{
    internal class IdealWeight
    {
        float height, age;
        char gender;

        public IdealWeight(char gender, float height, float age)
        {
            this.gender = gender;
            this.height = height;   
            this.age = age; 
        }

        float calculateIdealWeightF(float height, float age)
        {
            return height - 100 - ((height - 150) / 4) + (age - 20) / 4;
        }

        float calculateIdealWeightM(float height, float age)
        {
            return (float)(height - 100.0 - ((height - 150) / 2.5) + (age - 20.0) / 6.0);
        }

        public void displayIdealWeight(char gender, float height, float age)
        {
            float idealWeight;
            switch (gender)
            {
                case 'm':
                    idealWeight = calculateIdealWeightM(height, age);
                    Console.WriteLine("The ideal weight for a male with the height {0} and age {1} is: {2}", height, age, idealWeight);
                    break;
                case 'f':
                    idealWeight = calculateIdealWeightF(height, age);
                    Console.WriteLine("The ideal weight for a female with the height {0} and age {1} is: {2}", height, age, idealWeight);
                    break;
                final:
                    Console.WriteLine("Unrecognised gender, cannot calculate the ideal weight.");
            }
        }
    }
}
