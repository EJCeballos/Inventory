namespace Inventory
{
    partial class CheckIn
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
            this.components = new System.ComponentModel.Container();
            this.InputCheckin = new System.Windows.Forms.TextBox();
            this.CheckInLabel = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.Submit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // InputCheckin
            // 
            this.InputCheckin.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputCheckin.Location = new System.Drawing.Point(98, 125);
            this.InputCheckin.Name = "InputCheckin";
            this.InputCheckin.Size = new System.Drawing.Size(289, 34);
            this.InputCheckin.TabIndex = 0;
            // 
            // CheckInLabel
            // 
            this.CheckInLabel.AutoSize = true;
            this.CheckInLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckInLabel.Location = new System.Drawing.Point(24, 45);
            this.CheckInLabel.Name = "CheckInLabel";
            this.CheckInLabel.Size = new System.Drawing.Size(363, 38);
            this.CheckInLabel.TabIndex = 1;
            this.CheckInLabel.Text = "Please Scan Location:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(236, 199);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(97, 36);
            this.Submit.TabIndex = 2;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // CheckIn
            // 
            this.AcceptButton = this.Submit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 268);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.CheckInLabel);
            this.Controls.Add(this.InputCheckin);
            this.Name = "CheckIn";
            this.Text = "Checkin/Return Item to Stock";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InputCheckin;
        private System.Windows.Forms.Label CheckInLabel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button Submit;
    }
}