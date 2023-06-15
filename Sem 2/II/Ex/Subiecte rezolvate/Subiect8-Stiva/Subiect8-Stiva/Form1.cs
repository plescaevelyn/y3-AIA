using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Subiect8_Stiva
{
    public partial class Form1 : Form
    {
        public static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        public static System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        public Coada c;
        public int cnt = 0;

        public Form1()
        {
            InitializeComponent();
            c = new Coada();
            creareDB();
            creareTabel();

            timer.Tick += new EventHandler(addElem);
            timer.Interval = 10;
            timer.Start();
        }

        public static void creareDB()
        {
            SqlConnection myCon = new SqlConnection("Data Source=DESKTOP-LAR6UOC\\TEW_SQLEXPRESS;Initial Catalog=Numere;Integrated Security=true;TrustServerCertificate=True;");

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = myCon;
            cmd.CommandText = "CREATE DATABASE Numere";
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

        public static void creareTabel()
        {
            SqlConnection myCon = new SqlConnection("Data Source=DESKTOP-LAR6UOC\\TEW_SQLEXPRESS;Initial Catalog=Numere;Integrated Security=true;TrustServerCertificate=True;");

            try
            {
                myCon.Open();
                SqlCommand com = new SqlCommand();
                com.Connection = myCon;
                com.CommandText = "CREATE TABLE[dbo].[Num]([ID] INT PRIMARY KEY, [Valoare] INT NOT NULL)";
                com.ExecuteNonQuery();
                myCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public void addElem(Object myObject, EventArgs myEventArgs)
        {
            Random r = new Random();
            int num = r.Next(100);

            SqlConnection myCon = new SqlConnection("Data Source=DESKTOP-LAR6UOC\\TEW_SQLEXPRESS;Initial Catalog=Numere;Integrated Security=true;TrustServerCertificate=True;");

            myCon.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = myCon;

            c.PUSH(num);
            com.CommandText = "INSERT INTO Num (ID, Valoare) VALUES (@id, @i)";
            com.Parameters.AddWithValue("@id", cnt);
            com.Parameters.AddWithValue("@i", num);
            com.ExecuteNonQuery();
            myCon.Close();

            cnt++;
            if (cnt == 30)
            {
                timer.Stop();
                timer.Enabled = false;
                MessageBox.Show("am intrat in noul timer cica");
                cnt = 0;
                timer1.Tick += new EventHandler(afisElem);
                timer1.Interval = 1000;
                timer1.Start();
            }
        }

        public void afisElem(Object myObject, EventArgs myEventArgs)
        {
            SqlConnection myCon = new SqlConnection("Data Source=DESKTOP-LAR6UOC\\TEW_SQLEXPRESS;Initial Catalog=Numere;Integrated Security=true;TrustServerCertificate=True;");

            myCon.Open();

            DataSet dS = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Num ORDER BY Valoare ASC", myCon);
            da.Fill(dS, "val_asc");

            DataSet dS1 = new DataSet();
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT * FROM Num", myCon);
            da1.Fill(dS1, "val");

            listBox1.Items.Add(dS1.Tables["val"].Rows[cnt].ItemArray.GetValue(1));
            listBox2.Items.Add(dS.Tables["val_asc"].Rows[cnt].ItemArray.GetValue(1));

            cnt++;

            if (cnt == 30)
            {
                timer1.Stop();
            }
        }
    }
}