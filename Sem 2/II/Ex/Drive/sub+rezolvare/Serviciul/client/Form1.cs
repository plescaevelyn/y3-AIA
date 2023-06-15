using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ds = @"Data Source=Beny-PC\SQLEXPRESS";
            string db = "Initial Catalog=";
            string ins = "Integrated Security=True";
            string nume = "Companie";

            SqlConnection cursCon = new SqlConnection(@ds + ";" + db + ";" + ins);
            SqlCommand cursCom1 = cursCon.CreateCommand();
            String command = "CREATE DATABASE " + nume;
            try
            {
                cursCon.Open();
                cursCom1.CommandText = command;
                cursCom1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                cursCon.ChangeDatabase(nume);
                command = "CREATE TABLE [dbo].[Proiect]([ProiectID] [int] PRIMARY KEY,[NumeProiect] [text] NOT NULL,[Buget] [int] NOT NULL)";
                cursCom1.CommandText = command;
                cursCom1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                command = "CREATE TABLE [dbo].[Echipa]([EchipaID] [int] PRIMARY KEY,[ProiectID] [int] NOT NULL)";
                cursCom1.CommandText = command;
                cursCom1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                command = "ALTER TABLE [dbo].[Proiect] ADD CONSTRAINT [FK_ProiectID_ProiectID] FOREIGN KEY([ProiectID]) REFERENCES [dbo].[Echipa]([ProiectID])";
                cursCom1.CommandText = command;
                cursCom1.ExecuteNonQuery();
                cursCon.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                MessageBox.Show("Baza de date a fost creata cu succes  !");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            SqlConnection sqlCon = new SqlConnection(@"Data Source=Data Source=Beny-PC\SQLEXPRESS;Server=Beny-PC\SQLEXPRESS;Database=Companie;Integrated Security=True");
            try
            {
                sqlCon.Open();

                DataSet dsAfisare = new DataSet();

                SqlDataAdapter daAfisare = new SqlDataAdapter("Select * FROM Proiect", sqlCon);
                daAfisare.Fill(dsAfisare, "tabel");
                int id = 0;
                int contor = 0;
                int signal = 0;
                foreach (DataRow row in dsAfisare.Tables[0].Rows)
                {
                    id++;
                    contor++;
                    int buget = int.Parse(row.ItemArray.GetValue(2).ToString());
                    if (buget == 1000)
                        signal++;
                    if (buget < 1000)
                        buget += 100;

                    if (contor == signal)
                    {
                        label1.Text = "Gata am terminat !";
                    }

                    SqlCommand update = new SqlCommand("UPDATE Proiect SET Buget=" + buget + " WHERE ProiectID=" + id, sqlCon);
                    update.ExecuteNonQuery();

                    DataTable dat = new DataTable();
                    SqlDataAdapter daAfisare1 = new SqlDataAdapter("Select * FROM Proiect", sqlCon);
                    daAfisare1.Fill(dat);
                    dataGridView1.DataSource = dat;

                }




            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlCon.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Client.localhost.Service1 c = new Client.localhost.Service1();
            textBox1.Text = Convert.ToString(c.Proiecte());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Client.localhost.Service1 c = new Client.localhost.Service1();
            textBox2.Text = Convert.ToString(c.Bugettotal());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
