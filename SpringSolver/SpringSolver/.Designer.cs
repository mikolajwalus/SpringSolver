namespace SpringSolver
{
    partial class CalculationsViewer
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.programNameLabel = new System.Windows.Forms.Label();
            this.createCalculationsButton = new System.Windows.Forms.Button();
            this.loadCalculationsButton = new System.Windows.Forms.Button();
            this.calculationsComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // programNameLabel
            // 
            this.programNameLabel.AutoSize = true;
            this.programNameLabel.Font = new System.Drawing.Font("Malgun Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.programNameLabel.Location = new System.Drawing.Point(100, 9);
            this.programNameLabel.Name = "programNameLabel";
            this.programNameLabel.Size = new System.Drawing.Size(492, 47);
            this.programNameLabel.TabIndex = 0;
            this.programNameLabel.Text = "WABCO SPRING SOLVER CAR";
            this.programNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // createCalculationsButton
            // 
            this.createCalculationsButton.Font = new System.Drawing.Font("Malgun Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createCalculationsButton.Location = new System.Drawing.Point(199, 255);
            this.createCalculationsButton.Name = "createCalculationsButton";
            this.createCalculationsButton.Size = new System.Drawing.Size(274, 57);
            this.createCalculationsButton.TabIndex = 1;
            this.createCalculationsButton.Text = "Create Calculations";
            this.createCalculationsButton.UseVisualStyleBackColor = true;
            this.createCalculationsButton.Click += new System.EventHandler(this.createCalculationsButton_Click);
            // 
            // loadCalculationsButton
            // 
            this.loadCalculationsButton.Font = new System.Drawing.Font("Malgun Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadCalculationsButton.Location = new System.Drawing.Point(199, 181);
            this.loadCalculationsButton.Name = "loadCalculationsButton";
            this.loadCalculationsButton.Size = new System.Drawing.Size(274, 57);
            this.loadCalculationsButton.TabIndex = 2;
            this.loadCalculationsButton.Text = "Load Calculations";
            this.loadCalculationsButton.UseVisualStyleBackColor = true;
            this.loadCalculationsButton.Click += new System.EventHandler(this.loadCalculationsButton_Click);
            // 
            // calculationsComboBox
            // 
            this.calculationsComboBox.Font = new System.Drawing.Font("Malgun Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calculationsComboBox.FormattingEnabled = true;
            this.calculationsComboBox.Location = new System.Drawing.Point(108, 119);
            this.calculationsComboBox.Name = "calculationsComboBox";
            this.calculationsComboBox.Size = new System.Drawing.Size(469, 45);
            this.calculationsComboBox.TabIndex = 3;
            // 
            // CalculationsViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 351);
            this.Controls.Add(this.calculationsComboBox);
            this.Controls.Add(this.loadCalculationsButton);
            this.Controls.Add(this.createCalculationsButton);
            this.Controls.Add(this.programNameLabel);
            this.Name = "CalculationsViewer";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label programNameLabel;
        private System.Windows.Forms.Button createCalculationsButton;
        private System.Windows.Forms.Button loadCalculationsButton;
        private System.Windows.Forms.ComboBox calculationsComboBox;
    }
}

