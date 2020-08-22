using SpringSolverLibrary;
using SpringSolverLibrary.TextConnection;
using SpringSolverLibrary.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpringSolverLibrary.Models;

namespace SpringSolver
{
    public partial class CalculationsViewer : Form
    {
        List<CalculationsModel> calculations = new List<CalculationsModel>();

        public CalculationsViewer()
        {
            calculations = TextConnector.Calculations_GetAll();

            InitializeComponent();

            WireUpLists();
        }

        private void WireUpLists()
        {
            calculationsComboBox.DataSource = null;

            calculationsComboBox.DataSource = calculations;
            calculationsComboBox.DisplayMember = "Name";


        }

        private void loadCalculationsButton_Click(object sender, EventArgs e)
        {
            if(calculationsComboBox.SelectedItem == null)
            {
                MessageBox.Show("You dind't choose any calculation to perform!");
                return;
            }

            CalculationsModel chosenCalculation = new CalculationsModel();

            chosenCalculation = (CalculationsModel)calculationsComboBox.SelectedItem;

            List<SolutionModel> solutions = new List<SolutionModel>();

            chosenCalculation.PrepareCalculationsSet(solutions);

            List<SolutionModel> results = new List<SolutionModel>();

            solutions.SelectSolutions(results);

            ResultsViewer frm = new ResultsViewer(results);
            frm.Show();
        }

        private void createCalculationsButton_Click(object sender, EventArgs e)
        {
            CreateCalculations frm = new CreateCalculations();

            frm.ShowDialog();

            this.Close();

        }
    }
}
