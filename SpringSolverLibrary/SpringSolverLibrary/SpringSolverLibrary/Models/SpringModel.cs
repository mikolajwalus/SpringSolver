using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SpringSolverLibrary
{
    public class SpringModel
    {
        public SpringModel(bool zero = false)
        {
            if(zero)
            {
                Number = "";
                Rate = 0;
                Length = 0;
                Force = 0;
                ForceTolerance = 0;
            }
        }

        public int Id { get; set; }

        public string Number { get; set; }

        public double Rate { get; set; }

        public double Length { get; set; }

        public double Force { get; set; }

        public double ForceTolerance { get; set; }
    }
}