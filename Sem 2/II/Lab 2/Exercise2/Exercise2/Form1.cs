using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Exercise2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            foreach (var line in File.ReadAllLines("\\..\\y3AIA\\Sem 2\\II\\Lab 2\\Exercise2\\Exercise2\\file.txt"))
            {
                listBox1.Items.Add(line);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add(listBox1.SelectedItem);
            int i = listBox1.SelectedIndex;
            listBox1.Items.RemoveAt(i);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = listBox2.SelectedIndex;
            listBox2.Items.RemoveAt(i);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}