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

namespace Client
{
    public partial class Form1 : Form
    {
      

        public Form1()
        {
            InitializeComponent();
            
        }

     
        private void button1_Click_1(object sender, EventArgs e)
        {
            Client.localhost.Service1 c = new Client.localhost.Service1();
            c.InsertStiva(int.Parse(textBox1.Text));
            textBox1.Clear();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Client.localhost.Service1 c = new Client.localhost.Service1();
           int[] v = c.ShowStiva();
           

           for (int i = 0; i < 50; i++)
           {
               listBox1.Items.Add(v[i].ToString());
           }
           
          
               
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Client.localhost.Service1 c = new Client.localhost.Service1();
            c.DeleteFromStiva();

 
        }
    }
}
