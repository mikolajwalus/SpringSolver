using SpringSolverLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringSolverLibrary.Logic
{
    public static class PhysicalLogic
    {

        public static void SimulateSolution(this SolutionModel model)
        {

            List<double> c = model.CalculateCCoeficients();

            List<double> xOne = model.PointCorrectionX();

            List<double> yOne = model.PointCorrectionY();



            double rZero = model.SumCorrectionForce();

            double rOne = model.ROneCreate(xOne);

            double rTwo = model.RTwoCreate(yOne);



            double constantOne = c.Sum();

            double constantTwo = c.Zip(xOne, (x, y) => x * y).ToList().Sum() / xOne.First();

            double constantThree = c.Zip(yOne, (x, y) => x * y).ToList().Sum() / yOne.First();

            double constantFour = c.Zip(xOne, (x, y) => x * y).ToList().Sum();

            double constantFive = c.Zip(xOne, (x, y) => x * y * y).ToList().Sum() / xOne.First();

            double constantSix = c.Zip(xOne, (cp, x) => cp * x).ToList().Zip(yOne, (x, y) => x * y).ToList().Sum() / yOne.First();

            double constantSeven = c.Zip(yOne, (x, y) => x * y).ToList().Sum();

            double constantEight = c.Zip(xOne, (cp, x) => cp * x).ToList().Zip(yOne, (x, y) => x * y).ToList().Sum() / xOne.First();

            double constantNine = c.Zip(yOne, (x, y) => x * y * y).ToList().Sum() / yOne.First();



            double sXZero = - model.Compressor.Mass * 9.81 / (constantTwo - (constantOne * constantFive / constantFour)) * constantFive / constantFour;

            List<double> sX = new List<double>(xOne);

            sX = sX.Select(x => x =  ( x /   xOne.First()  ) * (model.Compressor.Mass * 9.81 / (constantTwo - (constantOne * constantFive / constantFour))) ).ToList();

            List<double> zX = new List<double>(sX);

            zX = zX.Select(x => x += sXZero).ToList();

            List<double> forcesX = zX.Zip(c, (x, y) => x * y).ToList();




            double sYZero = - model.Compressor.Mass * 9.81 / (constantThree - (constantOne * constantNine / constantSeven)) * constantNine / constantSeven;

            List<double> sY = new List<double>(yOne);

            sY = sY.Select(x => x = x / yOne.First() * (model.Compressor.Mass * 9.81 / (constantThree - (constantOne * constantNine / constantSeven)))).ToList();

            List<double> zY = new List<double>(sY);

            zY = zY.Select(x => x += sYZero).ToList();

            List<double> forcesY = zY.Zip(c, (x, y) => x * y).ToList();




            double conOne = constantTwo - constantEight * constantOne / constantSeven;

            double conTwo = constantThree - constantNine * constantOne / constantSeven;

            double conThree = constantEight * constantFour - constantFive * constantSeven;

            double conFour = constantSix * constantSeven - constantNine * constantFour;

            double conFive = constantTwo * constantSeven - constantEight * constantOne;

            double conSix = constantThree * constantSeven - constantNine * constantOne;

            double conSeven = constantEight * constantFour - constantFive * constantSeven;

            double conEight = constantNine * constantFour - constantSix * constantSeven;


            double zOne = (model.Compressor.Mass * 9.81 - rOne) * constantSeven + rTwo * constantOne;

            double zTwo = rOne * constantSeven - rTwo * constantFour;


            List<double> sZX = new List<double>();

            sZX.Add( ( zTwo * conSix - zOne * conEight )/( conSeven * conSix - conFive * conEight ) );

            sZX.Add( sZX[0] * xOne[1] / xOne[0] );

            sZX.Add(sZX[0] * xOne[2] / xOne[0]);

            sZX.Add(sZX[0] * xOne[3] / xOne[0]);


            List<double> sZY = new List<double>();

            sZY.Add( ( zTwo - conSeven * sZX.First() ) / conEight );

            sZY.Add(sZY[0] * yOne[1] / yOne[0]);

            sZY.Add(sZY[0] * yOne[2] / yOne[0]);

            sZY.Add(sZY[0] * yOne[3] / yOne[0]);

            double sZZero = (-rOne - sZX.First() * constantFive - sZY.First() * constantSix) / constantFour;


            List<double> zZ = new List<double>(sZX);

            zZ = zZ.Zip(sZY, (x, y) => x + y + sZZero).ToList();

            List<double> forcesZ = new List<double>(zZ);

            forcesZ = forcesZ.Zip(c, (x, y) => x * y).ToList().Zip(model.Points, (x, y) => x + y.CorrectionForce).ToList();



            double interia = model.Compressor.Mass * 0.043675 / 12 + model.Compressor.Mass * Math.Pow(model.Compressor.CogDistToIzolZ / 1000, 2);


            double interia_ = model.Compressor.Mass * 0.0006125 + Math.Pow( model.Compressor.CogDistToIzolZ / 1000 , 2) * model.Compressor.Mass;



            double cOneOne = (c[0] + c[1]) * 1000;

            double cTwoTwo = (c[2] + c[3]) * 1000;

            double lOne = Math.Abs( (xOne[0] + xOne[1])/2 ) / 1000;

            double lTwo = Math.Abs((xOne[2] + xOne[3]) / 2) / 1000;

            double omegaX = (cOneOne + cTwoTwo) / model.Compressor.Mass;

            double omegaPhi = (cOneOne * lOne * lOne + cTwoTwo * lTwo * lTwo) / interia;

            double kOne = (cOneOne * lOne - cTwoTwo * lTwo) / model.Compressor.Mass;

            double kTwo = (cOneOne * lOne - cTwoTwo * lTwo) / interia;

            double frequencyOne = Math.Sqrt( (omegaX + omegaPhi )/2   +   0.5 * Math.Sqrt( Math.Pow(omegaX - omegaPhi, 2) + 4 * kOne * kTwo) ) / 2 / Math.PI;

            double frequencyTwo = Math.Sqrt( (omegaX + omegaPhi)/2 - 0.5*Math.Sqrt( Math.Pow( omegaX - omegaPhi, 2 ) + 4 * kOne * kTwo) )/ 2 / Math.PI;



            double cOneOne_ = (c[0] + c[3]) * 1000;

            double cTwoTwo_ = (c[2] + c[1]) * 1000;

            double lOne_ = Math.Abs((yOne[0] + yOne[3]) / 2) / 1000;

            double lTwo_ = Math.Abs((yOne[2] + yOne[1]) / 2) / 1000;

            double omegaX_ = (cOneOne_ + cTwoTwo_) / model.Compressor.Mass;

            double omegaPhi_ = (cOneOne_ * lOne_ * lOne_ + cTwoTwo_ * lTwo_ * lTwo_) / interia_;

            double kOne_ = (cOneOne_ * lOne_ - cTwoTwo_ * lTwo_) / model.Compressor.Mass;

            double kTwo_ = (cOneOne_ * lOne_ - cTwoTwo_ * lTwo_) / interia_;

            double frequencyOne_ = Math.Sqrt((omegaX_ + omegaPhi_) / 2 + 0.5 * Math.Sqrt(Math.Pow(omegaX_ - omegaPhi_, 2) + 4 * kOne_ * kTwo_)) / 2 / Math.PI;

            double frequencyTwo_ = Math.Sqrt((omegaX_ + omegaPhi_) / 2 - 0.5 * Math.Sqrt(Math.Pow(omegaX_ - omegaPhi_, 2) + 4 * kOne_ * kTwo_)) / 2 / Math.PI;


            for (int i = 0; i < model.Points.Count; i++)
            {

                model.Points[i].ForceX = forcesX[i];
                model.Points[i].ElonSprX = zX[i];

                model.Points[i].ForceY = forcesY[i];
                model.Points[i].ElonSprY = zY[i];

                model.Points[i].ForceZ = forcesZ[i];
                model.Points[i].ElonSprZ = zZ[i];

            }

            model.FreqVertMov = frequencyTwo;

            model.FreqRotX = frequencyOne_;

            model.FreqRotY = frequencyOne;

            foreach (SolutionPointModel point in model.Points)
            {
                if (point.Chosen) point.CalculateGaps();
            }

            model.CalculateResult();
        }

        private static void CalculateResult(this SolutionModel model)
        {
            model.Result = 0;
            foreach (SolutionPointModel point in model.Points)
            {
                if (point.Chosen) model.Result += Math.Pow( Math.Abs(point.NominalTopGap - point.NominalBottomGap) + 1, 2);
            }
        }

        private static void CalculateGaps(this SolutionPointModel model)
        {

            double lf = model.Springs[1].Length - model.ForceZ / model.Springs[1].Rate;

            model.NominalTopGap = lf - model.Parts.Sleeve.StepHeight - ( model.Parts.Bearing.Length - model.Parts.Bearing.Step );

            model.NominalBottomGap = model.Parts.Sleeve.Length - lf - model.Parts.Bearing.Step - model.Parts.CounterSleeve.LengthTwo + model.Parts.CounterSleeve.LengthOne;


            double springTol = model.Springs[1].ForceTolerance / model.Springs[1].Rate;

            model.TopGapTolerance = Math.Sqrt( 
                Math.Pow(model.Parts.Sleeve.LengthTolerance, 2 ) +
                Math.Pow(model.Parts.Sleeve.StepHeightTolerance , 2) +
                Math.Pow(model.Parts.Bearing.LengthTolerance , 2) +
                Math.Pow(model.Parts.Bearing.StepTolerance, 2) +
                Math.Pow(springTol , 2) );

            model.BottomGapTolerance = Math.Sqrt(
                Math.Pow(model.Parts.Sleeve.LengthTolerance, 2) +
                Math.Pow(model.Parts.CounterSleeve.LengthOneTolerance, 2) +
                Math.Pow(model.Parts.CounterSleeve.LengthTwoTolerance, 2) +
                Math.Pow(model.Parts.Bearing.StepTolerance, 2) +
                Math.Pow(springTol, 2));

        }

        private static List<double> CalculateCCoeficients(this SolutionModel model)
        {
            List<double> output = new List<double>();

            foreach (SolutionPointModel point in model.Points)
            {
                output.Add(point.Springs[0].Rate + point.Springs[1].Rate);
            }

            return output;
        }

        private static List<double> PointCorrectionX(this SolutionModel model)
        {
            List<double> output = new List<double>();

            foreach (SolutionPointModel point in model.Points)
            {
                output.Add(point.XPosition + model.Compressor.CogDistToPistX);
            }

            return output;
        }

        private static List<double> PointCorrectionY(this SolutionModel model)
        {
            List<double> output = new List<double>();

            foreach (SolutionPointModel point in model.Points)
            {
                output.Add(point.YPosition);
            }

            return output;
        }

        private static double SumCorrectionForce(this SolutionModel model)
        {
            double output = 0;

            foreach (SolutionPointModel point in model.Points)
            {
                output += point.CorrectionForce;
            }

            return output;
        }

        private static double ROneCreate(this SolutionModel model, List<double> xOne)
        {
            double output = 0;

            output = model.Points.Zip(xOne, (x , y) => x.CorrectionForce * y).ToList().Sum();

            return output;
        }

        private static double RTwoCreate(this SolutionModel model, List<double> yOne)
        {
            double output = 0;

            output = model.Points.Zip(yOne, (x, y) => x.CorrectionForce * y).ToList().Sum();

            return output;
        }

    }
}
