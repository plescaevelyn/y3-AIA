using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;

namespace Tema1
{
    public partial class Form1 : Form
    {
        SqlConnection myCon = new SqlConnection();
        DataSet dsApplicants;
        public Form1()
        {
            InitializeComponent();

            listBox1.Items.Add("Software Developer Intern");
            listBox1.Items.Add("Software Tester Intern");
            listBox1.Items.Add("DevOps Intern");
            listBox1.Items.Add("Systems Admin Intern");

            myCon.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\y3AIA\\Sem 2\\II\\Tema1\\Tema1\\Database1.mdf;Integrated Security=True";
            myCon.Open();

            dsApplicants = new DataSet();
            SqlDataAdapter daApplicants = new SqlDataAdapter("SELECT * FROM Applicants", myCon);
            daApplicants.Fill(dsApplicants, "Applicants");

            foreach (DataRow dr in dsApplicants.Tables["Applicants"].Rows)
            {
                String name = dr.ItemArray.GetValue(1).ToString() + " " + dr.ItemArray.GetValue(2).ToString();
                listBox2.Items.Add(name);
            }

            myCon.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myCon.Open();

            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;
            string gender = radioButton1.Checked ? "m" : "f";
            string yearsOfExperience = yrsOfExp.Value.ToString();

            if (listBox1.SelectedItem == null || firstName == "" || lastName == "")
            {
                MessageBox.Show("Fill in all the data!");
                myCon.Close();

                return;
            }

            string selectedProgram = listBox1.SelectedItem.ToString();

            string insertQuery = "INSERT INTO Universitati (LastName, FirstName, Gender, YrsOfExp, Role) " +
                "VALUES (@firstName, @lastName, @gender, @yearOfExperience, @selectedProgram)";

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
            MessageBox.Show("Applicant registered!");

            dsApplicants.Clear();
            SqlDataAdapter daApplicants = new SqlDataAdapter("SELECT * FROM Applicants", myCon);
            daApplicants.Fill(dsApplicants, "Applicants");

            string numeApp = textBoxFirstName.Text + " " + textBoxLastName.Text;
            listBox2.Items.Add(numeApp);
        }
    }
}