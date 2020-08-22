namespace SpringSolver
{
    partial class SpringViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.allSpringsComboBox = new System.Windows.Forms.ComboBox();
            this.addSpringGroupBox = new System.Windows.Forms.GroupBox();
            this.addNewSpringButton = new System.Windows.Forms.Button();
            this.springForceToleranceTextBox = new System.Windows.Forms.TextBox();
            this.springForceTextBox = new System.Windows.Forms.TextBox();
            this.forceToleranceLabel = new System.Windows.Forms.Label();
            this.springRateTextBox = new System.Windows.Forms.TextBox();
            this.springFoceLabel = new System.Windows.Forms.Label();
            this.springRateLabel = new System.Windows.Forms.Label();
            this.springLenghTextBox = new System.Windows.Forms.TextBox();
            this.springLenghtLabel = new System.Windows.Forms.Label();
            this.springNumberTextBox = new System.Windows.Forms.TextBox();
            this.springNumberLabel = new System.Windows.Forms.Label();
            this.selectedSpringLabel = new System.Windows.Forms.Label();
            this.selectedSpringParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.selSpringForceToleranceValue = new System.Windows.Forms.Label();
            this.selSpringForceValue = new System.Windows.Forms.Label();
            this.selSpringRateValue = new System.Windows.Forms.Label();
            this.selSpringLenghtValue = new System.Windows.Forms.Label();
            this.selSpringForceToleranceLabel = new System.Windows.Forms.Label();
            this.selSpringForceLabel = new System.Windows.Forms.Label();
            this.selSpringLenghtLabel = new System.Windows.Forms.Label();
            this.selSpringRateLabel = new System.Windows.Forms.Label();
            this.addSpringGroupBox.SuspendLayout();
            this.selectedSpringParametersGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // allSpringsComboBox
            // 
            this.allSpringsComboBox.FormattingEnabled = true;
            this.allSpringsComboBox.Location = new System.Drawing.Point(223, 12);
            this.allSpringsComboBox.Name = "allSpringsComboBox";
            this.allSpringsComboBox.Size = new System.Drawing.Size(429, 45);
            this.allSpringsComboBox.TabIndex = 0;
            this.allSpringsComboBox.SelectionChangeCommitted += new System.EventHandler(this.allSpringsComboBox_SelectionChangeCommitted);
            // 
            // addSpringGroupBox
            // 
            this.addSpringGroupBox.Controls.Add(this.addNewSpringButton);
            this.addSpringGroupBox.Controls.Add(this.springForceToleranceTextBox);
            this.addSpringGroupBox.Controls.Add(this.springForceTextBox);
            this.addSpringGroupBox.Controls.Add(this.forceToleranceLabel);
            this.addSpringGroupBox.Controls.Add(this.springRateTextBox);
            this.addSpringGroupBox.Controls.Add(this.springFoceLabel);
            this.addSpringGroupBox.Controls.Add(this.springRateLabel);
            this.addSpringGroupBox.Controls.Add(this.springLenghTextBox);
            this.addSpringGroupBox.Controls.Add(this.springLenghtLabel);
            this.addSpringGroupBox.Controls.Add(this.springNumberTextBox);
            this.addSpringGroupBox.Controls.Add(this.springNumberLabel);
            this.addSpringGroupBox.Location = new System.Drawing.Point(472, 63);
            this.addSpringGroupBox.Name = "addSpringGroupBox";
            this.addSpringGroupBox.Size = new System.Drawing.Size(616, 411);
            this.addSpringGroupBox.TabIndex = 1;
            this.addSpringGroupBox.TabStop = false;
            this.addSpringGroupBox.Text = "Add New Spring";
            // 
            // addNewSpringButton
            // 
            this.addNewSpringButton.Location = new System.Drawing.Point(171, 332);
            this.addNewSpringButton.Name = "addNewSpringButton";
            this.addNewSpringButton.Size = new System.Drawing.Size(223, 53);
            this.addNewSpringButton.TabIndex = 10;
            this.addNewSpringButton.Text = "Add new spring";
            this.addNewSpringButton.UseVisualStyleBackColor = true;
            this.addNewSpringButton.Click += new System.EventHandler(this.addNewSpringButton_Click);
            // 
            // springForceToleranceTextBox
            // 
            this.springForceToleranceTextBox.Location = new System.Drawing.Point(273, 272);
            this.springForceToleranceTextBox.Name = "springForceToleranceTextBox";
            this.springForceToleranceTextBox.Size = new System.Drawing.Size(311, 43);
            this.springForceToleranceTextBox.TabIndex = 9;
            // 
            // springForceTextBox
            // 
            this.springForceTextBox.Location = new System.Drawing.Point(273, 214);
            this.springForceTextBox.Name = "springForceTextBox";
            this.springForceTextBox.Size = new System.Drawing.Size(311, 43);
            this.springForceTextBox.TabIndex = 7;
            // 
            // forceToleranceLabel
            // 
            this.forceToleranceLabel.AutoSize = true;
            this.forceToleranceLabel.Location = new System.Drawing.Point(17, 275);
            this.forceToleranceLabel.Name = "forceToleranceLabel";
            this.forceToleranceLabel.Size = new System.Drawing.Size(256, 37);
            this.forceToleranceLabel.TabIndex = 8;
            this.forceToleranceLabel.Text = "Force Tolerance [N]";
            // 
            // springRateTextBox
            // 
            this.springRateTextBox.Location = new System.Drawing.Point(273, 158);
            this.springRateTextBox.Name = "springRateTextBox";
            this.springRateTextBox.Size = new System.Drawing.Size(311, 43);
            this.springRateTextBox.TabIndex = 5;
            // 
            // springFoceLabel
            // 
            this.springFoceLabel.AutoSize = true;
            this.springFoceLabel.Location = new System.Drawing.Point(17, 217);
            this.springFoceLabel.Name = "springFoceLabel";
            this.springFoceLabel.Size = new System.Drawing.Size(218, 37);
            this.springFoceLabel.TabIndex = 6;
            this.springFoceLabel.Text = "Spring Force [N]";
            // 
            // springRateLabel
            // 
            this.springRateLabel.AutoSize = true;
            this.springRateLabel.Location = new System.Drawing.Point(17, 161);
            this.springRateLabel.Name = "springRateLabel";
            this.springRateLabel.Size = new System.Drawing.Size(159, 37);
            this.springRateLabel.TabIndex = 4;
            this.springRateLabel.Text = "Spring Rate";
            // 
            // springLenghTextBox
            // 
            this.springLenghTextBox.Location = new System.Drawing.Point(273, 100);
            this.springLenghTextBox.Name = "springLenghTextBox";
            this.springLenghTextBox.Size = new System.Drawing.Size(311, 43);
            this.springLenghTextBox.TabIndex = 3;
            // 
            // springLenghtLabel
            // 
            this.springLenghtLabel.AutoSize = true;
            this.springLenghtLabel.Location = new System.Drawing.Point(17, 103);
            this.springLenghtLabel.Name = "springLenghtLabel";
            this.springLenghtLabel.Size = new System.Drawing.Size(263, 37);
            this.springLenghtLabel.TabIndex = 2;
            this.springLenghtLabel.Text = "Spring Length [mm]";
            // 
            // springNumberTextBox
            // 
            this.springNumberTextBox.Location = new System.Drawing.Point(273, 49);
            this.springNumberTextBox.Name = "springNumberTextBox";
            this.springNumberTextBox.Size = new System.Drawing.Size(311, 43);
            this.springNumberTextBox.TabIndex = 1;
            // 
            // springNumberLabel
            // 
            this.springNumberLabel.AutoSize = true;
            this.springNumberLabel.Location = new System.Drawing.Point(17, 52);
            this.springNumberLabel.Name = "springNumberLabel";
            this.springNumberLabel.Size = new System.Drawing.Size(207, 37);
            this.springNumberLabel.TabIndex = 0;
            this.springNumberLabel.Text = "Spring Number";
            // 
            // selectedSpringLabel
            // 
            this.selectedSpringLabel.AutoSize = true;
            this.selectedSpringLabel.Location = new System.Drawing.Point(12, 15);
            this.selectedSpringLabel.Name = "selectedSpringLabel";
            this.selectedSpringLabel.Size = new System.Drawing.Size(205, 37);
            this.selectedSpringLabel.TabIndex = 2;
            this.selectedSpringLabel.Text = "Selected spring";
            // 
            // selectedSpringParametersGroupBox
            // 
            this.selectedSpringParametersGroupBox.Controls.Add(this.selSpringForceToleranceValue);
            this.selectedSpringParametersGroupBox.Controls.Add(this.selSpringForceValue);
            this.selectedSpringParametersGroupBox.Controls.Add(this.selSpringRateValue);
            this.selectedSpringParametersGroupBox.Controls.Add(this.selSpringLenghtValue);
            this.selectedSpringParametersGroupBox.Controls.Add(this.selSpringForceToleranceLabel);
            this.selectedSpringParametersGroupBox.Controls.Add(this.selSpringForceLabel);
            this.selectedSpringParametersGroupBox.Controls.Add(this.selSpringLenghtLabel);
            this.selectedSpringParametersGroupBox.Controls.Add(this.selSpringRateLabel);
            this.selectedSpringParametersGroupBox.Location = new System.Drawing.Point(12, 63);
            this.selectedSpringParametersGroupBox.Name = "selectedSpringParametersGroupBox";
            this.selectedSpringParametersGroupBox.Size = new System.Drawing.Size(428, 273);
            this.selectedSpringParametersGroupBox.TabIndex = 3;
            this.selectedSpringParametersGroupBox.TabStop = false;
            this.selectedSpringParametersGroupBox.Text = "Selected spring parameters";
            // 
            // selSpringForceToleranceValue
            // 
            this.selSpringForceToleranceValue.AutoSize = true;
            this.selSpringForceToleranceValue.Location = new System.Drawing.Point(268, 211);
            this.selSpringForceToleranceValue.Name = "selSpringForceToleranceValue";
            this.selSpringForceToleranceValue.Size = new System.Drawing.Size(117, 37);
            this.selSpringForceToleranceValue.TabIndex = 16;
            this.selSpringForceToleranceValue.Text = "<none>";
            // 
            // selSpringForceValue
            // 
            this.selSpringForceValue.AutoSize = true;
            this.selSpringForceValue.Location = new System.Drawing.Point(230, 153);
            this.selSpringForceValue.Name = "selSpringForceValue";
            this.selSpringForceValue.Size = new System.Drawing.Size(117, 37);
            this.selSpringForceValue.TabIndex = 16;
            this.selSpringForceValue.Text = "<none>";
            // 
            // selSpringRateValue
            // 
            this.selSpringRateValue.AutoSize = true;
            this.selSpringRateValue.Location = new System.Drawing.Point(171, 97);
            this.selSpringRateValue.Name = "selSpringRateValue";
            this.selSpringRateValue.Size = new System.Drawing.Size(117, 37);
            this.selSpringRateValue.TabIndex = 15;
            this.selSpringRateValue.Text = "<none>";
            // 
            // selSpringLenghtValue
            // 
            this.selSpringLenghtValue.AutoSize = true;
            this.selSpringLenghtValue.Location = new System.Drawing.Point(275, 39);
            this.selSpringLenghtValue.Name = "selSpringLenghtValue";
            this.selSpringLenghtValue.Size = new System.Drawing.Size(117, 37);
            this.selSpringLenghtValue.TabIndex = 14;
            this.selSpringLenghtValue.Text = "<none>";
            // 
            // selSpringForceToleranceLabel
            // 
            this.selSpringForceToleranceLabel.AutoSize = true;
            this.selSpringForceToleranceLabel.Location = new System.Drawing.Point(6, 211);
            this.selSpringForceToleranceLabel.Name = "selSpringForceToleranceLabel";
            this.selSpringForceToleranceLabel.Size = new System.Drawing.Size(256, 37);
            this.selSpringForceToleranceLabel.TabIndex = 13;
            this.selSpringForceToleranceLabel.Text = "Force Tolerance [N]";
            // 
            // selSpringForceLabel
            // 
            this.selSpringForceLabel.AutoSize = true;
            this.selSpringForceLabel.Location = new System.Drawing.Point(6, 153);
            this.selSpringForceLabel.Name = "selSpringForceLabel";
            this.selSpringForceLabel.Size = new System.Drawing.Size(218, 37);
            this.selSpringForceLabel.TabIndex = 12;
            this.selSpringForceLabel.Text = "Spring Force [N]";
            // 
            // selSpringLenghtLabel
            // 
            this.selSpringLenghtLabel.AutoSize = true;
            this.selSpringLenghtLabel.Location = new System.Drawing.Point(6, 39);
            this.selSpringLenghtLabel.Name = "selSpringLenghtLabel";
            this.selSpringLenghtLabel.Size = new System.Drawing.Size(263, 37);
            this.selSpringLenghtLabel.TabIndex = 10;
            this.selSpringLenghtLabel.Text = "Spring Length [mm]";
            // 
            // selSpringRateLabel
            // 
            this.selSpringRateLabel.AutoSize = true;
            this.selSpringRateLabel.Location = new System.Drawing.Point(6, 97);
            this.selSpringRateLabel.Name = "selSpringRateLabel";
            this.selSpringRateLabel.Size = new System.Drawing.Size(159, 37);
            this.selSpringRateLabel.TabIndex = 11;
            this.selSpringRateLabel.Text = "Spring Rate";
            // 
            // SpringViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 517);
            this.Controls.Add(this.selectedSpringParametersGroupBox);
            this.Controls.Add(this.selectedSpringLabel);
            this.Controls.Add(this.addSpringGroupBox);
            this.Controls.Add(this.allSpringsComboBox);
            this.Font = new System.Drawing.Font("Malgun Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.Name = "SpringViewer";
            this.Text = "SpringViewer";
            this.addSpringGroupBox.ResumeLayout(false);
            this.addSpringGroupBox.PerformLayout();
            this.selectedSpringParametersGroupBox.ResumeLayout(false);
            this.selectedSpringParametersGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox allSpringsComboBox;
        private System.Windows.Forms.GroupBox addSpringGroupBox;
        private System.Windows.Forms.TextBox springNumberTextBox;
        private System.Windows.Forms.Label springNumberLabel;
        private System.Windows.Forms.Button addNewSpringButton;
        private System.Windows.Forms.TextBox springForceToleranceTextBox;
        private System.Windows.Forms.TextBox springForceTextBox;
        private System.Windows.Forms.Label forceToleranceLabel;
        private System.Windows.Forms.TextBox springRateTextBox;
        private System.Windows.Forms.Label springFoceLabel;
        private System.Windows.Forms.Label springRateLabel;
        private System.Windows.Forms.TextBox springLenghTextBox;
        private System.Windows.Forms.Label springLenghtLabel;
        private System.Windows.Forms.Label selectedSpringLabel;
        private System.Windows.Forms.GroupBox selectedSpringParametersGroupBox;
        private System.Windows.Forms.Label selSpringForceToleranceValue;
        private System.Windows.Forms.Label selSpringForceValue;
        private System.Windows.Forms.Label selSpringRateValue;
        private System.Windows.Forms.Label selSpringLenghtValue;
        private System.Windows.Forms.Label selSpringForceToleranceLabel;
        private System.Windows.Forms.Label selSpringForceLabel;
        private System.Windows.Forms.Label selSpringLenghtLabel;
        private System.Windows.Forms.Label selSpringRateLabel;
    }
}