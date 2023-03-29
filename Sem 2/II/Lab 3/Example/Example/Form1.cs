using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Example
{
    public partial class Form1 : Form
    {
        SqlConnection myCon = new SqlConnection();
        DataTable dataTable = new DataTable();
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

            dataGridView1.DataSource = dsFac.Tables["Facultati"].DefaultView;

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

            if (listBox_Univ.SelectedItem != null)
            {
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myCon.Open();

            string name = textBox_Nume.Text;
            string id = textBox_id.Text;
            string code = textBox_cod.Text;
            string city = textBox_oras.Text;

            if (name == "" || id == "" || code == "" || city == "")
            {
                MessageBox.Show("Fill in all the data!");
                return;
            }

            string insertQuery = "INSERT INTO Universitati (Id, NameUniv, City, Code) VALUES (@id, @name, @city, @code)";

            SqlCommand cmd = new SqlCommand(insertQuery, myCon);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
            }

            myCon.Close();

            dsUniv.Clear();
            SqlDataAdapter daUniv = new SqlDataAdapter("SELECT * FROM Universitati", myCon);
            daUniv.Fill(dsUniv, "Universitati");

            string numeUniv = textBox_Nume.Text;
            listBox_Univ.Items.Add(numeUniv);

            MessageBox.Show("New university added succesfully!");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox_Univ.SelectedIndex != -1)
            {
                myCon.Open();

                string id = textBox_id.Text;
                string name = textBox_Nume.Text;

                if (name == "")
                {
                    MessageBox.Show("Fill in all the data!");
                    return;
                }

                string updateQuery = "UPDATE Universitati (Id, NameUniv, City, Code) SET NameUniv = @name WHERE Id = '" + @id + "'";

                SqlCommand cmd = new SqlCommand(updateQuery, myCon);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                }

                myCon.Close();

                dsUniv.Clear();
                SqlDataAdapter daUniv = new SqlDataAdapter("SELECT * FROM Universitati", myCon);
                daUniv.Fill(dsUniv, "Universitati");

                MessageBox.Show("University updated succesfully!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox_Univ.SelectedIndex != -1)
            {
                myCon.Open();

                string name = textBox_Nume.Text;
                string deleteQuery = "DELETE FROM Universitati (Id, NameUniv, City, Code) WHERE NameUniv = '" + @name + "'";

                SqlCommand cmd = new SqlCommand(deleteQuery, myCon);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                }

                myCon.Close();

                dsUniv.Clear();
                SqlDataAdapter daUniv = new SqlDataAdapter("SELECT * FROM Universitati", myCon);
                daUniv.Fill(dsUniv, "Universitati");

                listBox_Univ.Items.RemoveAt(listBox_Univ.SelectedIndex);

                MessageBox.Show("University deleted succesfully!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBoxNumeFac.Text != "" && textBoxIdFac.Text != "" && textBoxCodFac.Text != "")
            {
                dsFac.Tables.Add(dataTable);

                if (dataTable.Columns.Count == 0)
                {
                    dataTable.Columns.Add("Cod", typeof(string));
                    dataTable.Columns.Add("Id", typeof(string));
                    dataTable.Columns.Add("NumeFac", typeof(string));
                }

                DataRow NewRow = dataTable.NewRow();
                NewRow[0] = textBoxCodFac.Text;
                NewRow[1] = textBoxIdFac.Text;
                NewRow[2] = textBoxNumeFac.Text;

                dataTable.Rows.Add(NewRow);

                textBoxNumeFac.Clear();
                textBoxIdFac.Clear();
                textBoxCodFac.Clear();
                
                dataGridView1.DataSource = dataTable;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedRows[0].Index;
                dataGridView1.Rows.RemoveAt(rowIndex);
            }
        }
    }
}