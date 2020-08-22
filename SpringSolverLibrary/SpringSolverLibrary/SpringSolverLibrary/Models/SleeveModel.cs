using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringSolverLibrary
{
    public class SleeveModel
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public double Length { get; set; }

        public double LengthTolerance { get; set; }

        public double StepHeight { get; set; }

        public double StepHeightTolerance { get; set; }
    }
}
