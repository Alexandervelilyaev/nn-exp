using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNeuralNetworkExperience.Models
{
    public class NeuralNetwork
    {
        public NeuralNetwork()
        {
            Neurons = new List<Neuron>();
            Synapses = new List<Synapse>();
        }

        public List<Neuron> Neurons { get; set; }
        public List<Synapse> Synapses { get; set; }
    }
}
