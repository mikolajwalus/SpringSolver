using SpringSolverLibrary;
using SpringSolverLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpringSolver
{
    public partial class ResultsViewer : Form
    {
        private bool fourthPoint;

        List<SolutionModel> solutions;

        BindingList<int> solutionNumbers = new BindingList<int>();

        public ResultsViewer(List<SolutionModel> results)
        {
            solutions = results;

            CheckPointsQuantity(solutions.First());

            InitializeComponent();

            pointFourGroupBox.Visible = fourthPoint;

            CheckSolutionQuantity();

            WireUpComboBox();


        }

        private void WireUpResults()
        {
            if (chooseSolutionComboBox.SelectedItem == null) return;

            int solutionNumber = (int)chooseSolutionComboBox.SelectedItem - 1;


            springOneNumberValue.Text = solutions[solutionNumber].Points[0].Springs[1].Number;

            topGapOneValue.Text = Math.Round(solutions[solutionNumber].Points[0].NominalTopGap, 3).ToString();

            bottomGapOneValue.Text = Math.Round(solutions[solutionNumber].Points[0].NominalBottomGap, 3).ToString();


            springTwoNumberValue.Text = solutions[solutionNumber].Points[1].Springs[1].Number;

            topGapTwoValue.Text = Math.Round(solutions[solutionNumber].Points[1].NominalTopGap, 3).ToString();

            bottomGapTwoValue.Text = Math.Round(solutions[solutionNumber].Points[1].NominalBottomGap, 3).ToString();


            springThreeNumberValue.Text = solutions[solutionNumber].Points[2].Springs[1].Number;

            topGapThreeValue.Text = Math.Round(solutions[solutionNumber].Points[2].NominalTopGap, 3).ToString();

            bottomGapThreeValue.Text = Math.Round(solutions[solutionNumber].Points[2].NominalBottomGap, 3).ToString();

            if (fourthPoint)
            {

                springFourNumberValue.Text = solutions[solutionNumber].Points[3].Springs[1].Number;

                topGapFourValue.Text = Math.Round(solutions[solutionNumber].Points[3].NominalTopGap, 3).ToString();

                bottomGapFourValue.Text = Math.Round(solutions[solutionNumber].Points[3].NominalBottomGap, 3).ToString(); 

            }
        }

        private void WireUpComboBox()
        {
            chooseSolutionComboBox.DataSource = null;
            chooseSolutionComboBox.DataSource = solutionNumbers;
        }

        private void CheckSolutionQuantity()
        {
            int param = 1;
            foreach (SolutionModel item in solutions)
            {
                solutionNumbers.Add(param);
                param++;
            }
        }

        private void CheckPointsQuantity(SolutionModel model)
        {
            fourthPoint = model.Points[3].Chosen;
        }

        private void chooseSolutionComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            WireUpResults();
        }
    }
}
