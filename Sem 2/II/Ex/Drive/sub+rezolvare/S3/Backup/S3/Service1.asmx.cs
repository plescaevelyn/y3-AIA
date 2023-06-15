using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;

namespace S3
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string Sorts(String s)
        {
            char[] sir = s.ToCharArray();
            Array.Sort(sir);

            return new string(sir);
        }

        [WebMethod]
        public void InsertDb(string[] s)
        {
            SqlConnection con = new SqlConnection(@"Data Source=BENY-PC\SQLEXPRESS;Initial Catalog=SirdeSiruri;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                cmd.CommandText = "INSERT INTO Siruri(Sir) VALUES('"+s[i]+"')" ;
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }
    }
}