using SpringSolverLibrary;
using SpringSolverLibrary.InterfaceRequestors;
using SpringSolverLibrary.Logic;
using SpringSolverLibrary.Models;
using SpringSolverLibrary.TextConnection;
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
    public partial class CreateCalculations : Form, IPartSetRequestor
    {
        CalculationsModel calculation = new CalculationsModel();

        CompressorModel compressorModel = new CompressorModel();

        List<FixationPointModel> fixationPoints = new List<FixationPointModel>();

        List<PartSetModel> partSetOne = TextConnector.PartSet_GetAll();
        List<PartSetModel> partSetTwo = TextConnector.PartSet_GetAll();
        List<PartSetModel> partSetThree = TextConnector.PartSet_GetAll();
        List<PartSetModel> partSetFour = TextConnector.PartSet_GetAll();

        bool fourthPointVisibility = true;

        List<string> allowedSpringNumber = new List<string>() { "1", "2", "3", "4" } ;

        public CreateCalculations()
        {
            InitializeComponent();
            UpdateData();

        }

        private void UpdateData()
        {


            otherPartsSizeOneComboBox.DataSource = null;
            otherPartsSizeOneComboBox.DataSource = partSetOne;
            otherPartsSizeOneComboBox.DisplayMember = "Name";

            otherPartsSizeTwoComboBox.DataSource = null;
            otherPartsSizeTwoComboBox.DataSource = partSetTwo;
            otherPartsSizeTwoComboBox.DisplayMember = "Name";

            otherPartsSizeThreeComboBox.DataSource = null;
            otherPartsSizeThreeComboBox.DataSource = partSetThree;
            otherPartsSizeThreeComboBox.DisplayMember = "Name";

            otherPartsSizeFourComboBox.DataSource = null;
            otherPartsSizeFourComboBox.DataSource = partSetFour;
            otherPartsSizeFourComboBox.DisplayMember = "Name";

            allowedSpringNumberComboBox.DataSource = null;
            allowedSpringNumberComboBox.DataSource = allowedSpringNumber;
        }

        private bool ValidateData()
        {
            bool isValid = true;

            isValid &= ValidateName();

            isValid &=  ValidatePointOne();

            isValid &= ValidatePointTwo();

            isValid &= ValidatePointThree();

            if(fourthPointVisibility == true) isValid &= ValidatePointFour();

            isValid &= ValidateCompressorData();

            return isValid;
        }

        private bool ValidateName()
        {
            bool isValid = true;

            if (calculationNameTextBox.Text.Length == 0)
            {
                MessageBox.Show("You didn't entered data as solution name!", "Invalid input error");
                isValid = false;
            }

            return isValid;
        }

        private bool ValidatePointOne()
        {
            double result = 0;
            bool isValid = true;

            if (!double.TryParse(pointOnePositionXTextBox.Text, out result) )
            {
                MessageBox.Show("You entered wrong data as point data position in Point 1!", "Invalid input error");
                isValid = false;
            }

            if (!double.TryParse(pointOnePositionYTextBox.Text, out result) )
            {
                MessageBox.Show("You entered wrong data as point data position in Point 1!", "Invalid input error");
                isValid = false;
            }

            if (lowerSpringOneChceckBox.Checked == false && upperSpringOneCheckBox.Checked == false)
            {
                MessageBox.Show("You didn't choose any spring in Point 1!", "Invalid input error");
                isValid = false;
            }

            if (otherPartsSizeOneComboBox.SelectedItem == null)
            {
                MessageBox.Show("You didn't choose other parts size in Point 1!", "Invalid input error");
                isValid = false;
            }

            return isValid;
        }

        private bool ValidatePointTwo()
        {
            double result = 0;
            bool isValid = true;

            if (!double.TryParse(pointTwoPositionXTextBox.Text, out result) )
            {
                MessageBox.Show("You entered wrong data as point data position in Point 2!", "Invalid input error");
                isValid = false;
            }

            if (!double.TryParse(pointTwoPositionYTextBox.Text, out result) )
            {
                MessageBox.Show("You entered wrong data as point data position in Point 2!", "Invalid input error");
                isValid = false;
            }

            if (lowerSpringTwoChceckBox.Checked == false && upperSpringTwoCheckBox.Checked == false)
            {
                MessageBox.Show("You didn't choose any spring in Point 2!", "Invalid input error");
                isValid = false;
            }

            if (otherPartsSizeTwoComboBox.SelectedItem == null)
            {
                MessageBox.Show("You didn't choose other parts size in Point 2!", "Invalid input error");
                isValid = false;
            }

            return isValid;
        }

        private bool ValidatePointThree()
        {
            double result = 0;
            bool isValid = true;

            if (!double.TryParse(pointThreePositionXTextBox.Text, out result) )
            {
                MessageBox.Show("You entered wrong data as point data position in Point 3!", "Invalid input error");
                isValid = false;
            }

            if (!double.TryParse(pointThreePositionYTextBox.Text, out result) )
            {
                MessageBox.Show("You entered wrong data as point data position in Point 3!", "Invalid input error");
                isValid = false;
            }

            if (lowerSpringThreeChceckBox.Checked == false && upperSpringThreeCheckBox.Checked == false)
            {
                MessageBox.Show("You didn't choose any spring in Point 3!", "Invalid input error");
                isValid = false;
            }

            if (otherPartsSizeThreeComboBox.SelectedItem == null)
            {
                MessageBox.Show("You didn't choose other parts size in Point 3!", "Invalid input error");
                isValid = false;
            }

            return isValid;
        }

        private bool ValidatePointFour()
        {
            double result = 0;
            bool isValid = true;

            if (!double.TryParse(pointFourPositionXTextBox.Text, out result) )
            {
                MessageBox.Show("You entered wrong data as point data position in Point 4!", "Invalid input error");
                isValid = false;
            }

            if (!double.TryParse(pointFourPositionYTextBox.Text, out result) )
            {
                MessageBox.Show("You entered wrong data as point data position in Point 4!", "Invalid input error");
                isValid = false;
            }

            if (lowerSpringFourChceckBox.Checked == false && upperSpringFourCheckBox.Checked == false)
            {
                MessageBox.Show("You didn't choose any spring in Point 4!", "Invalid input error");
                isValid = false;
            }

            if (otherPartsSizeFourComboBox.SelectedItem == null)
            {
                MessageBox.Show("You didn't choose other parts size in Point 4!", "Invalid input error");
                isValid = false;
            }

            return isValid;
        }

        private bool ValidateCompressorData()
        {
            double result = 0;
            bool isValid = true;

            if (!double.TryParse(compressorMassTextBox.Text, out result) || result <= 0)
            {
                MessageBox.Show("You entered wrong data as compressor mass!", "Invalid input error");
                isValid = false;
            }

            if (!double.TryParse(xCorrectionTextBox.Text, out result) || result < 0)
            {
                MessageBox.Show("You entered wrong data as x correction!", "Invalid input error");
                isValid = false;
            }

            if (!double.TryParse(yCorrectionTextBox.Text, out result) || result < 0)
            {
                MessageBox.Show("You entered wrong data as y correction!", "Invalid input error");
                isValid = false;
            }

            if (!double.TryParse(cogDistToPistXTextBox.Text, out result) || result < 0)
            {
                MessageBox.Show("You entered wrong data as distance to piston!", "Invalid input error");
                isValid = false;
            }

            if (!double.TryParse(cogDistToIzolZTextBox.Text, out result) || result < 0)
            {
                MessageBox.Show("You entered wrong data as distance to izolator!", "Invalid input error");
                isValid = false;
            }

            return isValid;
        }

        public void NewPartSetCreated(PartSetModel model)
        {
            partSetOne.Add(model);
            partSetTwo.Add(model);
            partSetThree.Add(model);
            partSetFour.Add(model);

            UpdateData();
        }

        private void fourFixationPointsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (fourFixationPointsRadioButton.Checked == true)
            {
                allowedSpringNumber.Add("4");
                fourthPointVisibility = true;
                pointFourGroupBox.Visible = fourthPointVisibility;

                UpdateData(); 
            }
        }

        private void threeFixationPointsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (threeFixationPointsRadioButton.Checked == true)
            {
                allowedSpringNumber.Remove("4");
                fourthPointVisibility = false;
                pointFourGroupBox.Visible = fourthPointVisibility;

                UpdateData(); 
            }
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            if (!ValidateData()) return;

            fixationPoints.Clear();

            calculation = new CalculationsModel();

            FixationPointModel fixationPointOne = new FixationPointModel();
            FixationPointModel fixationPointTwo = new FixationPointModel();
            FixationPointModel fixationPointThree = new FixationPointModel();
            FixationPointModel fixationPointFour = new FixationPointModel() { Chosen = false};

            CompressorModel compressorModel = new CompressorModel();

            fixationPointOne.XPosition = double.Parse(pointOnePositionXTextBox.Text);
            fixationPointOne.YPosition = double.Parse(pointOnePositionYTextBox.Text);
            fixationPointOne.UpperSpringBool = upperSpringOneCheckBox.Checked;
            fixationPointOne.LowerSpringBool = lowerSpringOneChceckBox.Checked;
            fixationPointOne.Parts = (PartSetModel)otherPartsSizeOneComboBox.SelectedItem;
            fixationPointOne.Chosen = true;

            fixationPointTwo.XPosition = double.Parse(pointTwoPositionXTextBox.Text);
            fixationPointTwo.YPosition = double.Parse(pointTwoPositionYTextBox.Text);
            fixationPointTwo.UpperSpringBool = upperSpringTwoCheckBox.Checked;
            fixationPointTwo.LowerSpringBool = lowerSpringTwoChceckBox.Checked;
            fixationPointTwo.Parts = (PartSetModel)otherPartsSizeTwoComboBox.SelectedItem;
            fixationPointTwo.Chosen = true;


            fixationPointThree.XPosition = double.Parse(pointThreePositionXTextBox.Text);
            fixationPointThree.YPosition = double.Parse(pointThreePositionYTextBox.Text);
            fixationPointThree.UpperSpringBool = upperSpringThreeCheckBox.Checked;
            fixationPointThree.LowerSpringBool = lowerSpringThreeChceckBox.Checked;
            fixationPointThree.Parts = (PartSetModel)otherPartsSizeTwoComboBox.SelectedItem;
            fixationPointThree.Chosen = true;


            if (fourFixationPointsRadioButton.Checked == true)
            {
                fixationPointFour.XPosition = double.Parse(pointFourPositionXTextBox.Text);
                fixationPointFour.YPosition = double.Parse(pointFourPositionYTextBox.Text);
                fixationPointFour.UpperSpringBool = upperSpringFourCheckBox.Checked;
                fixationPointFour.LowerSpringBool = lowerSpringFourChceckBox.Checked;
                fixationPointFour.Parts = (PartSetModel)otherPartsSizeTwoComboBox.SelectedItem;
                fixationPointFour.Chosen = true; 
            }

            compressorModel.Mass = double.Parse(compressorMassTextBox.Text);

            compressorModel.XCorrection = double.Parse(xCorrectionTextBox.Text);
            compressorModel.YCorrection = double.Parse(yCorrectionTextBox.Text);

            compressorModel.CogDistToPistX = double.Parse(cogDistToPistXTextBox.Text);
            compressorModel.CogDistToIzolZ = double.Parse(cogDistToIzolZTextBox.Text);

            fixationPoints.Add(fixationPointOne);
            fixationPoints.Add(fixationPointTwo);
            fixationPoints.Add(fixationPointThree);
            if(fourFixationPointsRadioButton.Checked == true) fixationPoints.Add(fixationPointFour);

            calculation.Name = calculationNameTextBox.Text;
            calculation.Compressor = compressorModel;
            calculation.Points = fixationPoints;
            calculation.AllowedSpringNumber = int.Parse((string)allowedSpringNumberComboBox.SelectedItem);

            TextConnector.CreateCalculation(calculation);

            List<SolutionModel> solutions = new List<SolutionModel>();

            calculation.PrepareCalculationsSet(solutions);

            List<SolutionModel> results = new List<SolutionModel>();

            solutions.SelectSolutions(results);
            
            ResultsViewer frm = new ResultsViewer(results);
            frm.Show();
        }

        private void otherPartsLibraryButton_Click(object sender, EventArgs e)
        {
            OtherPartsViewer frm = new OtherPartsViewer(this);
            frm.Show();
        }

        private void springsLibraryButton_Click(object sender, EventArgs e)
        {
            SpringViewer frm = new SpringViewer();
            frm.Show();
        }

    }
}
