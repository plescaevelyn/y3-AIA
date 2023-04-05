namespace MyFirstClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyFirstClient.ServiceReference1.WebService1SoapClient service = new MyFirstClient.ServiceReference1.WebService1SoapClient();

            int temperatureInF = service.ConvertTemperature(13, 'C');
            Console.WriteLine("{0} Celsius in Fahrenheit is {1}",13, temperatureInF);
            Console.ReadKey();

            string currentTime = service.TimeDisplay();
            Console.WriteLine("The current time is {0}", currentTime);
            Console.ReadKey();

            string list = service.ListDisplay(new List<string> { "one", "two", "three", "four", "five" });
            Console.WriteLine("The elements of the list are {0}", list);
            Console.ReadKey();

            string convertToHUF= service.CurrencyConversion(100);
            Console.WriteLine("{0}RON is equal to {1}HUF", currentTime);
            Console.ReadKey();
        }
    }
}