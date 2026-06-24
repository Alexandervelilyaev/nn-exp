using System.Drawing.Drawing2D;

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

        private void DrawCircle(int x, int y, int radius, Color color, Bitmap image)
        {
            using (Graphics g = Graphics.FromImage(image))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                using (Pen pen = new Pen(color, 2))
                {
                    g.DrawEllipse(pen, x, y, radius, radius);
                }
            }
        }

        private SizeF DrawText(string text, int x, int y, Color color, Bitmap image)
        {
            using (Graphics g = Graphics.FromImage(image))
            {
                var font = new Font("Tahoma", 8);
                var size = g.MeasureString(text, font);

                RectangleF rectf = new RectangleF(x, y, size.Width, size.Height);

                rectf.X -= rectf.Width / 2;
                rectf.Y -= rectf.Height / 2;

                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawString(text, font, Brushes.Black, rectf);

                return size;
            }
        }

        private void VisualizeTopology(NeuralNetwork nn)
        {
            List<int> renderedIds = new List<int>();

            // TODO: Move this select to the NeuralNetwork class
            List<Neuron> inputNeurons = nn.Neurons
                .Where(n => !nn.Synapses.Select(s => s.DestinationId).ToList().Contains(n.Id))
                .ToList();

            var bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            for (int i = 0; i < bitmap.Width; i++)
            {
                bitmap.SetPixel(i, 0, Color.Black);
            }

            for (int i = 0; i < bitmap.Height; i++)
            {
                bitmap.SetPixel(0, i, Color.Black);
            }

            int padding = 5;
            int radius = 20;
            int x = padding;
            int y = padding;


            foreach (Neuron neuron in inputNeurons)
            {
                if (!renderedIds.Contains(neuron.Id))
                {
                    DrawCircle(x, y, radius, Color.Green, bitmap);
                    DrawText(neuron.Id.ToString(), x + radius / 2, y + radius / 2, Color.Blue, bitmap);
                    renderedIds.Add(neuron.Id);
                }

                // TODO: Move this select to the NeuralNetwork class
                var synapses = nn.Synapses.Where(s => s.SourceId == neuron.Id).ToList();

                // TODO: Move this select to the NeuralNetwork class
                List<Neuron> nextLayerNeurons = nn.Neurons
                    .Where(n => synapses.Select(s => s.DestinationId).ToList().Contains(n.Id))
                    .ToList();

                foreach (Neuron nextLayerNeuron in nextLayerNeurons)
                {
                    if (!renderedIds.Contains(nextLayerNeuron.Id))
                    {
                        var xx = x + radius * 2 + padding;
                        DrawCircle(xx, y, radius, Color.Red, bitmap);
                        DrawText(nextLayerNeuron.Id.ToString(), xx + radius / 2, y + radius / 2, Color.Blue, bitmap);
                        renderedIds.Add(nextLayerNeuron.Id);
                    }
                }

                y += padding + radius * 2;
            }

            pictureBox1.Image = bitmap;
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

            VisualizeTopology(nn);

            Console.WriteLine("");
        }
    }
}