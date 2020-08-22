using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringSolverLibrary
{
    public class CompressorModel
    {
        public int Id { get; set; }

        public double Mass { get; set; }

        public double XCorrection { get; set; }

        public double YCorrection { get; set; }

        public double CogDistToPistX { get; set; }

        public double CogDistToIzolZ { get; set; }
    }
}
