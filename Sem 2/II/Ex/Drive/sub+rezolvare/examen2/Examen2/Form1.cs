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

namespace Examen2
{
    public partial class Form1 : Form
    {
        Baza st;
        Timer timer = new Timer();
        Timer timer2 = new Timer();
        DBConnection dbcon = null;

        public Form1()
        {
            InitializeComponent();
            st = new Stiva();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (st.returnNrElemente() == 9)
                timer.Stop();

            st.PUSH((int)new Random().Next(1, 100));
            // MessageBox.Show(st.returnNrElemente().ToString());
            refreshListbox();

        }

        void refreshListbox()
        {
            List<string> x = st.returnAsList();
            x.Reverse();
            
            listBox1.DataSource = x;
            //listBox1.Refresh();
        }

        void refreshListbox2()
        {
            string query = "select val from elements order by val";
            SqlCommand cmd = new SqlCommand(query,dbcon.connection);
            SqlDataReader reader = cmd.ExecuteReader();

            List<string> x = new List<string>();

            while (reader.Read())
            {
                x.Add(reader[0].ToString());
            }
            reader.Close();
            listBox2.DataSource = x;
            //listBox2.Refresh();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            timer2.Tick += new EventHandler(timer_Tick2);
            timer2.Interval = 1000;
            timer2.Enabled = true;
            timer2.Start();
        }
        void timer_Tick2(object sender, EventArgs e)
        {
            int x = st.POP();
            if (x == 0)
            {
                timer2.Stop();
                st = null;
                refreshListbox();
            }
            else
            {

                string query = "insert into elements (val) values(@val)";
                SqlCommand cmd = new SqlCommand(query, dbcon.connection);
                cmd.Parameters.Add("@val", SqlDbType.Int).Value = x;

                try
                {
                    cmd.ExecuteNonQuery();
                    refreshListbox2();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }

            }  
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dbcon = new DBConnection();
            if (dbcon.connection != null)
            {
                String query = "CREATE DATABASE " + textBox1.Text.Trim();
                SqlCommand cmd = new SqlCommand(query, dbcon.connection);
                try
                {
                    cmd.ExecuteNonQuery();
                    dbcon.connection.ChangeDatabase(textBox1.Text.Trim());
                    MessageBox.Show("Database " + textBox1.Text.Trim() + " has created!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                try
                {
                    query = "CREATE TABLE [dbo].[elements]([id] [int] PRIMARY KEY IDENTITY,[val] [int] NOT NULL)";
                    cmd = new SqlCommand(query, dbcon.connection);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }



        }
    }
}
