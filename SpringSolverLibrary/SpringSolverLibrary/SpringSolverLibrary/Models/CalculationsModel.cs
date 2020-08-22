using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringSolverLibrary
{
    public class CalculationsModel
    {
        public CalculationsModel()
        {

        }
        public CalculationsModel(CalculationsModel model)
        {
            this.Compressor = model.Compressor;

            this.AllowedSpringNumber = model.AllowedSpringNumber;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public List<FixationPointModel> Points { get; set; } = new List<FixationPointModel>();

        public CompressorModel Compressor { get; set; }

        public int AllowedSpringNumber { get; set; }
    }
}
