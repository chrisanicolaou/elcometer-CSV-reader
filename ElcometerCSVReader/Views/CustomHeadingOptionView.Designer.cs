namespace ElcometerCSVReader.Views
{
    partial class CustomHeadingOptionView
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
            this.ColumnNameText = new System.Windows.Forms.TextBox();
            this.EnterButton = new System.Windows.Forms.Button();
            this.DisplayTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ColumnNameText
            // 
            this.ColumnNameText.Location = new System.Drawing.Point(248, 182);
            this.ColumnNameText.Name = "ColumnNameText";
            this.ColumnNameText.PlaceholderText = "Column name";
            this.ColumnNameText.Size = new System.Drawing.Size(283, 23);
            this.ColumnNameText.TabIndex = 0;
            // 
            // EnterButton
            // 
            this.EnterButton.Location = new System.Drawing.Point(348, 235);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.Size = new System.Drawing.Size(78, 34);
            this.EnterButton.TabIndex = 1;
            this.EnterButton.Text = "Enter";
            this.EnterButton.UseVisualStyleBackColor = true;
            this.EnterButton.Click += new System.EventHandler(this.EnterButton_Click);
            // 
            // DisplayTextBox
            // 
            this.DisplayTextBox.Location = new System.Drawing.Point(248, 153);
            this.DisplayTextBox.Name = "DisplayTextBox";
            this.DisplayTextBox.ReadOnly = true;
            this.DisplayTextBox.Size = new System.Drawing.Size(283, 23);
            this.DisplayTextBox.TabIndex = 2;
            this.DisplayTextBox.Text = "Please enter a name for custom heading:";
            // 
            // CustomHeadingOptionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DisplayTextBox);
            this.Controls.Add(this.EnterButton);
            this.Controls.Add(this.ColumnNameText);
            this.Name = "CustomHeadingOptionView";
            this.Text = "CustomHeadingOptionView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox ColumnNameText;
        private Button EnterButton;
        private TextBox DisplayTextBox;
    }
}