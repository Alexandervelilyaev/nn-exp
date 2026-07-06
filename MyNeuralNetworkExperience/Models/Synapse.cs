using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
