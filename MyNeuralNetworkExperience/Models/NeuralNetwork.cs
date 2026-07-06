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

        public List<double> ProcessData(List<double> data)
        {
            // TODO: Implement this method
            return data;
        }
    }
}
