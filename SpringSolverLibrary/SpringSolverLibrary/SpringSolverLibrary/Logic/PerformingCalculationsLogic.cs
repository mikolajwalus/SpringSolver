using SpringSolverLibrary.Models;
using SpringSolverLibrary.TextConnection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SpringSolverLibrary.Logic
{
    public static class PerformingCalculationsLogic
    {

        public static void PrepareCalculationsSet(this CalculationsModel model, List<SolutionModel> solutions )
        {
            CalculationsModel calculation = model;
            List<SpringModel> allSprings = TextConnector.Spring_GetAll();

            List<List<SpringModel>> allSetups = new List<List<SpringModel>>();

            allSetups = CreateAllCombinations(calculation.AllowedSpringNumber, allSprings, new List<SpringModel>() );

            int springNumber = calculation.CountSpringNumber();
            List<List<SpringModel>> allCombinations = new List<List<SpringModel>>();

            foreach (List<SpringModel> setup in allSetups)
            {
                allCombinations.AddRange(CreateAllCombinations(springNumber, setup, new List<SpringModel>())); 
            }

            //List<SolutionModel> solutions = new List<SolutionModel>();

            foreach (List<SpringModel> springSetup in allCombinations)
            {
                solutions.Add(new SolutionModel(calculation, springSetup));
            }

            solutions = solutions.Distinct().ToList();

            foreach( SolutionModel solution in solutions )
            {
                solution.SimulateSolution();
            }

            //objListOrder.Sort((x, y) => x.OrderDate.CompareTo(y.OrderDate));

            //solutions.Sort((x, y) => x.Result.CompareTo(y.Result));

        }

        public static void SelectSolutions(this List<SolutionModel> input, List<SolutionModel> results)
        {
            int resultsNumber = 5;
            double result = 0;

            List<SolutionModel> models = input.OrderBy(x => x.Result).ToList();

            foreach (SolutionModel model in models)
            {
                if (resultsNumber == 0) break;
                if (model.Result != result)
                {
                    results.Add(model);
                    resultsNumber--;
                    result = model.Result;
                }
            }
        }

        private static List<List<T>> CreateAllCombinations<T>(int positions, List<T> elements, List<T> body)
        {

            List<List<T>> output = new List<List<T>>();
            List<T> parameter = new List<T>();
            parameter.AddRange(body);

            foreach (T member in elements)
            {
                parameter.Add(member);
                if (positions > 1)
                {
                    output.AddRange(CreateAllCombinations(positions - 1, elements, parameter));
                }
                else
                {
                    output.Add(new List<T>(parameter));
                }
                parameter.RemoveAt(parameter.Count - 1);
            }

            return output;
        }

        private static int CountSpringNumber(this CalculationsModel model)
        {
            int output = 0;
            foreach (FixationPointModel point in model.Points)
            {
                if (point.UpperSpringBool) output++;
                if (point.LowerSpringBool) output++;
            }

            return output;
        }

    }
}