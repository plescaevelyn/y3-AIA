using System.Data;
using System.Data.SqlClient;

namespace Example
{
    public partial class Form1 : Form
    {
        SqlConnection myCon = new SqlConnection();
        DataSet dsUniv;
        DataSet dsFac;
        public Form1()
        {
            InitializeComponent();

            myCon.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\y3AIA\\Sem 2\\II\\Lab 3\\Example\\Example\\Database1.mdf;Integrated Security=True";
            myCon.Open();

            dsUniv = new DataSet();
            dsFac = new DataSet();
            SqlDataAdapter daUniv = new SqlDataAdapter("SELECT * FROM Universitati", myCon);
            daUniv.Fill(dsUniv, "Universitati");
            SqlDataAdapter daFac = new SqlDataAdapter("SELECT * FROM Facultati", myCon);
            daFac.Fill(dsFac, "Facultati");

            foreach (DataRow dr in dsUniv.Tables["Universitati"].Rows)
            {
                String name = dr.ItemArray.GetValue(1).ToString();
                listBox_Univ.Items.Add(name);
            }

            myCon.Close();
        }

        private void listBox_Univ_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_Fac.Items.Clear();
            textBox_City.Clear();

            int code = 0;
            String UnivSelected = listBox_Univ.SelectedItem.ToString();

            foreach (DataRow dr in dsUniv.Tables["Universitati"].Rows)
            {
                if (UnivSelected == dr.ItemArray.GetValue(1).ToString())
                {
                    textBox_City.Text = dr.ItemArray.GetValue(2).ToString();
                    code = Convert.ToInt16(dr.ItemArray.GetValue(3));
                    textBox_CodeUniv.Text = code.ToString();
                }
            }

            foreach (DataRow dr in dsFac.Tables["Facultati"].Rows)
            {
                if (code == Convert.ToInt16(dr.ItemArray.GetValue(1)))
                {
                    String nameFac = dr.ItemArray.GetValue(2).ToString();
                    listBox_Fac.Items.Add(nameFac);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox_Univ.Items.Add(textBox1.Text);
            textBox1.Text = "";
            textBox1.Focus();
            //this.dsUniv.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox_Univ.SelectedIndex != -1)
            {
                String UnivSelected = listBox_Univ.SelectedItem.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox_Univ.SelectedIndex != -1)
            {
                listBox_Univ.Items.RemoveAt(listBox_Univ.SelectedIndex);
            }
        }
    }
}