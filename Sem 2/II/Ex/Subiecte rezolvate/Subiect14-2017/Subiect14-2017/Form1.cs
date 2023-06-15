using System.Runtime.Serialization.Formatters.Binary;
using System.Timers;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace Subiect14_2017
{
    public partial class Form1 : Form
    {
        static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        static System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        static Patrat[] patrate;
        static int counter = 0;
        
        /* static Patrat[] patrate =
        {
                new Patrat(1, "rosu"),
                new Patrat(2, "galben"),
                new Patrat(3, "albastru"),
                new Patrat(4, "rosu"),
                new Patrat(5, "alb"),
                new Patrat(6, "verde"),
                new Patrat(),
                new Patrat(),
                new Patrat(9, "negru"),
                new Patrat(10, "roz")
        }; */

        public Form1()
        {
            InitializeComponent();
            button1.Visible = false;
            button2.Visible = false;
            listBox1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            patrate = new Patrat[10];
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                    patrate[i] = new Patrat(i);
                else
                    patrate[i] = new Patrat(i + 1);
            }

            timer.Tick += new EventHandler(show);
            timer.Interval = 1000;
            timer.Start();
        }

        private void show(Object myObject, EventArgs myEventArgs)
        {
            if (button1.Visible == false)
            {
                button1.Visible = true;
            }
            else if (button2.Visible == false)
            {
                button2.Visible = true;
            }
            else if (listBox1.Visible == false)
            {
                listBox1.Visible = true;
            }
            else
            {
                timer.Stop();
            }
        }

        private void show1(Object myObject, EventArgs myEventArgs)
        {
            if (counter < 10)
            {
                Sortare.Sort(patrate, Patrat.ComparaPerim);
                foreach (Patrat patrat in patrate)
                {
                    listBox1.Items.Add(patrat.ToString);
                }
            }
            else
            {
                Sortare.Sort(patrate, Patrat.ComparaAria);
                foreach (Patrat patrat in patrate)
                {
                    listBox1.Items.Add(patrat.ToString);
                }
            }
            counter++;

            if (counter == 20)
            {
                timer1.Stop();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("DataFile.dat", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, patrate);
            }
            catch (SerializationException xe)
            {
                Console.WriteLine("Failed to serialize. Reason: " + xe.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("DataFile.dat", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and 
                // assign the reference to the local variable.
                patrate = (Patrat[])formatter.Deserialize(fs);
            }
            catch (SerializationException xe)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + xe.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }

            timer1.Tick += new EventHandler(show1);
            timer1.Interval = 1000;
            timer1.Start();
        }
    }
}