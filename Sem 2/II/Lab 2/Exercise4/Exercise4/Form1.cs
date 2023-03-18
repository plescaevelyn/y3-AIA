namespace Exercise4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBox1.Items.Add("Crasna Moftinu Mic");
            listBox1.Items.Add("Gloria Moftinu Mare");
            listBox1.Items.Add("Recolta Sanislau");
            listBox1.Items.Add("Vulturii Santau");
            listBox1.Items.Add("Cetate Ardud");
            listBox1.Items.Add("Real Andrid");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (listBox1.SelectedItem)
            {
                case "Crasna Moftinu Mic":
                    Image image =
                    panel1.BackgroundImage = Image.FromFile("E:\\y3AIA\\Sem 2\\II\\Lab 2\\Exercise4\\Exercise4\\footbal_team_logos\\moftinu_mic.jpg");
                    break;
                case "Gloria Moftinu Mare":
                    panel1.BackgroundImage = Image.FromFile("E:\\y3AIA\\Sem 2\\II\\Lab 2\\Exercise4\\Exercise4\\footbal_team_logos\\moftinu_mare.jpg");
                    break;
                case "Recolta Sanislau":
                    panel1.BackgroundImage = Image.FromFile("E:\\y3AIA\\Sem 2\\II\\Lab 2\\Exercise4\\Exercise4\\footbal_team_logos\\sanislau.png");
                    break;
                case "Vulturii Santau":
                    panel1.BackgroundImage = Image.FromFile("E:\\y3AIA\\Sem 2\\II\\Lab 2\\Exercise4\\Exercise4\\footbal_team_logos\\santau.png");
                    break;
                case "Cetate Ardud":
                    panel1.BackgroundImage = Image.FromFile("E:\\y3AIA\\Sem 2\\II\\Lab 2\\Exercise4\\Exercise4\\footbal_team_logos\\ardud.jpg");
                    break;
                case "Real Andrid":
                    panel1.BackgroundImage = Image.FromFile("E:\\y3AIA\\Sem 2\\II\\Lab 2\\Exercise4\\Exercise4\\footbal_team_logos\\andrid.jpg");
                    break;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}