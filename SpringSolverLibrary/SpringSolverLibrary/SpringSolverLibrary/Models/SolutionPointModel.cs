using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringSolverLibrary.Models
{
    public class SolutionPointModel : FixationPointModel
    {
        public SolutionPointModel(bool zero = false)
        {
            if(zero)
            {
                Chosen = false;
                UpperSpringBool = false;
                LowerSpringBool = false;
                XPosition = 0;
                YPosition = 0;
                Springs.Add(new SpringModel(true));
                Springs.Add(new SpringModel(true));
            }
        }

        public SolutionPointModel(FixationPointModel baseModel, List<SpringModel> springs) :base(baseModel)
        {
            Springs = springs;
            CorrectionForce = 0;
        }

        /// <summary>
        /// First is Upper Spring, Second is Lower
        /// </summary>
        public List<SpringModel> Springs { get; set; } = new List<SpringModel>();

        public double CorrectionForce;

        /// <summary>
        /// forces (N), analysis direction x
        /// </summary>
        public double ForceX { get; set; }

        /// <summary>
        /// elongation of the spring (mm) n x
        /// </summary>
        public double ElonSprX { get; set; }

        /// <summary>
        /// forces (N), analysis direction y
        /// </summary>
        public double ForceY { get; set; }

        /// <summary>
        /// elongation of the spring (mm) in y
        /// </summary>
        public double ElonSprY { get; set; }

        /// <summary>
        /// forces (N), analysis direction in z (x-y) plane
        /// </summary>
        public double ForceZ { get; set; }

        /// <summary>
        /// elongation of the spring (mm) in z (x-y) plane
        /// </summary>
        public double ElonSprZ { get; set; }

        /// <summary>
        /// top gap in the point
        /// </summary>
        public double NominalTopGap { get; set; }

        /// <summary>
        /// top gap tolerance
        /// </summary>
        public double TopGapTolerance { get; set; }

        /// <summary>
        /// nominal bottom gap
        /// </summary>
        public double NominalBottomGap { get; set; }

        /// <summary>
        /// bottom gap tolerance
        /// </summary>
        public double BottomGapTolerance { get; set; }
    }
}
