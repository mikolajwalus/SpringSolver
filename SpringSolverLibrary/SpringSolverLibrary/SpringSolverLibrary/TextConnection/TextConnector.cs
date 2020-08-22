using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpringSolverLibrary.TextConnection.TextConnectorProcessor;

namespace SpringSolverLibrary.TextConnection
{
    public static class TextConnector
    {
        public static void CreateSpring(SpringModel model)
        {
            List<SpringModel> allSprings = Spring_GetAll();

            if (allSprings.Count > 0) model.Id = allSprings.OrderByDescending(x => x.Id).First().Id + 1;

            else model.Id = 1;

            allSprings.Add(model);

            allSprings.SaveSpringsToFile();

        }

        public static void CreateBearing(BearingModel model)
        {
            List<BearingModel> allBearings = Bearing_GetAll();

            if (allBearings.Count > 0) model.Id = allBearings.OrderByDescending(x => x.Id).First().Id + 1;

            else model.Id = 1;

            allBearings.Add(model);

            allBearings.SaveBearingsToFile();
        }

        public static void CreateSleeve(SleeveModel model)
        {
            List<SleeveModel> allSleeves = Sleeve_GetAll();

            if (allSleeves.Count > 0) model.Id = allSleeves.OrderByDescending(x => x.Id).First().Id + 1;

            else model.Id = 1;

            allSleeves.Add(model);

            allSleeves.SaveSleevesToFile();
        }

        public static void CreateCounterSleeve(CounterSleeveModel model)
        {
            List<CounterSleeveModel> allCounterSleeves = CounterSleeve_GetAll();

            if (allCounterSleeves.Count > 0) model.Id = allCounterSleeves.OrderByDescending(x => x.Id).First().Id + 1;

            else model.Id = 1;

            allCounterSleeves.Add(model);

            allCounterSleeves.SaveCounterSleevesToFile();
        }

        public static void CreateCompressor(CompressorModel model)
        {
            List<CompressorModel> allCompressors = Compressor_GetAll();

            if (allCompressors.Count > 0) model.Id = allCompressors.OrderByDescending(x => x.Id).First().Id + 1;

            else model.Id = 1;

            allCompressors.Add(model);

            allCompressors.SaveCompressorsToFile();
        }

        public static void CreateFixationPoint(FixationPointModel model)
        {
            List<FixationPointModel> allFixationPoints = FixationPoint_GetAll();

            if (allFixationPoints.Count > 0) model.Id = allFixationPoints.OrderByDescending(x => x.Id).First().Id + 1;

            else model.Id = 1;

            allFixationPoints.Add(model);

            allFixationPoints.SaveFixationPointsToFile();
        }

        public static void CreatePartSet(PartSetModel model)
        {
            List<PartSetModel> allPartSets = PartSet_GetAll();

            if (allPartSets.Count > 0) model.Id = allPartSets.OrderByDescending(x => x.Id).First().Id + 1;

            else model.Id = 1;

            allPartSets.Add(model);

            allPartSets.SavePartSetsToFile();
        }

        public static void CreateCalculation(CalculationsModel model)
        {

            CreateCompressor(model.Compressor);

            foreach (FixationPointModel point in model.Points)
            {
                CreateFixationPoint(point);
            }

            List<CalculationsModel> allCalculations = Calculations_GetAll();

            if (allCalculations.Count > 0) model.Id = allCalculations.OrderByDescending(x => x.Id).First().Id + 1;

            else model.Id = 1;

            allCalculations.Add(model);

            allCalculations.SaveCalculationsToFile();
        }

        public static List<SpringModel> Spring_GetAll()
        {
            return GlobalConfig.SpringFile.FullFilePath().LoadFile().ConvertTextToSpring();
        }

        public static List<BearingModel> Bearing_GetAll()
        {
            return GlobalConfig.BearingFile.FullFilePath().LoadFile().ConvertTextToBearing();
        }

        public static List<SleeveModel> Sleeve_GetAll()
        {
            return GlobalConfig.SleeveFile.FullFilePath().LoadFile().ConvertTextToSleeve();
        }

        public static List<CounterSleeveModel> CounterSleeve_GetAll()
        {
            return GlobalConfig.CounterSleeveFile.FullFilePath().LoadFile().ConvertTextToCounterSleeve();
        }

        public static List<CompressorModel> Compressor_GetAll()
        {
            return GlobalConfig.CompressorFile.FullFilePath().LoadFile().ConvertTextToCompressor();
        }

        public static List<PartSetModel> PartSet_GetAll()
        {
            return GlobalConfig.PartSetFile.FullFilePath().LoadFile().ConvertTextToPartSet();
        }

        public static List<FixationPointModel> FixationPoint_GetAll()
        {
            return GlobalConfig.FixationPointFile.FullFilePath().LoadFile().ConvertTextToFixationPoint();
        }

        public static List<CalculationsModel> Calculations_GetAll()
        {
            return GlobalConfig.CalculationFile.FullFilePath().LoadFile().ConvertTextToCalculation();
        }

    }
}
