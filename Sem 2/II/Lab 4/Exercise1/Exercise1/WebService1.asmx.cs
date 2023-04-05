using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Exercise1_Service
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod(Description = "Converts temperature from C to F or vice versa based on chosen mode.")]
        public int ConvertTemperature(int initialTemperature, char temperatureConversionMode)
        {
            switch (temperatureConversionMode)
            {
                case 'C':
                    return initialTemperature * 9 / 5 + 32;
                case 'F':
                    return (initialTemperature - 32) * 5 / 9;
            }

            return -40;
        }

        [WebMethod(Description = "Returns current time.")]
        public string TimeDisplay()
        {
            return DateTime.Now.ToString("h:mm:ss tt");
        }

        [WebMethod(Description = "Returns a list of 5 elements.")]
        public string ListDisplay(List<string> list)
        {
            string elements = "";
            foreach (string element in list)
            {
                elements += (element + "\t");
            }

            return elements;
        }

        [WebMethod(Description = "Converts currency in RON to currency in HUF.")] 
        public string CurrencyConversion(float ronAmount) 
        {
            return (ronAmount * (float)61.2796).ToString();
        }
    }
}
