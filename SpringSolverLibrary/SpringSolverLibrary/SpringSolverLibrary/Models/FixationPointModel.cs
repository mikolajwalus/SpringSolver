using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringSolverLibrary
{
    public class FixationPointModel
    {
        public FixationPointModel()
        {

        }

        public FixationPointModel(FixationPointModel model)
        {

            this.Id = model.Id;
            this.Chosen = model.Chosen;
            this.UpperSpringBool = model.UpperSpringBool;
            this.LowerSpringBool = model.LowerSpringBool;
            this.XPosition = model.XPosition;
            this.YPosition = model.YPosition;
            this.Parts = model.Parts;
        }

        public int Id { get; set; }

        public bool Chosen { get; set; }

        public bool UpperSpringBool { get; set; }

        public bool LowerSpringBool { get; set; }

        public double XPosition { get; set; }

        public double YPosition { get; set; }

        public PartSetModel Parts { get; set; }

    }
}
