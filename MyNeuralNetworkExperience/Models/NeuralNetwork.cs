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

        public List<Synapse> GetSynapsesByNeuron(Neuron neuron)
        {
            List<Synapse> synapses = Synapses
                .Where(s => s.SourceId == neuron.Id)
                .ToList();

            return synapses;
        }

        public List<Neuron> GetNextLayerNeurons(Neuron neuron)
        {
            var synapses = GetSynapsesByNeuron(neuron);

            List<Neuron> nextLayerNeurons = Neurons
                .Where(n => synapses.Select(s => s.DestinationId).ToList().Contains(n.Id))
                .ToList();

            return nextLayerNeurons;
        }

        public List<Neuron> GetHiddenLayerNeurons()
        {
            List<Neuron> inputNeurons = GetInputNeurons();
            List<Neuron> outputNeurons = GetOutputNeurons();

            List<Neuron> hiddenLayerNeurons = Neurons
                .Where(n => !inputNeurons.Select(inn => inn.Id).Contains(n.Id) && !outputNeurons.Select(inn => inn.Id).Contains(n.Id))
                .ToList();

            return hiddenLayerNeurons;
        }

        public List<double> ProcessData(List<double> data)
        {
            List<double> outputValues = new List<double>();
            List<Neuron> inputNeurons = GetInputNeurons();
            List<Neuron> hiddenLayerNeurons = GetHiddenLayerNeurons();

            int inputCount = Math.Min(data.Count, inputNeurons.Count);
            for (int i = 0; i < inputCount; i++)
            {
                Neuron inputNeuron = inputNeurons[i];
                double inputValue = data[i];
            }

            return outputValues;
        }
    }
}
