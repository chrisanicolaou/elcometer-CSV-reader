namespace ElcometerCSVReader.Views
{
    partial class CustomHeadingsView
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ConfirmCustomHeadingsButton = new System.Windows.Forms.Button();
            this.DeclineCustomHeadingsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(226, 39);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(372, 82);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Would you like to set your own custom headers? (CSV Reader will use the first row" +
    " as column headers by default).";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ConfirmCustomHeadingsButton
            // 
            this.ConfirmCustomHeadingsButton.Location = new System.Drawing.Point(226, 171);
            this.ConfirmCustomHeadingsButton.Name = "ConfirmCustomHeadingsButton";
            this.ConfirmCustomHeadingsButton.Size = new System.Drawing.Size(130, 43);
            this.ConfirmCustomHeadingsButton.TabIndex = 1;
            this.ConfirmCustomHeadingsButton.Text = "Yes, I want to set my own headers";
            this.ConfirmCustomHeadingsButton.UseVisualStyleBackColor = true;
            this.ConfirmCustomHeadingsButton.Click += new System.EventHandler(this.ConfirmCustomHeadingsButton_Click);
            // 
            // DeclineCustomHeadingsButton
            // 
            this.DeclineCustomHeadingsButton.Location = new System.Drawing.Point(468, 171);
            this.DeclineCustomHeadingsButton.Name = "DeclineCustomHeadingsButton";
            this.DeclineCustomHeadingsButton.Size = new System.Drawing.Size(130, 43);
            this.DeclineCustomHeadingsButton.TabIndex = 2;
            this.DeclineCustomHeadingsButton.Text = "No, I\'m happy with the default headers";
            this.DeclineCustomHeadingsButton.UseVisualStyleBackColor = true;
            this.DeclineCustomHeadingsButton.Click += new System.EventHandler(this.DeclineCustomHeadingsButton_Click);
            // 
            // CustomHeadingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DeclineCustomHeadingsButton);
            this.Controls.Add(this.ConfirmCustomHeadingsButton);
            this.Controls.Add(this.textBox1);
            this.Name = "CustomHeadingsView";
            this.Text = "Custom Headings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private Button ConfirmCustomHeadingsButton;
        private Button DeclineCustomHeadingsButton;
    }
}