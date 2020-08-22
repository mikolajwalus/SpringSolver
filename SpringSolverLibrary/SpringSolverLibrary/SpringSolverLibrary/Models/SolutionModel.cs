using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringSolverLibrary.Models
{
    public class SolutionModel : CalculationsModel
    {
        public SolutionModel(CalculationsModel model, List<SpringModel> springSetup) :base(model)
        {
            List<SpringModel> springs = new List<SpringModel>(springSetup);
            List<SpringModel> param = new List<SpringModel>();

            this.Points = new List<SolutionPointModel>();

            foreach (FixationPointModel point in model.Points)
            {
                if(point.UpperSpringBool)
                {
                    param.Add(springs.First());
                    springs.RemoveAt(0);
                }
                else
                {
                    param.Add(new SpringModel(true));
                }

                if (point.LowerSpringBool)
                {
                    param.Add(springs.First());
                    springs.RemoveAt(0);
                }
                else
                {
                    param.Add(new SpringModel(true));
                }

                this.Points.Add(new SolutionPointModel( point,  new List<SpringModel>(param) ));

                param.Clear();
            }

            if(Points.Count() == 3)
            {
                this.Points.Add(new SolutionPointModel(true) );
            }
        }
        new public List<SolutionPointModel> Points { get; set; }

        public double FreqVertMov { get; set; }

        public double FreqRotY { get; set; }

        public double FreqRotX { get; set; }

        public double Result { get; set; }

    }
}
