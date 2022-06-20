using ElcometerCSVReader.Models;
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
    public partial class CustomHeadingsView : Form, ICustomHeadingsView
    {
        // FIELDS

        private readonly CSVReaderPresenter _presenter;

        // CONSTRUCTORS

        public CustomHeadingsView(CSVReaderPresenter presenter)
        {
            InitializeComponent();
            _presenter = presenter;
        }

        // METHODS
        // Methods on the view serve as event listeners, and call a respective method from the presenter.

        public void DeclineCustomHeadingsButton_Click(object sender, EventArgs e)
        {
            _presenter.GetCSVData();
            this.Hide();
        }

        public void ConfirmCustomHeadingsButton_Click(object sender, EventArgs e)
        {
            _presenter.CustomHeadingOption();
            this.Hide();
        }
    }
}
