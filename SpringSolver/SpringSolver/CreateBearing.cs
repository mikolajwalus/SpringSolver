using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpringSolverLibrary;
using SpringSolverLibrary.TextConnection;
using SpringSolverLibrary.InterfaceRequestors;

namespace SpringSolver
{
    public partial class CreateBearing : Form
    {
        List<BearingModel> allBearings = new List<BearingModel>();
        BearingModel selectedBearing = new BearingModel();
        IBearingRequestor callingForm;

        public CreateBearing(IBearingRequestor caller)
        {
            InitializeComponent();
            callingForm = caller;
            allBearings = TextConnector.Bearing_GetAll();
            UpdateData();
            WireUpLists();
        }

        private void UpdateData()
        {
            allBearingsComboBox.DataSource = null;
            allBearingsComboBox.DataSource = allBearings;
            allBearingsComboBox.DisplayMember = "Number";
        }

        private void WireUpLists()
        {

            selBearingLenghtValue.Text = $"{selectedBearing.Length.ToString()} +//- {selectedBearing.LengthTolerance.ToString()}";
            selBearingStepValue.Text = $"{selectedBearing.Step.ToString()} +//- {selectedBearing.StepTolerance.ToString()}";

        }


        private bool ValidateData()
        {

            double result = 0;
            bool isValid = true;

            if (bearingNumberTextBox.Text == null)
            {
                MessageBox.Show("You didn't entered data as spring number!", "Invalid input error");
                isValid = false;
            }

            if (!double.TryParse(bearingLengthTextBox.Text, out result))
            {
                MessageBox.Show("You entered wrong data as bearing lenght!", "Invalid input error");
                isValid = false;
            }

            if (!double.TryParse(bearingLengthToleranceTextBox.Text, out result))
            {
                MessageBox.Show("You entered wrong data as bearing lenght tolerance!", "Invalid input error");
                isValid = false;
            }

            if (!double.TryParse(bearingStepTextBox.Text, out result))
            {
                MessageBox.Show("You entered wrong data as bearing step!", "Invalid input error");
                isValid = false;
            }

            if (!double.TryParse(bearingStepToleranceTextBox.Text, out result))
            {
                MessageBox.Show("You entered wrong data as bearing step tolerance!", "Invalid input error");
                isValid = false;
            }

            return isValid;
        }

        private void addNewBearingButton_Click(object sender, EventArgs e)
        {
            if (!ValidateData()) return;
            BearingModel model = new BearingModel()
            {
                Number = bearingNumberTextBox.Text,
                Length = double.Parse(bearingLengthTextBox.Text),
                LengthTolerance = double.Parse(bearingLengthToleranceTextBox.Text),
                Step = double.Parse(bearingStepTextBox.Text),
                StepTolerance = double.Parse(bearingStepToleranceTextBox.Text)
            };
            TextConnector.CreateBearing(model);

            allBearings.Add(model);

            UpdateData();

            callingForm.NewBearingCreated(model);
        }

        private void allBearingsComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedBearing = (BearingModel)allBearingsComboBox.SelectedItem;
            WireUpLists();
        }
    }
}
