namespace MyNeuralNetworkExperience.Models
{
    public class Synapse
    {
        public int Id { get; set; }

        public int SourceId { get; set; }

        public int DestinationId { get; set; }

        public double Weight { get; set; }
    }
}
