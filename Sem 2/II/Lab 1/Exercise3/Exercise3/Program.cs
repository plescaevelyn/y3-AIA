// See https://aka.ms/new-console-template for more information

using System;

namespace Exercise3 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your initial temperature in: Celsius or Fahrenheit? [C/F]");
            char initialTemperature = Console.ReadLine()[0];

            float temperatureC, temperatureF;

            Console.WriteLine("Give the temperature.\t");
            switch(initialTemperature)
            {
                case 'C':
                    temperatureC = int.Parse(Console.ReadLine());   
                    temperatureF = TemperatureConverter.convertFromCelsiusToFahrenheit(temperatureC);
                    TemperatureConverter temperatureConverter = new TemperatureConverter(initialTemperature, temperatureC, temperatureF);
                    temperatureConverter.displayTemperatures(temperatureC, temperatureF);
                    break;
                case 'F':
                    temperatureF = int.Parse(Console.ReadLine());
                    temperatureC = TemperatureConverter.convertFromFahrenheitToCelsius(temperatureF);
                    TemperatureConverter temperatureConverter1 = new TemperatureConverter(initialTemperature, temperatureC, temperatureF);
                    temperatureConverter1.displayTemperatures(temperatureC, temperatureF);
                    break;
            }
        }
    }
}