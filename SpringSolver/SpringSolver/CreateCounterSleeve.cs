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
    public partial class CreateCounterSleeve : Form
    {
        List<CounterSleeveModel> allCounterSleeves = new List<CounterSleeveModel>();
        CounterSleeveModel selectedCounterSleeve = new CounterSleeveModel();
        ICounterSleeveRequestor callingForm;

        public CreateCounterSleeve(ICounterSleeveRequestor caller)
        {
            InitializeComponent();
            callingForm = caller;
            allCounterSleeves = TextConnector.CounterSleeve_GetAll();
            UpdateData();
            WireUpLists();
        }

        private void UpdateData()
        {
            allCounterSleevsComboBox.DataSource = null;
            allCounterSleevsComboBox.DataSource = allCounterSleeves;
            allCounterSleevsComboBox.DisplayMember = "Number";
        }

        private void WireUpLists()
        {

            selCounterSleeveLenghtOneValue.Text = $"{selectedCounterSleeve.LengthOne.ToString()} +//- {selectedCounterSleeve.LengthOneTolerance.ToString()}";
            selCounterSleeveLenghtTwoValue.Text = $"{selectedCounterSleeve.LengthTwo.ToString()} +//- {selectedCounterSleeve.LengthTwoTolerance.ToString()}";

        }


        private bool ValidateData()
        {

            double result = 0;
            bool isValid = true;

            if (counterSleeveNumberTextBox.Text == null)
            {
                MessageBox.Show("You didn't entered data as counter sleeve number!", "Invalid input error");
                isValid = false;
            }

            if (!double.TryParse(counterSleeveLenghtOneTextBox.Text, out result))
            {
                MessageBox.Show("You entered wrong data as counter sleeve lenght one!", "Invalid input error");
                isValid = false;
            }

            if (!double.TryParse(counterSleeveLenghtOneToleranceTextBox.Text, out result))
            {
                MessageBox.Show("You entered wrong data as counter sleeve lenght one tolerance!", "Invalid input error");
                isValid = false;
            }

            if (!double.TryParse(counterSleeveLenghtTwoTextBox.Text, out result))
            {
                MessageBox.Show("You entered wrong data as counter sleeve lenght two!", "Invalid input error");
                isValid = false;
            }

            if (!double.TryParse(counterSleeveLenghtTwoToleranceTextBox.Text, out result))
            {
                MessageBox.Show("You entered wrong data as counter sleeve lenght two tolerance!", "Invalid input error");
                isValid = false;
            }

            return isValid;
        }

        private void allCounterSleevsComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedCounterSleeve = (CounterSleeveModel)allCounterSleevsComboBox.SelectedItem;
            WireUpLists();
        }

        private void addNewSpringButton_Click(object sender, EventArgs e)
        {
            if (!ValidateData()) return;
            CounterSleeveModel model = new CounterSleeveModel()
            {
                Number = counterSleeveNumberTextBox.Text,
                LengthOne = double.Parse(counterSleeveLenghtOneTextBox.Text),
                LengthOneTolerance = double.Parse(counterSleeveLenghtOneToleranceTextBox.Text),
                LengthTwo = double.Parse(counterSleeveLenghtTwoTextBox.Text),
                LengthTwoTolerance = double.Parse(counterSleeveLenghtTwoToleranceTextBox.Text)
            };
            TextConnector.CreateCounterSleeve(model);

            allCounterSleeves.Add(model);

            UpdateData();

            callingForm.NewCounterSleeveCreated(model);
        }
    }
}
