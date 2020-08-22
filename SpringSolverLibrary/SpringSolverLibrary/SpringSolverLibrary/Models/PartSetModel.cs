using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringSolverLibrary
{
    public class PartSetModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public SleeveModel Sleeve { get; set; }

        public BearingModel Bearing { get; set; }

        public CounterSleeveModel CounterSleeve { get; set; }
    }
}
