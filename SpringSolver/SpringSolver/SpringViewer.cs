using SpringSolverLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpringSolverLibrary.TextConnection;

namespace SpringSolver
{
    public partial class SpringViewer : Form
    {
        List<SpringModel> allSprings = new List<SpringModel>();
        SpringModel selectedSpring = new SpringModel();


        public SpringViewer()
        {
            InitializeComponent();
            allSprings = TextConnector.Spring_GetAll();
            UpdateData();
            WireUpLists();
        }
        private void UpdateData()
        {
            allSpringsComboBox.DataSource = null;
            allSpringsComboBox.DataSource = allSprings;
            allSpringsComboBox.DisplayMember = "Number";
        }
        private void WireUpLists()
        {
            selSpringLenghtValue.Text = selectedSpring.Length.ToString();
            selSpringRateValue.Text = selectedSpring.Rate.ToString();
            selSpringForceValue.Text = selectedSpring.Force.ToString();
            selSpringForceToleranceValue.Text = selectedSpring.ForceTolerance.ToString();

        }

        private void allSpringsComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedSpring = (SpringModel)allSpringsComboBox.SelectedItem;
            WireUpLists();
        }

        private void addNewSpringButton_Click(object sender, EventArgs e)
        {
            if (!ValidateData()) return;
            SpringModel model = new SpringModel(){
                Number = springNumberTextBox.Text,
                Force = double.Parse(springForceTextBox.Text),
                ForceTolerance = double.Parse(springForceToleranceTextBox.Text),
                Length = double.Parse(springLenghTextBox.Text),
                Rate = double.Parse(springRateTextBox.Text) };
            TextConnector.CreateSpring(model);
            allSprings.Add(model);
            UpdateData();
        }
        private bool ValidateData()
        {
            //TODO - Validate all creation forms -> add non negative number filter
            //TODO - Validation check all creation forms < or <= 0 ?? to check
            //TODO - Change name or number validation method .lenght > 0 instead of == null, check all creation forms

            double result = 0;
            bool isValid = true;

            if (springNumberTextBox.Text.Length == 0)
            {
                MessageBox.Show("You didn't entered data as spring number!","Invalid input error");
                isValid = false;
            }

            if (!double.TryParse(springLenghTextBox.Text, out result))
            {
                MessageBox.Show("You entered wrong data as spring lenght!", "Invalid input error");
                isValid = false;
            }

            if (!double.TryParse(springRateTextBox.Text, out result))
            {
                MessageBox.Show("You entered wrong data as spring rate!", "Invalid input error");
                isValid = false;
            }

            if (!double.TryParse(springForceTextBox.Text, out result))
            {
                MessageBox.Show("You entered wrong data as spring force!", "Invalid input error");
                isValid = false;
            }

            if (!double.TryParse(springForceToleranceTextBox.Text, out result))
            {
                MessageBox.Show("You entered wrong data as spring force tolerance!", "Invalid input error");
                isValid = false;
            }

            return isValid;
        }
    }
}
