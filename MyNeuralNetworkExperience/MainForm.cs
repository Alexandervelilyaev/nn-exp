namespace MyNeuralNetworkExperience
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewForm newForm = new NewForm();
            newForm.ShowDialog();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: use openFileDialog
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            List<Neuron> neuronList = new List<Neuron>();
            List<Synapse> synapseList = new List<Synapse>();

            Neuron n1 = new Neuron()
            {
                Id = 1
            };
            neuronList.Add(n1);

            Neuron n2 = new Neuron()
            {
                Id = 2
            };
            neuronList.Add(n2);

            Neuron n3 = new Neuron()
            {
                Id = 3
            };
            neuronList.Add(n3);

            Synapse s1 = new Synapse()
            {
                Id = 1,
                SourceId = 1,
                DestinationId = 3,
                Weight = new Random().NextDouble()
            };
            synapseList.Add(s1);

            Synapse s2 = new Synapse()
            {
                Id = 2,
                SourceId = 2,
                DestinationId = 3,
                Weight = new Random().NextDouble()
            };
            synapseList.Add(s2);

            NeuralNetwork nn = new NeuralNetwork();
            nn.Neurons = neuronList;
            nn.Synapses = synapseList;

            Console.WriteLine("");
        }
    }
}