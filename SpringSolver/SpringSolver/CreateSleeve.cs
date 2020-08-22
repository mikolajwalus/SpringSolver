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
using SpringSolverLibrary.InterfaceRequestors;
using SpringSolverLibrary.TextConnection;

namespace SpringSolver
{
    public partial class CreateSleeve : Form
    {
        List<SleeveModel> allSleeves = new List<SleeveModel>();
        SleeveModel selectedSleeve = new SleeveModel();
        ISleeveRequestor callingForm;

        public CreateSleeve(ISleeveRequestor caller)
        {
            InitializeComponent();
            callingForm = caller;
            allSleeves = TextConnector.Sleeve_GetAll();

            UpdateData();
            WireUpLists();
        }

        private void UpdateData()
        {
            allSleevsComboBox.DataSource = null;
            allSleevsComboBox.DataSource = allSleeves;
            allSleevsComboBox.DisplayMember = "Number";
        }
        private void WireUpLists()
        {

            selSleeveLenghtValue.Text = $"{selectedSleeve.Length.ToString()} +//- {selectedSleeve.LengthTolerance.ToString()}";
            selSleeveStepHeightValue.Text = $"{selectedSleeve.StepHeight.ToString()} +//- {selectedSleeve.StepHeightTolerance.ToString()}";

        }


        private bool ValidateData()
        {

            double result = 0;
            bool isValid = true;

            if (sleeveNumberTextBox.Text == null)
            {
                MessageBox.Show("You didn't entered data as sleeve number!", "Invalid input error");
                isValid = false;
            }

            if (!double.TryParse(sleeveLengthTextBox.Text, out result))
            {
                MessageBox.Show("You entered wrong data as sleeve lenght!", "Invalid input error");
                isValid = false;
            }

            if (!double.TryParse(sleeveLenghtToleranceTextBox.Text, out result))
            {
                MessageBox.Show("You entered wrong data as sleeve lenght tolerance!", "Invalid input error");
                isValid = false;
            }

            if (!double.TryParse(sleeveStepHeightTextBox.Text, out result))
            {
                MessageBox.Show("You entered wrong data as sleeve step!", "Invalid input error");
                isValid = false;
            }

            if (!double.TryParse(sleeveStepHeightToleranceTextBox.Text, out result))
            {
                MessageBox.Show("You entered wrong data as sleeve step tolerance!", "Invalid input error");
                isValid = false;
            }

            return isValid;
        }

        private void allSleevsComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedSleeve = (SleeveModel)allSleevsComboBox.SelectedItem;
            WireUpLists();
        }

        private void addNewSleeveButton_Click(object sender, EventArgs e)
        {
            if (!ValidateData()) return;
            SleeveModel model = new SleeveModel()
            {
                Number = sleeveNumberTextBox.Text,
                Length = double.Parse(sleeveLengthTextBox.Text),
                LengthTolerance = double.Parse(sleeveLenghtToleranceTextBox.Text),
                StepHeight = double.Parse(sleeveStepHeightTextBox.Text),
                StepHeightTolerance = double.Parse(sleeveStepHeightToleranceTextBox.Text)
            };

            TextConnector.CreateSleeve(model);

            allSleeves.Add(model);

            UpdateData();

            callingForm.NewSleeveCreated(model);
        }

    }
}
