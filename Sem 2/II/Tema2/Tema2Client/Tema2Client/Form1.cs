using System.Data;
using System.Data.SqlClient;

namespace Tema2Client
{
    public partial class Form1 : Form
    {
        Tema2Client.ServiceReference1.WebService1SoapClient service = new Tema2Client.ServiceReference1.WebService1SoapClient();

        SqlConnection myCon = new SqlConnection();
        DataTable dataTable = new DataTable();
        DataSet dsSongs;

        public Form1()
        {
            InitializeComponent();

            myCon.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\Facultate\\y3-AIA\\Sem 2\\II\\Tema2\\Tema2Client\\Tema2Client\\Database1.mdf;Integrated Security=True";
            myCon.Open();

            dsSongs = new DataSet();
            SqlDataAdapter daUniv = new SqlDataAdapter("SELECT * FROM Songs", myCon);
            daUniv.Fill(dsSongs, "Songs");

            foreach (DataRow dr in dsSongs.Tables["Songs"].Rows)
            {
                String name = dr.ItemArray.GetValue(1).ToString();
                dbData.Items.Add(name);
            }

            myCon.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void insertBttn_Click(object sender, EventArgs e)
        {
            try
            {
                service.Post(int.Parse(songIdTextBox.Text), songNameLabel.Text, songTypeTextBox.Text,
                    artistTextBox.Text, albumTextBox.Text);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            dsSongs.Clear();
            SqlDataAdapter daSongs = new SqlDataAdapter("SELECT * FROM Songs", myCon);

            String addedSongName = songNameTextBox.Text;
            dbData.Items.Add(addedSongName);
}

        private void updateBttn_Click(object sender, EventArgs e)
        {
            try
            {
                service.Put(int.Parse(songIdTextBox.Text), songNameLabel.Text, songTypeTextBox.Text,
                    artistTextBox.Text, albumTextBox.Text);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            dbData.Items.Clear();
            foreach (DataRow dr in dsSongs.Tables["Songs"].Rows)
            {
                dbData.Items.Add(dr.ItemArray.GetValue(1));
            }
        }

        private void deleteBttn_Click(object sender, EventArgs e)
        {
            try
            {
                service.Delete(int.Parse(songIdTextBox.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            dsSongs.Clear();
            SqlDataAdapter daSongs = new SqlDataAdapter("SELECT * FROM Songs", myCon);
            
            string deletedSong = songNameTextBox.Text;
            dbData.Items.Remove(deletedSong);
        }   
    }
}