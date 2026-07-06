namespace MyNeuralNetworkExperience.Models
{
    public class NeuralNetwork
    {
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

        public List<Neuron> Neurons { get; set; }
        public List<Synapse> Synapses { get; set; }
        public int Iteration { get; set; }
        public int Epoch { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
