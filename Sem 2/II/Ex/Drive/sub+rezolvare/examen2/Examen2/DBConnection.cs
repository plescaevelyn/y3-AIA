using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen2
{
    class DBConnection
    {
        public SqlConnection connection = null;
        public DBConnection()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=CSONGOR-PC\\SQLEXPRESS;Initial Catalog=;Integrated Security=True";
                con.Open();
                this.connection = con;
            }
            catch (Exception e)
            {
                MessageBox.Show("Cannot open the sql connection: " + e.Message.ToString());
            }
        }


    }
}
