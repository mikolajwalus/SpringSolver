using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringSolverLibrary.TextConnection.TextConnectorProcessor
{
    public static class TextConnectorProcessor
    {
        public static string FullFilePath(this string fileName)
        {
        // D:\SpringSolver\fileName
            return $"{ConfigurationManager.AppSettings["filePath"]}\\{fileName}";
        }

        public static List<string> LoadFile(this string file)
        {
            if(!File.Exists(file))
            {
                return new List<string>();
            }
            else
            {
                return File.ReadAllLines(file).ToList();
            }
        }

        public static List<SpringModel> ConvertTextToSpring(this List<string> lines)
        {
            // Id|^|Number|^|Rate|^|Length|^|Force|^|ForceTolerance

            List<SpringModel> output = new List<SpringModel>();
            SpringModel curr = new SpringModel();
            foreach (string line in lines)
            {
                string[] cols = line.Split(new string[] { "|^|" }, StringSplitOptions.None);
                curr.Id = int.Parse(cols[0]);
                curr.Number = cols[1];
                curr.Rate = double.Parse(cols[2]);
                curr.Length = double.Parse(cols[3]);
                curr.Force = double.Parse(cols[4]);
                curr.ForceTolerance = double.Parse(cols[5]);

                output.Add(curr);
                curr = new SpringModel();
            }

            return output;
        }

        public static List<BearingModel> ConvertTextToBearing(this List<string> lines)
        {
            //Id|^|Number|^|Lenght|^|LenghtTolerance|^|Step|^|StepTolerance";

            List<BearingModel> output = new List<BearingModel>();
            BearingModel curr = new BearingModel();

            foreach (string line in lines)
            {
                string[] cols = line.Split(new string[] { "|^|" }, StringSplitOptions.None);
                curr.Id = int.Parse(cols[0]);
                curr.Number = cols[1];
                curr.Length = double.Parse(cols[2]);
                curr.LengthTolerance = double.Parse(cols[3]);
                curr.Step = double.Parse(cols[4]);
                curr.StepTolerance = double.Parse(cols[5]);

                output.Add(curr);
                curr = new BearingModel();
            }

            return output;
        }

        public static List<SleeveModel> ConvertTextToSleeve(this List<string> lines)
        {
            //Id|^|Number|^|Lenght|^|LenghtTolerance|^|StepHeight|^|StepHeightTolerance";

            List<SleeveModel> output = new List<SleeveModel>();
            SleeveModel curr = new SleeveModel();

            foreach (string line in lines)
            {
                string[] cols = line.Split(new string[] { "|^|" }, StringSplitOptions.None);
                curr.Id = int.Parse(cols[0]);
                curr.Number = cols[1];
                curr.Length = double.Parse(cols[2]);
                curr.LengthTolerance = double.Parse(cols[3]);
                curr.StepHeight = double.Parse(cols[4]);
                curr.StepHeightTolerance = double.Parse(cols[5]);

                output.Add(curr);
                curr = new SleeveModel();
            }

            return output;
        }

        public static List<CounterSleeveModel> ConvertTextToCounterSleeve(this List<string> lines)
        {
            //Id|^|Number|^|LengthOne|^|LengthOneTolerance|^|LengthTwo|^|LengthTwoTolerance";

            List<CounterSleeveModel> output = new List<CounterSleeveModel>();
            CounterSleeveModel curr = new CounterSleeveModel();

            foreach (string line in lines)
            {
                string[] cols = line.Split(new string[] { "|^|" }, StringSplitOptions.None);
                curr.Id = int.Parse(cols[0]);
                curr.Number = cols[1];
                curr.LengthOne = double.Parse(cols[2]);
                curr.LengthOneTolerance = double.Parse(cols[3]);
                curr.LengthTwo = double.Parse(cols[4]);
                curr.LengthTwoTolerance = double.Parse(cols[5]);

                output.Add(curr);
                curr = new CounterSleeveModel();
            }

            return output;
        }

        public static List<CompressorModel> ConvertTextToCompressor(this List<string> lines)
        {
            //Id|^|Mass|^|XCorrection|^|YCorrection|^|CogDistToPistX|^|CogDistToIzolZ";

            List<CompressorModel> output = new List<CompressorModel>();
            CompressorModel curr = new CompressorModel();

            foreach (string line in lines)
            {
                string[] cols = line.Split(new string[] { "|^|" }, StringSplitOptions.None);
                curr.Id = int.Parse(cols[0]);
                curr.Mass = double.Parse(cols[1]);
                curr.XCorrection = double.Parse(cols[2]);
                curr.YCorrection = double.Parse(cols[3]);
                curr.CogDistToPistX = double.Parse(cols[4]);
                curr.CogDistToIzolZ = double.Parse(cols[5]);

                output.Add(curr);
                curr = new CompressorModel();
            }

            return output;
        }

        public static List<FixationPointModel> ConvertTextToFixationPoint(this List<string> lines)
        {
            //Id|^|Chosen|^|UpperSpringBool|^|LowerSpringBool|^|XPosition|^|YPosition|^|PartSetModelId";

            List<FixationPointModel> output = new List<FixationPointModel>();
            FixationPointModel curr = new FixationPointModel();
            List<PartSetModel> allPartSets = TextConnector.PartSet_GetAll();

            foreach (string line in lines)
            {
                string[] cols = line.Split(new string[] { "|^|" }, StringSplitOptions.None);
                curr.Id = int.Parse(cols[0]);
                curr.Chosen = Boolean.Parse(cols[1]);
                curr.UpperSpringBool = Boolean.Parse(cols[2]);
                curr.LowerSpringBool = Boolean.Parse(cols[3]);
                curr.XPosition = double.Parse(cols[4]);
                curr.YPosition = double.Parse(cols[5]);
                curr.Parts = allPartSets.Where(x => x.Id == int.Parse(cols[6])).First();

                output.Add(curr);
                curr = new FixationPointModel();
            }

            return output;
        }

        public static List<PartSetModel> ConvertTextToPartSet(this List<string> lines)
        {
            //Id|^|Name|^|SleeveId|^|BearingId|^|CounterSleeveId;

            List<PartSetModel> output = new List<PartSetModel>();
            PartSetModel curr = new PartSetModel();

            List<SleeveModel> sleeves = TextConnector.Sleeve_GetAll();
            List<BearingModel> bearings = TextConnector.Bearing_GetAll();
            List<CounterSleeveModel> counterSleeves = TextConnector.CounterSleeve_GetAll();

            foreach (string line in lines)
            {
                string[] cols = line.Split(new string[] { "|^|" }, StringSplitOptions.None);
                curr.Id = int.Parse(cols[0]);
                curr.Name = cols[1];
                curr.Sleeve = sleeves.Where(x => x.Id == int.Parse(cols[2])).First();
                curr.Bearing = bearings.Where(x => x.Id == int.Parse(cols[3])).First();
                curr.CounterSleeve = counterSleeves.Where(x => x.Id == int.Parse(cols[4])).First();

                output.Add(curr);
                curr = new PartSetModel();
            }

            return output;
        }

        public static List<CalculationsModel> ConvertTextToCalculation(this List<string> lines)
        {
            //Id|^|Name|^|CompressorId|^|PointId\\\\PointId\\\\PointId|^|AllowedSpringNumber;

            List<CalculationsModel> output = new List<CalculationsModel>();
            CalculationsModel curr = new CalculationsModel();

            List<FixationPointModel> fixationPoints = TextConnector.FixationPoint_GetAll();
            List<CompressorModel> compressors = TextConnector.Compressor_GetAll();

            foreach (string line in lines)
            {
                string[] cols = line.Split(new string[] { "|^|" }, StringSplitOptions.None);
                curr.Id = int.Parse(cols[0]);
                curr.Name = cols[1];
                curr.Compressor = compressors.Where(x => x.Id == int.Parse(cols[2])).First();

                string[] colsPoint = cols[3].Split(new string[] { "," }, StringSplitOptions.None);
                foreach (string point in colsPoint)
                {
                    curr.Points.Add(fixationPoints.Where(x => x.Id == int.Parse(point)).ToList().First());
                }

                curr.AllowedSpringNumber = int.Parse(cols[4]);

                output.Add(curr);
                curr = new CalculationsModel();
            }

            return output;
        }

        public static void SaveSpringsToFile(this List<SpringModel> springs)
        {

            List<string> text = new List<string>();
            string curr = "";
            foreach (SpringModel spring in springs)
            {
                curr = $"{spring.Id}|^|{spring.Number}|^|{spring.Rate}|^|{spring.Length}|^|{spring.Force}|^|{spring.ForceTolerance}";
                text.Add(curr);
                curr = "";
            }
            File.WriteAllLines(GlobalConfig.SpringFile.FullFilePath(), text);

        }

        public static void SaveBearingsToFile(this List<BearingModel> bearings)
        {

            List<string> text = new List<string>();
            string curr = "";
            foreach (BearingModel bearing in bearings)
            {
                curr = $"{bearing.Id}|^|{bearing.Number}|^|{bearing.Length}|^|{bearing.LengthTolerance}|^|{bearing.Step}|^|{bearing.StepTolerance}";
                text.Add(curr);
                curr = "";
            }
            File.WriteAllLines(GlobalConfig.BearingFile.FullFilePath(), text);

        }

        public static void SaveSleevesToFile(this List<SleeveModel> sleeves)
        {

            List<string> text = new List<string>();
            string curr = "";
            foreach (SleeveModel sleeve in sleeves)
            {
                curr = $"{sleeve.Id}|^|{sleeve.Number}|^|{sleeve.Length}|^|{sleeve.LengthTolerance}|^|{sleeve.StepHeight}|^|{sleeve.StepHeightTolerance}";
                text.Add(curr);
                curr = "";
            }
            File.WriteAllLines(GlobalConfig.SleeveFile.FullFilePath(), text);

        }

        public static void SaveCounterSleevesToFile(this List<CounterSleeveModel> counterSleeves)
        {

            List<string> text = new List<string>();
            string curr = "";
            foreach (CounterSleeveModel counterSleeve in counterSleeves)
            {
                curr = $"{counterSleeve.Id}|^|{counterSleeve.Number}|^|{counterSleeve.LengthOne}|^|{counterSleeve.LengthOneTolerance}|^|{counterSleeve.LengthTwo}|^|{counterSleeve.LengthTwoTolerance}";
                text.Add(curr);
                curr = "";
            }
            File.WriteAllLines(GlobalConfig.CounterSleeveFile.FullFilePath(), text);

        }

        public static void SaveCompressorsToFile(this List<CompressorModel> compressors)
        {
            //Id|^|Mass|^|XCorrection|^|YCorrection|^|CogDistToPistX|^|CogDistToIzolZ";
            List<string> text = new List<string>();
            string curr = "";
            foreach (CompressorModel compressor in compressors)
            {
                curr = $"{compressor.Id}|^|{compressor.Mass}|^|{compressor.XCorrection}|^|{compressor.YCorrection}|^|{compressor.CogDistToPistX}|^|{compressor.CogDistToIzolZ}";
                text.Add(curr);
                curr = "";
            }
            File.WriteAllLines(GlobalConfig.CompressorFile.FullFilePath(), text);

        }

        public static void SaveFixationPointsToFile(this List<FixationPointModel> points)
        {
            //Id|^|Chosen|^|UpperSpringBool|^|LowerSpringBool|^|XPosition|^|YPosition|^|PartSetModelId";
            List<string> text = new List<string>();
            string curr = "";
            foreach (FixationPointModel point in points)
            {
                curr = $"{point.Id}|^|{point.Chosen.ToString()}|^|{point.UpperSpringBool.ToString()}|^|{point.LowerSpringBool.ToString()}|^|{point.XPosition}|^|{point.YPosition}|^|{point.Parts.Id}";
                text.Add(curr);
                curr = "";
            }
            File.WriteAllLines(GlobalConfig.FixationPointFile.FullFilePath(), text);

        }

        public static void SavePartSetsToFile(this List<PartSetModel> partSets)
        {
            List<string> text = new List<string>();
            string curr = "";
            foreach (PartSetModel partSet in partSets)
            {
                curr = $"{partSet.Id}|^|{partSet.Name}|^|{partSet.Sleeve.Id}|^|{partSet.Bearing.Id}|^|{partSet.CounterSleeve.Id}";
                text.Add(curr);
                curr = "";
            }
            File.WriteAllLines(GlobalConfig.PartSetFile.FullFilePath(), text);
        }

        public static void SaveCalculationsToFile(this List<CalculationsModel> calculations)
        {
            //Id|^|Name|^|CompressorId|^|PointId\\\\PointId\\\\PointId|^|AllowedSpringNumber;

            List<string> text = new List<string>();
            string curr = "";
            string pointsString = "";

            foreach (CalculationsModel calculation in calculations)
            {
                foreach(FixationPointModel point in calculation.Points)
                {
                    pointsString += $"{point.Id},";
                }

                pointsString = pointsString.Substring(0, pointsString.Length - 1);

                curr = $"{calculation.Id}|^|{calculation.Name}|^|{calculation.Compressor.Id}|^|{pointsString}|^|{calculation.AllowedSpringNumber}";
                text.Add(curr);
                curr = "";
                pointsString = "";
            }

            File.WriteAllLines(GlobalConfig.CalculationFile.FullFilePath(), text);
        }
    }
}
