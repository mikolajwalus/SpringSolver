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
    public partial class OtherPartsViewer : Form, IBearingRequestor, ISleeveRequestor, ICounterSleeveRequestor
    {
        //TODO - delete all existing part sets and make standart set regarding excel
        List<PartSetModel> allPartSets = new List<PartSetModel>();
        PartSetModel selectedPartSet = new PartSetModel();
        List<SleeveModel> allSleeves = new List<SleeveModel>();
        List<CounterSleeveModel> allCounterSleeves = new List<CounterSleeveModel>();
        List<BearingModel> allBearings = new List<BearingModel>();
        IPartSetRequestor callingForm;

        public OtherPartsViewer(IPartSetRequestor caller)
        {
            InitializeComponent();
            callingForm = caller;
            allPartSets = TextConnector.PartSet_GetAll();
            allSleeves = TextConnector.Sleeve_GetAll();
            allCounterSleeves = TextConnector.CounterSleeve_GetAll();
            allBearings = TextConnector.Bearing_GetAll();
            UpdatePartSetList();
            UpdateNewPartSetGroupBoxes();
            if(selectedPartSet.Id != 0) WireUpLists();
        }

        private void UpdatePartSetList()
        {
            selectExistingPartsSetComboBox.DataSource = null;
            selectExistingPartsSetComboBox.DataSource = allPartSets;
            selectExistingPartsSetComboBox.DisplayMember = "Name";
        }

        private void UpdateNewPartSetGroupBoxes()
        {
            newSetNameTextBox.Text = "";

            newSetSleeveComboBox.DataSource = null;
            newSetSleeveComboBox.DataSource = allSleeves;
            newSetSleeveComboBox.DisplayMember = "Number";

            newSetCounterSleeveComboBox.DataSource = null;
            newSetCounterSleeveComboBox.DataSource = allCounterSleeves;
            newSetCounterSleeveComboBox.DisplayMember = "Number";

            newSetBearingComboBox.DataSource = null;
            newSetBearingComboBox.DataSource = allBearings;
            newSetBearingComboBox.DisplayMember = "Number";

        }

        private void WireUpLists()
        {

            sleeveNumberValue.Text = $"{selectedPartSet.Sleeve.Number}";
            sleeveLengthValue.Text = $"{selectedPartSet.Sleeve.Length.ToString()} +//- {selectedPartSet.Sleeve.LengthTolerance.ToString()}";
            sleeveStepHeightValue.Text = $"{selectedPartSet.Sleeve.StepHeight.ToString()} +//- {selectedPartSet.Sleeve.StepHeightTolerance.ToString()}";

            counterSleeveNumberValue.Text = $"{selectedPartSet.CounterSleeve.Number}";
            counterSleeveLengthOneValue.Text = $"{selectedPartSet.CounterSleeve.LengthOne.ToString()} +//- {selectedPartSet.CounterSleeve.LengthOneTolerance.ToString()}";
            counterSleeveLengthTwoValue.Text = $"{selectedPartSet.CounterSleeve.LengthTwo.ToString()} +//- {selectedPartSet.CounterSleeve.LengthTwoTolerance.ToString()}";

            bearingNumberValue.Text = $"{selectedPartSet.Bearing.Number}";
            bearingLengthValue.Text = $"{selectedPartSet.Bearing.Length.ToString()} +//- {selectedPartSet.Bearing.LengthTolerance.ToString()}";
            bearingStepValue.Text = $"{selectedPartSet.Bearing.Step.ToString()} +//- {selectedPartSet.Bearing.StepTolerance.ToString()}";

        }

        private bool ValidateData()
        {

            bool isValid = true;

            if (newSetNameTextBox.Text == null)
            {
                MessageBox.Show("You didn't entered data as part set number!", "Invalid input error");
                isValid = false;
            }

            if (newSetSleeveComboBox.SelectedItem == null)
            {
                MessageBox.Show("You didn't choose sleeve!", "Invalid input error");
                isValid = false;
            }

            if (newSetBearingComboBox.SelectedItem == null)
            {
                MessageBox.Show("You didn't choose bearing", "Invalid input error");
                isValid = false;
            }

            if (newSetCounterSleeveComboBox.SelectedItem == null)
            {
                MessageBox.Show("You didn't choose counter sleeve!", "Invalid input error");
                isValid = false;
            }


            return isValid;
        }


        private void createNewSetButton_Click(object sender, EventArgs e)
        {
            if (!ValidateData()) return;
            PartSetModel model = new PartSetModel()
            {
                Name = newSetNameTextBox.Text,
                Sleeve = (SleeveModel)newSetSleeveComboBox.SelectedItem,
                CounterSleeve = (CounterSleeveModel)newSetCounterSleeveComboBox.SelectedItem,
                Bearing = (BearingModel)newSetBearingComboBox.SelectedItem
            };
            TextConnector.CreatePartSet(model);
            allPartSets.Add(model);
            UpdatePartSetList();
            UpdateNewPartSetGroupBoxes();
            callingForm.NewPartSetCreated(model);

        }

        private void selectExistingPartsSetComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedPartSet = (PartSetModel)selectExistingPartsSetComboBox.SelectedItem;
            WireUpLists();
        }

        public void NewBearingCreated(BearingModel model)
        {
            allBearings.Add(model);
            UpdateNewPartSetGroupBoxes();
        }

        public void NewSleeveCreated(SleeveModel model)
        {
            allSleeves.Add(model);
            UpdateNewPartSetGroupBoxes();
        }

        public void NewCounterSleeveCreated(CounterSleeveModel model)
        {
            allCounterSleeves.Add(model);
            UpdateNewPartSetGroupBoxes();
        }

        private void addNewSleeveLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateSleeve frm = new CreateSleeve(this);
            frm.Show();
        }

        private void addNewCounterSleeveLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateCounterSleeve frm = new CreateCounterSleeve(this);
            frm.Show();
        }

        private void addNewBearingLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateBearing frm = new CreateBearing(this);
            frm.Show();
        }
    }
}
