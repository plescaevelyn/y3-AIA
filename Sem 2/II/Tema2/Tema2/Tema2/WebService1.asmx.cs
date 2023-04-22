using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Tema2
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        string connectionData = @"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\Facultate\\y3-AIA\\Sem 2\\II\\Tema2\\Tema2Client\\Tema2Client\\Database1.mdf;Integrated Security=True";
    
        [WebMethod(Description = "A function that retrieves data from the database.")]
        public string Get()
        {
            return null;
        }

        [WebMethod(Description = "A function that puts data into the database.")]
        public int Post(int id, string song_name, string song_type, string artist, string album)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(connectionData))
            {
                SqlCommand command = new SqlCommand("INSERT INTO Songs VALUES (@id, @song_name, @song_type, @artist, @album)");

                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@song_name", song_name);
                command.Parameters.AddWithValue("@song_type", song_type);
                command.Parameters.AddWithValue("@artist", artist);
                command.Parameters.AddWithValue("@album", album);
                command.Connection = connection;

                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
                connection.Close();
            }

            return rowsAffected;
        }

        [WebMethod(Description = "A function that updates data.")]
        public void Put(int id, string song_name, string song_type, string artist, string album)
        {
            using (SqlConnection connection = new SqlConnection(connectionData))
            {
                string query = "UPDATE Songs SET song_name = @song_name, song_type = @song_type, "
                    + "artist = @artist, album = @album WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@song_name", song_name);
                command.Parameters.AddWithValue("@song_type", song_type);
                command.Parameters.AddWithValue("@artist", artist);
                command.Parameters.AddWithValue("@album", album);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Following error occured:\t", ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        [WebMethod]
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionData))
            {
                string query = "DELETE FROM Songs WHERE ID = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Following error occured:\t", ex);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
