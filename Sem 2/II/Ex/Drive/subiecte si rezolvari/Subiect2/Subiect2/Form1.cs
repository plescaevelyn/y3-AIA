using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Subiect2
{
    public partial class Form1 : Form
    {
        public static System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();


        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            creareDB();
            creareTabele();
            t.Tick += new EventHandler(majorareBuget);
            t.Interval = 2000;
            t.Start();
           
        }

        public static void creareDB()
        {
            string ds = @"Data Source=DESKTOP-LAR6UOC\TEW_SQLEXPRESS";
            string db = "Initial Catalog=Companiei";
            string ins = "Integrated Security=True";
            SqlConnection myCon = new SqlConnection(@ds + ";" + db + ";" + ins);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myCon;
            cmd.CommandText = "CREATE DATABASE Companiei";
            try
            {
                myCon.Open();
                cmd.ExecuteNonQuery();
                myCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void creareTabele()
        {
            string ds = @"Data Source=DESKTOP-LAR6UOC\TEW_SQLEXPRESS";
            string db = "Initial Catalog=Companiei";
            string ins = "Integrated Security=True";

            SqlConnection myCon = new SqlConnection(@ds + ";" + db + ";" + ins);
            
            try
            {
                myCon.Open();
            
                SqlCommand com = new SqlCommand();
                com.Connection = myCon;
                
                com.CommandText = "CREATE TABLE[dbo].[Proiect]([ProiectID] INT PRIMARY KEY,[NumeProiect] CHAR(20) NOT NULL,[Buget] INT NOT NULL)";
                com.ExecuteNonQuery();
                
                com.CommandText = "INSERT INTO Proiect (ProiectID,NumeProiect,Buget) VALUES (1,'Proiect1',100), (2,'Proiect2',200), (3,'Proiect3',300)";
                com.ExecuteNonQuery();
                
                com.CommandText = "CREATE TABLE[dbo].[Echipa]([EchipaID] INT PRIMARY KEY,[ProiectID] INT NOT NULL)";
                com.ExecuteNonQuery();
                
                com.CommandText = "INSERT INTO Echipa (EchipaID,ProiectID) VALUES (1,1), (2,1), (3,2), (4,3)";
                com.ExecuteNonQuery();
                
                myCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

       
        private void majorareBuget(Object myObject, EventArgs myEventArgs)
        {
            string ds = @"Data Source=DESKTOP-MS1J7EF\SQLEXPRESS";
            string db = "Initial Catalog=Companiei";
            string ins = "Integrated Security=True";
            SqlConnection myCon = new SqlConnection(@ds + ";" + db + ";" + ins);
            myCon.Open();
            DataSet dS = new DataSet();
            List<int> bugete = new List<int>();


            bool bugetDepasit = true;
            SqlDataAdapter da = new SqlDataAdapter("SELECT Proiect.Buget,Proiect.NumeProiect FROM Proiect", myCon);
            da.Fill(dS, "val");


            

            foreach (DataRow dr in dS.Tables["val"].Rows)
            {
                if (Convert.ToInt32(dr.ItemArray.GetValue(0)) + 100 <= 1000)
                {
                    SqlCommand com = new SqlCommand();
                    com.Connection = myCon;
                    bugetDepasit = false;
                    string numeProiect = dr.ItemArray.GetValue(1).ToString();
                    int b = Convert.ToInt32(dr.ItemArray.GetValue(0)) + 100;
                    com.CommandText = "UPDATE Proiect SET Buget = @buget WHERE NumeProiect = @numeProiect";
                    com.Parameters.AddWithValue("@buget", b);
                    com.Parameters.AddWithValue("@numeProiect", numeProiect);
                    com.ExecuteNonQuery();
                   // MessageBox.Show(b.ToString());

                }
            }
            label3.Text = dS.Tables["val"].Rows[0].ItemArray.GetValue(1).ToString() + ": " + dS.Tables["val"].Rows[0].ItemArray.GetValue(0).ToString();
            label4.Text = dS.Tables["val"].Rows[0].ItemArray.GetValue(1).ToString() + ": " + dS.Tables["val"].Rows[0].ItemArray.GetValue(0).ToString();

            if (bugetDepasit == true)
            {
                t.Stop();
                label1.Hide();
                label2.Hide();
                label3.Hide();
                label4.Hide();
                label5.Text = "GATA";
            }
            else
            {
                t.Enabled = true;

            }
            myCon.Close();


        }

    }
}
