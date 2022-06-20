using ElcometerCSVReader.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElcometerCSVReader.Views
{
    public partial class ApplyFilterView : Form, IApplyFilterView
    {
        // FIELDS

        private readonly CSVReaderPresenter _presenter;

        // PROPERTIES
        /* Provides the presenter with a way to read and update the private components available to the view.
         * This is important to create passive views where the logic is handled by the presenter.
         */

        public List<string> FilterBox
        {
            set { FilterComboBox.DataSource = value; }
        }

        // CONSTRUCTORS

        public ApplyFilterView(CSVReaderPresenter presenter)
        {
            InitializeComponent();
            _presenter = presenter;
            FilterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // METHODS
        // Methods on the view serve as event listeners, and call a respective method from the presenter.

        private void ApplyFilterButton_Click(object sender, EventArgs e)
        {
            _presenter.ApplyFilter(FilterComboBox.SelectedItem.ToString(), FilterValue.Text);
            this.Hide();
        }
    }
}
