using System.Drawing.Drawing2D;

namespace MyNeuralNetworkExperience
{
    public partial class MainForm : Form
    {
        private List<Neuron> renderedNeurons { get; set; }
        private readonly int radius = 20;
        private readonly int padding = 5;

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

        private void DrawLine(int x1, int y1, int x2, int y2, Color color, Bitmap image)
        {
            using (Graphics g = Graphics.FromImage(image))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                using (Pen pen = new Pen(color, 2))
                {
                    g.DrawLine(pen, x1, y1, x2, y2);
                }
            }
        }

        private void drawNode(Neuron neuron, Color color, Bitmap image)
        {
            if (!renderedNeurons.Select(n=>n.Id).Contains(neuron.Id))
            {
                DrawCircle(neuron.X, neuron.Y, radius, color, image);
                DrawText(neuron.Id.ToString(), neuron.X + radius / 2, neuron.Y + radius / 2, Color.Blue, image);
                renderedNeurons.Add(new Neuron()
                {
                    Id = neuron.Id,
                    X = neuron.X,
                    Y = neuron.Y
                });
            }
        }

        private void VisualizeTopology(NeuralNetwork nn)
        {
            renderedNeurons = new List<Neuron>();

            // TODO: Move this select to the NeuralNetwork class
            List<Neuron> inputNeurons = nn.Neurons
                .Where(n => !nn.Synapses.Select(s => s.DestinationId).ToList().Contains(n.Id))
                .ToList();

            int calculatedHeight = inputNeurons.Count * (radius * 2) + (inputNeurons.Count - 1) * padding;

            var bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            for (int i = 0; i < bitmap.Width; i++)
            {
                bitmap.SetPixel(i, 0, Color.Black);
            }

            for (int i = 0; i < bitmap.Height; i++)
            {
                bitmap.SetPixel(0, i, Color.Black);
            }

            int x = padding;
            int y = padding;

            foreach (Neuron neuron in inputNeurons)
            {
                neuron.X = x;
                neuron.Y = y;
                drawNode(neuron, Color.Green, bitmap);

                // TODO: Move this select to the NeuralNetwork class
                var synapses = nn.Synapses.Where(s => s.SourceId == neuron.Id).ToList();

                // TODO: Move this select to the NeuralNetwork class
                List<Neuron> nextLayerNeurons = nn.Neurons
                    .Where(n => synapses.Select(s => s.DestinationId).ToList().Contains(n.Id))
                    .ToList();

                for (int i = 0; i < nextLayerNeurons.Count; i++)
                {
                    Neuron nextLayerNeuron = nextLayerNeurons[i];
                    nextLayerNeuron.X = x + radius * 2 + padding;
                    nextLayerNeuron.Y = y + i * (radius * 2 + padding);

                    if (nextLayerNeurons.Count == 1)
                    {
                        nextLayerNeuron.Y += calculatedHeight / 2 - radius;
                    }

                    drawNode(nextLayerNeuron, Color.Red, bitmap);
                }

                y += padding + radius * 2;
            }

            foreach (Synapse synapse in nn.Synapses)
            {
                var srcNeuron = renderedNeurons.Where(n => synapse.SourceId == n.Id).FirstOrDefault();
                var dstNeuron = renderedNeurons.Where(n => synapse.DestinationId == n.Id).FirstOrDefault();
                if (srcNeuron != null && dstNeuron != null)
                {
                    DrawLine(srcNeuron.X + radius, srcNeuron.Y + radius / 2, dstNeuron.X, dstNeuron.Y + radius / 2, Color.Green, bitmap);
                }
            }

            pictureBox1.Image = bitmap;
        }

        private NeuralNetwork CreateNetworkSmall()
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

            return nn;
        }

        private NeuralNetwork CreateNetworkBig()
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

            Neuron n4 = new Neuron()
            {
                Id = 4
            };
            neuronList.Add(n4);

            Neuron n5 = new Neuron()
            {
                Id = 5
            };
            neuronList.Add(n5);

            Neuron n6 = new Neuron()
            {
                Id = 6
            };
            neuronList.Add(n6);

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
                SourceId = 1,
                DestinationId = 4,
                Weight = new Random().NextDouble()
            };
            synapseList.Add(s2);

            Synapse s3 = new Synapse()
            {
                Id = 3,
                SourceId = 1,
                DestinationId = 5,
                Weight = new Random().NextDouble()
            };
            synapseList.Add(s3);

            Synapse s4 = new Synapse()
            {
                Id = 4,
                SourceId = 2,
                DestinationId = 3,
                Weight = new Random().NextDouble()
            };
            synapseList.Add(s4);

            Synapse s5 = new Synapse()
            {
                Id = 5,
                SourceId = 2,
                DestinationId = 4,
                Weight = new Random().NextDouble()
            };
            synapseList.Add(s5);

            Synapse s6 = new Synapse()
            {
                Id = 6,
                SourceId = 2,
                DestinationId = 5,
                Weight = new Random().NextDouble()
            };
            synapseList.Add(s6);

            Synapse s7 = new Synapse()
            {
                Id = 7,
                SourceId = 3,
                DestinationId = 6,
                Weight = new Random().NextDouble()
            };
            synapseList.Add(s7);

            Synapse s8 = new Synapse()
            {
                Id = 8,
                SourceId = 4,
                DestinationId = 6,
                Weight = new Random().NextDouble()
            };
            synapseList.Add(s8);

            Synapse s9 = new Synapse()
            {
                Id = 9,
                SourceId = 5,
                DestinationId = 6,
                Weight = new Random().NextDouble()
            };
            synapseList.Add(s9);

            NeuralNetwork nn = new NeuralNetwork();
            nn.Neurons = neuronList;
            nn.Synapses = synapseList;

            return nn;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            NeuralNetwork nn = CreateNetworkBig();
            VisualizeTopology(nn);

            Console.WriteLine("");
        }
    }
}