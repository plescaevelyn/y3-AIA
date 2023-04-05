namespace MyFirstClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyFirstClient.ServiceReference1.WebService1SoapClient service = new MyFirstClient.ServiceReference1.WebService1SoapClient();


            // int sum = service.Add(2, 3);
            // Console.WriteLine("The sum is " + sum.ToString());
            // Console.ReadKey();
        }
    }
}
    