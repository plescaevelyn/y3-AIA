using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        public static System.Windows.Forms.Timer t1 = new System.Windows.Forms.Timer();

        public static Dreptunghi[] list;
        public static int counter = 0;

        public Form1()
        {
            InitializeComponent();
            button1.Visible = false;
            button2.Visible = false;
            listBox1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            list = new Dreptunghi[10];
            for(int i = 0; i<10;i++)
            {
                if (i % 2 == 0)
                    list[i] = new Dreptunghi(i);
                else
                    list[i] = new Dreptunghi(i, i + 1);
            }
            t.Tick += new EventHandler(show);
            t.Interval = 1000;
            t.Start();
            
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
                t.Stop();
        }
        private void show1(Object myObject, EventArgs myEventArgs)
        {
           if(counter<10)
            {
                list = sortDreptunghiPerim(list);
                String s = "2*(" + list[counter].l1.ToString() + "+" + list[counter].l2.ToString() + ")=" + list[counter].Perim().ToString();
                listBox1.Items.Add(s);
            }

            else
            {
                list = sortDreptunghiAria(list);
                String ss = list[counter-10].l1.ToString() + "*" + list[counter-10].l2.ToString() + "=" + list[counter-10].Aria();
                listBox1.Items.Add(ss);
            }
            counter++;
                
            if(counter == 20)
                t1.Stop();
        }
        Dreptunghi[] sortDreptunghiAria(Dreptunghi[] d)
        {
            for (int i = 0; i < d.Length - 1; i++)
                for (int j = i + 1; j < d.Length; j++)
                {
                    if (d[i].Aria()< d[i].Aria())
                    {
                        Dreptunghi aux = d[i];
                        d[i] = d[j];
                        d[j] = aux;
                    }
                }
            return d;
        }
        Dreptunghi[] sortDreptunghiPerim(Dreptunghi[] d)
        {
            for (int i = 0; i < d.Length - 1; i++)
                for (int j = i + 1; j < d.Length; j++)
                {
                    if (d[i].Perim() > d[i].Perim())
                    {
                        Dreptunghi aux = d[i];
                        d[i] = d[j];
                        d[j] = aux;
                    }
                }
            return d;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("DataFile.dat", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, list);
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
                list = (Dreptunghi[])formatter.Deserialize(fs);
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

            t1.Tick += new EventHandler(show1);
            t1.Interval = 1000;
            t1.Start();
        }
    }
    [Serializable]
    public abstract class FiguriGeometrice
    {
        public abstract int Aria();
        public abstract int Perim();
    }
    [Serializable]
    public class Dreptunghi:FiguriGeometrice
    {
        public int l1, l2;
        public Dreptunghi(int l1)
        {
            this.l1 = l1;
            this.l2 = l2;
        }
        public Dreptunghi(int l1, int l2)
        {
            this.l1 = l1;
            this.l2 = l2;
        }
        // overriding
        public override int Aria() => l1 * l2;

        // overriding
        public override int Perim() => 2*(l1 + l2);

    }
}
