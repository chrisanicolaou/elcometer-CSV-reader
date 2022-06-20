namespace ElcometerCSVReader.Views
{
    partial class CSVReaderView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.UploadCSVButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ApplyFilterButton = new System.Windows.Forms.Button();
            this.RemoveLastFilterButton = new System.Windows.Forms.Button();
            this.RemoveAllFiltersButton = new System.Windows.Forms.Button();
            this.CurrentFilters = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // UploadCSVButton
            // 
            this.UploadCSVButton.Location = new System.Drawing.Point(194, 22);
            this.UploadCSVButton.Name = "UploadCSVButton";
            this.UploadCSVButton.Size = new System.Drawing.Size(137, 34);
            this.UploadCSVButton.TabIndex = 0;
            this.UploadCSVButton.Text = "Upload CSV";
            this.UploadCSVButton.UseVisualStyleBackColor = true;
            this.UploadCSVButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 116);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1022, 525);
            this.dataGridView1.TabIndex = 1;
            // 
            // ApplyFilterButton
            // 
            this.ApplyFilterButton.Location = new System.Drawing.Point(366, 22);
            this.ApplyFilterButton.Name = "ApplyFilterButton";
            this.ApplyFilterButton.Size = new System.Drawing.Size(137, 34);
            this.ApplyFilterButton.TabIndex = 2;
            this.ApplyFilterButton.Text = "Apply New Filter";
            this.ApplyFilterButton.UseMnemonic = false;
            this.ApplyFilterButton.UseVisualStyleBackColor = true;
            this.ApplyFilterButton.Click += new System.EventHandler(this.ApplyFilterButton_Click);
            // 
            // RemoveLastFilterButton
            // 
            this.RemoveLastFilterButton.Location = new System.Drawing.Point(529, 22);
            this.RemoveLastFilterButton.Name = "RemoveLastFilterButton";
            this.RemoveLastFilterButton.Size = new System.Drawing.Size(137, 34);
            this.RemoveLastFilterButton.TabIndex = 3;
            this.RemoveLastFilterButton.Text = "Remove Last Filter";
            this.RemoveLastFilterButton.UseVisualStyleBackColor = true;
            this.RemoveLastFilterButton.Click += new System.EventHandler(this.RemoveLastFilterButton_Click);
            // 
            // RemoveAllFiltersButton
            // 
            this.RemoveAllFiltersButton.Location = new System.Drawing.Point(693, 22);
            this.RemoveAllFiltersButton.Name = "RemoveAllFiltersButton";
            this.RemoveAllFiltersButton.Size = new System.Drawing.Size(137, 34);
            this.RemoveAllFiltersButton.TabIndex = 4;
            this.RemoveAllFiltersButton.Text = "Remove All Filters";
            this.RemoveAllFiltersButton.UseVisualStyleBackColor = true;
            this.RemoveAllFiltersButton.Click += new System.EventHandler(this.RemoveAllFiltersButton_Click);
            // 
            // CurrentFilters
            // 
            this.CurrentFilters.Location = new System.Drawing.Point(194, 75);
            this.CurrentFilters.Name = "CurrentFilters";
            this.CurrentFilters.ReadOnly = true;
            this.CurrentFilters.Size = new System.Drawing.Size(636, 23);
            this.CurrentFilters.TabIndex = 5;
            this.CurrentFilters.Text = "No current filters";
            // 
            // CSVReaderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 653);
            this.Controls.Add(this.CurrentFilters);
            this.Controls.Add(this.RemoveAllFiltersButton);
            this.Controls.Add(this.RemoveLastFilterButton);
            this.Controls.Add(this.ApplyFilterButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.UploadCSVButton);
            this.Name = "CSVReaderView";
            this.Text = "CSV Reader";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button UploadCSVButton;
        private DataGridView dataGridView1;
        private Button ApplyFilterButton;
        private Button RemoveLastFilterButton;
        private Button RemoveAllFiltersButton;
        private TextBox CurrentFilters;
    }
}