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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form

    {
        public static System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        public static System.Windows.Forms.Timer t1 = new System.Windows.Forms.Timer();
        public Coada c;
        public int cnt = 0;

        public Form1()
        {
            InitializeComponent();
            c = new Coada();
            creareDB();
            creareTabel();

            t.Tick += new EventHandler(addElem);
            t.Interval = 10;
            t.Start();
            
                
                            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
      
        public static void creareDB()
        {
            string ds = @"Data Source=DESKTOP-MS1J7EF\SQLEXPRESS";
            string db = "Initial Catalog= ";
            string ins = "Integrated Security=True";
            SqlConnection myCon = new SqlConnection(@ds + ";" + db + ";" + ins);

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
            string ds = @"Data Source=DESKTOP-MS1J7EF\SQLEXPRESS";
            string db = "Initial Catalog=Numere";
            string ins = "Integrated Security=True";
            SqlConnection myCon = new SqlConnection(@ds + ";" + db + ";" + ins);
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
            string ds = @"Data Source=DESKTOP-MS1J7EF\SQLEXPRESS";
            string db = "Initial Catalog=Numere";
            string ins = "Integrated Security=True";
            SqlConnection myCon = new SqlConnection(@ds + ";" + db + ";" + ins);
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
                t.Stop();
                t.Enabled = false;
                MessageBox.Show("am intrat in noul timer cica");
                cnt = 0;
                t1.Tick += new EventHandler(afisElem);
                t1.Interval = 1000;
                t1.Start();
            }
                
        }

        public void afisElem(Object myObject, EventArgs myEventArgs)
        {
            string ds = @"Data Source=DESKTOP-MS1J7EF\SQLEXPRESS";
            string db = "Initial Catalog=Numere";
            string ins = "Integrated Security=True";
            SqlConnection myCon = new SqlConnection(@ds + ";" + db + ";" + ins);
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
                t1.Stop();

        }
    }
    public class Elem_lista
    {
        private int _val;
        private Elem_lista _urmatorul;
        public Elem_lista(int i)
        {
            _val = i;
            _urmatorul = null;
        }
        public int val
        {
            get
            {
                return _val;
            }
            set
            {
                _val = value;
            }
        }
        public Elem_lista urmatorul
        {
            get
            {
                return _urmatorul;
            }
            set
            {
                _urmatorul = value;
            }
        }
    }
    public abstract class Baza
    {
        public Elem_lista _cap;
        public Elem_lista cap
        {
            get
            {
                return _cap;
            }
            set
            {
                _cap = value;
            }
        }
        public Baza()
        {
            _cap = null;
        }
        public virtual void PUSH(int i)
        {

        }
        public virtual int POP()
        {

            return 0;
        }
        public virtual void Afisez()
        {
            Elem_lista ptr = new Elem_lista(0);
            ptr = _cap;
            if (ptr == null)
                Console.WriteLine(" Structura vida");
            while (ptr != null)
            {
                Console.WriteLine(ptr.val);
                ptr = ptr.urmatorul;
            }
        }
    }
    public class Coada : Baza
    {
        public override void PUSH(int i)
        {
            Elem_lista elem_nou = new Elem_lista(i);
            Elem_lista ptr = new Elem_lista(0);
            if (cap == null)
                cap = elem_nou;
            else
            {
                ptr = cap;
                while (ptr.urmatorul != null)
                    ptr = ptr.urmatorul;
                ptr.urmatorul = elem_nou;
            }
        }
        public override int POP()
        {
            int valret;
            if (cap == null)
            {
                Console.WriteLine("Coada goala");
                return 0;
            }
            valret = cap.val;
            cap = cap.urmatorul;
            return valret;
        }
        public override void Afisez()
        {
            Console.WriteLine("Coada contine");
            base.Afisez();
        }
        public int NrElementeImpare()
        {
            int NrElementeImpare = 0;
            Elem_lista ptr = new Elem_lista(0);
            ptr = _cap;
            if (ptr == null)
                return 0;
            while (ptr != null)
            {
                if (ptr.val % 2 == 1) NrElementeImpare++;
                Console.WriteLine(ptr.val);
                ptr = ptr.urmatorul;
            }
            return NrElementeImpare;
        }
    }


}
