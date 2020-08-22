using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringSolverLibrary
{
    public class BearingModel
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public double Length { get; set; }

        public double LengthTolerance { get; set; }

        public double Step { get; set; }

        public double StepTolerance { get; set; }
    }
}
