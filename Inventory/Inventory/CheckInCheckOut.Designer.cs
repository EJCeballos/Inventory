namespace Inventory
{
    partial class CheckInCheckOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckInCheckOut));
            this.CheckOutInput = new System.Windows.Forms.TextBox();
            this.DirectionLabel = new System.Windows.Forms.Label();
            this.submitCheckOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CheckOutInput
            // 
            this.CheckOutInput.Location = new System.Drawing.Point(112, 100);
            this.CheckOutInput.Name = "CheckOutInput";
            this.CheckOutInput.Size = new System.Drawing.Size(269, 22);
            this.CheckOutInput.TabIndex = 0;
            // 
            // DirectionLabel
            // 
            this.DirectionLabel.AutoSize = true;
            this.DirectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DirectionLabel.Location = new System.Drawing.Point(109, 58);
            this.DirectionLabel.Name = "DirectionLabel";
            this.DirectionLabel.Size = new System.Drawing.Size(220, 20);
            this.DirectionLabel.TabIndex = 1;
            this.DirectionLabel.Text = "Please enter Serial Number:";
            // 
            // submitCheckOut
            // 
            this.submitCheckOut.Location = new System.Drawing.Point(190, 150);
            this.submitCheckOut.Name = "submitCheckOut";
            this.submitCheckOut.Size = new System.Drawing.Size(92, 33);
            this.submitCheckOut.TabIndex = 2;
            this.submitCheckOut.Text = "Submit";
            this.submitCheckOut.UseVisualStyleBackColor = true;
            this.submitCheckOut.Click += new System.EventHandler(this.submitCheckOut_Click);
            // 
            // CheckOut
            // 
            this.AcceptButton = this.submitCheckOut;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 216);
            this.Controls.Add(this.submitCheckOut);
            this.Controls.Add(this.DirectionLabel);
            this.Controls.Add(this.CheckOutInput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CheckOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CheckOut";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CheckOutInput;
        private System.Windows.Forms.Label DirectionLabel;
        private System.Windows.Forms.Button submitCheckOut;
    }
}