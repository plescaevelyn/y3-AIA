using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;

namespace Serviciul
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
        SqlConnection c = new SqlConnection(@"Data Source=BENY-PC\SQLEXPRESS;Initial Catalog=Companie;Integrated Security=True");

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Proiecte()
        {
            DataSet dsE = new DataSet();
            int k = 0;
            dsE.Clear();
            c.Open();
            SqlDataAdapter d1 = new SqlDataAdapter("select * from Proiect", c);

            d1.Fill(dsE, "Proiect");

            foreach (DataRow dr in dsE.Tables["Proiect"].Rows)
            {

                string name = dr.ItemArray.GetValue(1).ToString();

                k = k + 1;

            }

            return k;
        }

        [WebMethod]
        public int Bugettotal()
        {
            DataSet dsE = new DataSet();
            int k = 0;
            int bug = 0;
            int bugT = 0;
            dsE.Clear();
            c.Open();
            SqlDataAdapter d1 = new SqlDataAdapter("select * from Proiect", c);

            d1.Fill(dsE, "Proiect");

            foreach (DataRow dr in dsE.Tables["Proiect"].Rows)
            {

                  bug = int.Parse(dr.ItemArray.GetValue(2).ToString());
                  bugT = bugT + bug;
                 //bug = bug + 100;

            }

           

            return bugT;
        }
    }
}