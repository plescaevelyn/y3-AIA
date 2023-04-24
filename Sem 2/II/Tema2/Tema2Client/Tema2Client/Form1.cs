using System.Data;
using System.Data.SqlClient;
using ServiceReference1;

namespace Tema2Client
{
    public partial class Form1 : Form
    {
        ServiceReference1.WebService1SoapClient service = new WebService1SoapClient(WebService1SoapClient.EndpointConfiguration.WebService1Soap);

        SqlConnection myCon = new SqlConnection();
        DataTable dataTable = new DataTable();
        DataSet dsSongs;

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public Form1()
        {
            InitializeComponent();

            myCon.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\Facultate\\y3-AIA\\Sem 2\\II\\Tema2\\Tema2Client\\Tema2Client\\Database.mdf;Integrated Security=True";
            myCon.Open();

            dsSongs = new DataSet();
            SqlDataAdapter daUniv = new SqlDataAdapter("SELECT * FROM Songs", myCon);
            daUniv.Fill(dsSongs, "Songs");

            foreach (DataRow dr in dsSongs.Tables["Songs"].Rows)
            {
                String name = dr.ItemArray.GetValue(1).ToString() + dr.ItemArray.GetValue(3).ToString();
                dbData.Items.Add(name);
            }

            myCon.Close();
        }

        private void insertBttn_Click(object sender, EventArgs e)
        {
            try
            {
                service.PostAsync(int.Parse(songIdTextBox.Text), songNameLabel.Text, songTypeTextBox.Text,
                    artistTextBox.Text, albumTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            String addedSong = songNameTextBox.Text + " - " + artistTextBox.Text;
            dbData.Items.Add(addedSong);

            dsSongs.Clear();
            SqlDataAdapter daSongs = new SqlDataAdapter("SELECT * FROM Songs", myCon);
        }

        private void updateBttn_Click(object sender, EventArgs e)
        {
            try
            {
                service.PutAsync(int.Parse(songIdTextBox.Text), songNameLabel.Text, songTypeTextBox.Text,
                artistTextBox.Text, albumTextBox.Text);

                MessageBox.Show("Song updated succesfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            dsSongs.Clear();
            SqlDataAdapter daSongs = new SqlDataAdapter("SELECT * FROM Songs", myCon);
            daSongs.Fill(dsSongs, "Songs");

            dbData.Items.Clear();
            foreach (DataRow dr in dsSongs.Tables["Songs"].Rows)
            {
                dbData.Items.Add(dr.ItemArray.GetValue(1).ToString() + " - " + dr.ItemArray.GetValue(3).ToString());
            }
        }


        private void deleteBttn_Click(object sender, EventArgs e)
        {
            if (songIdTextBox.Text != null)
            {
                try
                {
                    service.DeleteAsync(int.Parse(songIdTextBox.Text));
                    MessageBox.Show("Song with id " + songIdTextBox.Text + " deleted succesfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Song couldn't be deleted because " + ex.Message);
                }
            }

            dsSongs.Clear();
            SqlDataAdapter daSongs = new SqlDataAdapter("SELECT * FROM Songs", myCon);
            daSongs.Fill(dsSongs, "Songs");

            String deletedSong = songNameTextBox.Text + " - " + artistTextBox.Text;
            dbData.Items.Remove(deletedSong);
        }

        private void dbData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dbData.SelectedItem != null)
            {
                String selection = dbData.SelectedItem.ToString();

                foreach (DataRow dr in dsSongs.Tables["Songs"].Rows)
                {
                    if (selection == dr.ItemArray.GetValue(1).ToString() + " - " + dr.ItemArray.GetValue(3))
                    {
                        songIdTextBox.Text = dr.ItemArray.GetValue(0).ToString();
                        songNameTextBox.Text = dr.ItemArray.GetValue(1).ToString();
                        songTypeTextBox.Text = dr.ItemArray.GetValue(2).ToString();
                        artistTextBox.Text = dr.ItemArray.GetValue(3).ToString();
                        albumTextBox.Text = dr.ItemArray.GetValue(4).ToString();
                    }
                }
            }
        }
    }
}