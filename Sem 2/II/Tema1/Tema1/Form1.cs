namespace Tema1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            listBox1.Items.Add("Software Developer Intern");
            listBox1.Items.Add("Software Tester Intern");
            listBox1.Items.Add("DevOps Intern");
            listBox1.Items.Add("Systems Admin Intern");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}