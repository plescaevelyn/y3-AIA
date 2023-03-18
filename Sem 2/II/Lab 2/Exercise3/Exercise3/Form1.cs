namespace Exercise3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, EventArgs e)
        {
            try
            {
                toolStripTextBox3.Text = (int.Parse(this.toolStripTextBox1.Text) + int.Parse(this.toolStripTextBox2.Text)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void substract_Click(object sender, EventArgs e)
        {
            try
            {
                toolStripTextBox3.Text = (int.Parse(this.toolStripTextBox1.Text) - int.Parse(this.toolStripTextBox2.Text)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void multiply_Click(object sender, EventArgs e)
        {
            try
            {
                toolStripTextBox3.Text = (int.Parse(this.toolStripTextBox1.Text) * int.Parse(this.toolStripTextBox2.Text)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void divide_Click(object sender, EventArgs e)
        {
            try
            {
                toolStripTextBox3.Text = (int.Parse(this.toolStripTextBox1.Text) / int.Parse(this.toolStripTextBox2.Text)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}