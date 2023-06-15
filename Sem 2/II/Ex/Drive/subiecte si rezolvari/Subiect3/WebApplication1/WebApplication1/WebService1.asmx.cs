using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Description = "", Name = "SortingService", Namespace = "SortingService")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public String Sort(String s)
        {
            char[] characters = s.ToArray();
            Array.Sort(characters);
            return new String(characters);

        }
        [WebMethod]
        public void creareDB()
        {
            string ds = @"Data Source=DESKTOP-MS1J7EF\SQLEXPRESS";
            string db = "Initial Catalog= ";
            string ins = "Integrated Security=True";
            SqlConnection myCon = new SqlConnection(@ds + ";" + db + ";" + ins);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myCon;
            cmd.CommandText = "CREATE DATABASE Strings";
            try
            {
                myCon.Open();
                cmd.ExecuteNonQuery();
                myCon.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }
        [WebMethod]
        public void creareTabel()
        {
            string ds = @"Data Source=DESKTOP-MS1J7EF\SQLEXPRESS";
            string db = "Initial Catalog=Strings";
            string ins = "Integrated Security=True";
            SqlConnection myCon = new SqlConnection(@ds + ";" + db + ";" + ins);
            try
            {
                myCon.Open();
                SqlCommand com = new SqlCommand();
                com.Connection = myCon;
                com.CommandText = "CREATE TABLE[dbo].[Siruri]([Sir] CHAR(20) NOT NULL, [ID] INT NULL)";
                com.ExecuteNonQuery();
                myCon.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }

        }
        [WebMethod]
        public void insertInDB(String s)
        {
            
            creareDB();
            creareTabel();
            string ds = @"Data Source=DESKTOP-MS1J7EF\SQLEXPRESS";
            string db = "Initial Catalog=Strings";
            string ins = "Integrated Security=True";
            SqlConnection myCon = new SqlConnection(@ds + ";" + db + ";" + ins);
            try
            {
                myCon.Open();
                SqlCommand com = new SqlCommand();
                com.Connection = myCon;
                com.CommandText = "INSERT INTO Siruri (Sir) VALUES (@s)";
                com.Parameters.AddWithValue("@s", s);
                com.ExecuteNonQuery();
                myCon.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }
    }
}
