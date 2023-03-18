using System.Windows.Forms;

namespace Exercise1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = File.ReadLines("\\..\\y3AIA\\Sem 2\\II\\Lab 2\\Exercise1\\Exercise1\\file.txt").First();
            string password = File.ReadAllLines("\\..\\y3AIA\\Sem 2\\II\\Lab 2\\Exercise1\\Exercise1\\file.txt").ElementAtOrDefault(1);

            if (textBox1.Text.Equals(username) && textBox2.Text.Equals(password))
            {
                Form2 form2 = new Form2();
                form2.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}