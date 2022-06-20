using ElcometerCSVReader.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElcometerCSVReader.Views
{
    public partial class CustomHeadingOptionView : Form, ICustomHeadingOptionView
    {
        // FIELDS

        private readonly CSVReaderPresenter _presenter;

        // PROPERTIES
        /* Provides the presenter with a way to read and update the private components available to the view.
         * This is important to create passive views where the logic is handled by the presenter.
         */

        public string DisplayText
        {
            get { return DisplayTextBox.Text; }
            set { DisplayTextBox.Text = value; }
        }

        // CONSTRUCTORS

        public CustomHeadingOptionView(CSVReaderPresenter presenter)
        {
            InitializeComponent();
            _presenter = presenter;
        }

        // METHODS
        // Methods on the view serve as event listeners, and call a respective method from the presenter.

        public void EnterButton_Click(object sender, EventArgs e)
        {
            _presenter.CustomHeadingOption(ColumnNameText.Text);
            this.Hide();
        }
    }
}
