namespace MyNeuralNetworkExperience.Models
{
    public class NeuralNetwork
    {
        public List<Neuron> Neurons { get; set; }
        public List<Synapse> Synapses { get; set; }
        public int Iteration { get; set; }
        public int Epoch { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public NeuralNetwork()
        {
            Neurons = new List<Neuron>();
            Synapses = new List<Synapse>();
            Name = "Neural Network";
            DateTime now = DateTime.UtcNow;
            CreatedAt = now;
            UpdatedAt = now;
            Iteration = 0;
            Epoch = 0;
        }

        public List<Neuron> GetInputNeurons()
        {
            List<Neuron> inputNeurons = Neurons
                .Where(n => !Synapses.Select(s => s.DestinationId).ToList().Contains(n.Id))
                .ToList();

            return inputNeurons;
        }

        public List<Neuron> GetOutputNeurons()
        {
            List<Neuron> outputNeurons = Neurons
                .Where(n => !Synapses.Select(s => s.SourceId).ToList().Contains(n.Id))
                .ToList();

            return outputNeurons;
        }

        public List<Synapse> GetNextSynapsesByNeuron(Neuron neuron)
        {
            List<Synapse> synapses = Synapses
                .Where(s => s.SourceId == neuron.Id)
                .ToList();

            return synapses;
        }

        public List<Synapse> GetPreviousSynapsesByNeuron(Neuron neuron)
        {
            List<Synapse> synapses = Synapses
                .Where(s => s.DestinationId == neuron.Id)
                .ToList();

            return synapses;
        }

        public List<Neuron> GetPreviousLayerNeurons(Neuron neuron)
        {
            var synapses = GetPreviousSynapsesByNeuron(neuron);

            List<Neuron> previousLayerNeurons = Neurons
                .Where(n => synapses.Select(s => s.SourceId).ToList().Contains(n.Id))
                .ToList();

            return previousLayerNeurons;
        }

        public List<Neuron> GetNextLayerNeurons(Neuron neuron)
        {
            var synapses = GetNextSynapsesByNeuron(neuron);

            List<Neuron> nextLayerNeurons = Neurons
                .Where(n => synapses.Select(s => s.DestinationId).ToList().Contains(n.Id))
                .ToList();

            return nextLayerNeurons;
        }

        // TODO: Reorganize this method
        // Use the level argument as the level of the neural network
        public List<Neuron> GetHiddenLayerNeurons(int level)
        {
            List<Neuron> inputNeurons = GetInputNeurons();
            List<Neuron> outputNeurons = GetOutputNeurons();

            List<Neuron> hiddenLayerNeurons = Neurons
                .Where(n => !inputNeurons.Select(inn => inn.Id).Contains(n.Id) && !outputNeurons.Select(inn => inn.Id).Contains(n.Id))
                .ToList();

            if (level == 0)
            {
                return hiddenLayerNeurons;
            }
            else
            {
                return outputNeurons;
            }
        }

        public List<double> ProcessData(List<double> data, int level = 0)
        {
            List<double> outputValues = new List<double>();

            List<Neuron> hiddenLayerNeurons = GetHiddenLayerNeurons(level);
            foreach (Neuron neuron in hiddenLayerNeurons)
            {
                List<Neuron> previousLayerNeurons = GetPreviousLayerNeurons(neuron);
                double outputValue = 0;
                for (int i = 0; i < previousLayerNeurons.Count; i++)
                {
                    Neuron previousNeuron = previousLayerNeurons[i];
                    double inputValue = data[i];
                    Synapse synapse = Synapses.Where(s => s.SourceId == previousNeuron.Id && s.DestinationId == neuron.Id).FirstOrDefault();
                    if (synapse != null)
                    {
                        outputValue += inputValue * synapse.Weight;
                    }
                }

                outputValues.Add(outputValue);
            }

            if (level == 0)
            {
                return ProcessData(outputValues, level + 1);
            }

            return outputValues;
        }
    }
}
