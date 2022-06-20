using System.Diagnostics;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;
using ElcometerCSVReader.Models;
using ElcometerCSVReader;
using ElcometerCSVReader.DataAccess;
using ElcometerCSVReader.Presenters;

namespace ElcometerCSVReader.Views
{
    public partial class CSVReaderView : Form, ICSVReaderView
    {
        // FIELDS

        private readonly CSVReaderPresenter _presenter;

        // PROPERTIES
        /* Provides the presenter with a way to read and update the private components available to the view.
         * This is important to create passive views where the logic is handled by the presenter.
         */

        public DataTable CSVData
        {
            get { return (DataTable)dataGridView1.DataSource; }
            set { dataGridView1.DataSource = value; }
        }
        public string CurrentFiltersText
        {
            get { return CurrentFilters.Text;  }
            set { CurrentFilters.Text = value; }
        }
        
        // CONSTRUCTORS

        public CSVReaderView()
        {
            InitializeComponent();
            _presenter = new CSVReaderPresenter(this);
        }

        // METHODS
        // Methods on the view serve as event listeners, and call a respective method from the presenter.
        public void BrowseButton_Click(object sender, EventArgs e)
        {
            _presenter.BrowseFiles();
        }

        public void ApplyFilterButton_Click(object sender, EventArgs e)
        {
            _presenter.DisplayFilter();
        }

        private void RemoveLastFilterButton_Click(object sender, EventArgs e)
        {
            _presenter.RemoveLastFilter();
        }

        private void RemoveAllFiltersButton_Click(object sender, EventArgs e)
        {
            _presenter.RemoveAllFilters();
        }
    }   
}