namespace MyNeuralNetworkExperience
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            versionLabel.Text = $"Version: {Application.ProductVersion}";
        }
    }
}
