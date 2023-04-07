namespace Exercise2FormsClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Exercise2FormsClient.ServiceReference1.WebService1SoapClient service = new Exercise2FormsClient.ServiceReference1.WebService1SoapClient();
        }

        private void FtoCbttn_Click(object sender, EventArgs e)
        {
            resultTextBox.Text = service.ConvertTemperature(fahrenheitTextBox.Text, 'F');
        }

        private void CtoFbttn_Click(object sender, EventArgs e)
        {
            resultTextBox.Text = service.ConvertTemperature(celsiusTextBox.Text, 'C');
        }

        private void ronTextBox_TextChanged(object sender, EventArgs e)
        {
            hufTextBox.Text = service.CurrencyConversion(int.Parse(ronTextBox.Text));
        }

        private void dataLbl_Click(object sender, EventArgs e)
        {
            dataLbl.Text = "Data: " + service.TimeDisplay(); 
        }
    }
}