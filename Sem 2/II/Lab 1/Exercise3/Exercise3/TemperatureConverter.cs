using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    internal class TemperatureConverter
    {
        float temperatureInCelsius;
        float temperatureInFahrenheit;
        char initialTempGivenIn;

        public TemperatureConverter(char initialTempGivenIn, float temperatureInCelsius, float temperatureInFahrenheit) {
            this.initialTempGivenIn = initialTempGivenIn;
            this.temperatureInCelsius = temperatureInCelsius;
            this.temperatureInFahrenheit = convertFromCelsiusToFahrenheit(temperatureInCelsius);
        }

        public static float convertFromCelsiusToFahrenheit(float temperatureInCelsius)
        {
            return temperatureInCelsius * 9 / 5 + 32;
        }
        public static float convertFromFahrenheitToCelsius(float temperatureInFahrenheit) { 
            return (temperatureInFahrenheit - 32) * 5 / 9;
        }

        public void displayTemperatures(float temperatureInCelsius, float temperatureInFahrenheit)
        {
            Console.WriteLine("Today's temperatures are:\n\t{0}°C\t\t\t{1}°F", temperatureInCelsius, temperatureInFahrenheit);
        }
    }
}
