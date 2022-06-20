using ElcometerCSVReader.DataAccess;
using ElcometerCSVReader.Models;
using ElcometerCSVReader.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElcometerCSVReader.Presenters
{

    /* Single Presenter layer class for updating the view, listening to user events, and retrieving data from the model.
     * Unfortunately, all views in the app reference a single instance of this one presenter class. My limited
     * experience with MVP in winforms/C# means this is neither very or extendable, nor does it correctly
     * utilise interfaces (more on that in ICSVReaderView). My main goal was making sure that the Views were passive
     * and only updated through a Presenter, which I achieved.
     */
    public class CSVReaderPresenter
    {
        // FIELDS
        private readonly CSVReaderView _view;
        private CSVFile _file;
        private readonly List<string> _customHeadings = new List<string>();
        private readonly List<string[]> _filters = new List<string[]>();
        private DataTable _previousState = new DataTable();

        // CONSTRUCTORS
        public CSVReaderPresenter(CSVReaderView view)
        {
            _view = view;
        }

        // METHODS

        // Method called when the "Upload CSV" button on main view is pressed.
        public void BrowseFiles()
        {
            var fileDialogue = new OpenFileDialog();
            var result = fileDialogue.ShowDialog(); // Shows user the file dialogue.
            if (result == DialogResult.OK) // If user does not cancel (ie selects a file)
            {
                try
                {
                    string filePath = fileDialogue.FileName;
                    _file = new CSVFile(filePath); /* Tries to create a new CSVFile object from filepath.
                                                    * If the file extension does not end in .csv, the CSVFile
                                                    * FilePath setter will return an exception.
                                                    */
                    var customHeadingsView = new CustomHeadingsView(this);
                    customHeadingsView.Show(); // Takes the user to the "Custom Headings" view.
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); // Handles the CSVFile FilePath setter exception.
                }
            }
        }

        // Method called when the "Yes, I want to set headers" button on CustomHeadingsView is pressed.
        public void CustomHeadingOption()
        {
            var columnCount = CSVFileManager.GetColumnCount(_file.FilePath); /* Checks the column count
                                                                              * from the CSVFileManager.
                                                                              * (This is called on every new
                                                                              * CustomHeading - would have been
                                                                              * more efficient to call once
                                                                              * and store the result 
                                                                              * in a field).
                                                                              */
            if (_customHeadings.Count < columnCount)
            {
                var customHeadingOption = new CustomHeadingOptionView(this); /* Takes the user to a "CustomHeadingOption"
                                                                              * view if another custom heading is required.
                                                                              */
                customHeadingOption.DisplayText = $"Enter a name for column {_customHeadings.Count + 1}";
                customHeadingOption.Show();
            }
        }

        /* Method called when the "Confirm" button on CustomHeadingOptionView is pressed.
         * This method is responsible for either generating another CustomHeadingOptionView,
         * or for retrieving the data if all customHeadings have been set.
         */

        public void CustomHeadingOption(string heading)
        {
            _customHeadings.Add(heading);
            var columnCount = CSVFileManager.GetColumnCount(_file.FilePath);
            if (_customHeadings.Count < columnCount)
            {
                var customHeadingOption = new CustomHeadingOptionView(this);
                customHeadingOption.DisplayText = $"Enter a name for column {_customHeadings.Count + 1}";
                customHeadingOption.Show();
            }
            else
            {
                try
                {
                    _file.RetrieveData(_customHeadings); /* Retrieves the data from the CSVFile. 
                                                         * On large CSV's, this causes the application to hang -
                                                         * would like to have at least displayed a message telling the user
                                                         * to wait.
                                                         */
                    _view.CSVData = _file.Data; // Updates the table on the view with a DataTable.
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message); /* Here the exception from the FileManager.ReadCSV method
                                                 * is caught. (Not a good way to handle it - see
                                                 * FileManager for details).
                                                 */
                }
            }
        }

        // Method called when the "Apply New Filter" button on the main view is pressed.
        public void DisplayFilter()
        {
            try
            {
                CheckForFile(); // See bottom of class
                var columns = _file.Data.Columns;
                var columnsList = new List<string>();
                foreach (var item in columns)
                {
                    columnsList.Add(item.ToString());
                }
                var filterView = new ApplyFilterView(this);

                // ComboBox used in Form required an IList data type.

                filterView.FilterBox = columnsList;
                filterView.Show();
            }
            catch (Exception e) // As with all below methods, displays exception from CheckForFile method.
            {
                MessageBox.Show(e.Message);
            }
        }

        // Method called when the "Apply Filter" button on the ApplyFilterView is pressed.
        public void ApplyFilter(string column, string value)
        {
            if (value != null)
            {
                try
                {
                    /* To try and cut down on the number of times the program needs to iterate over the data,
                     * I tried to store a previousState copy of the data, so that when the user wants to remove the last
                     * filter (see below method), or add a new filter, the view is simply updated with the previousState.
                     * However, I didn't realise that this would then break if the user wanted to remove
                     * 2 consecutive last filters.
                     */

                    _previousState = _view.CSVData.Copy();

                    // Uses LINQ to enumerate over the DataTable based on params.

                    var result = _previousState.AsEnumerable().Where(row => row.Field<string>(column) == value).CopyToDataTable();
                    _view.CSVData = result;

                    // Keeps track of current filters for updating the view.

                    _filters.Add(new string[] { column, value });
                    SetFilterText();

                } 
                catch (InvalidOperationException e)
                {
                    MessageBox.Show("No matching results.");
                }
            }
            else
            {
                MessageBox.Show("No value inputted to filter");
            }
        }

        // Method called when the "Remove Last Filter" button on the main view is pressed.
        public void RemoveLastFilter()
        {
            try
            {
                CheckForFile();
                if (_previousState.Rows.Count > 0)
                {

                    /* To handle my mistake with the previousState, I clear the previousState and update
                     * the view each time the user wants to remove the last filter.
                     * Upon consecutive removals, previousState.Rows.Count is now 0, triggering the else.
                     * This feels like a very messy and unnecessary way to handle filters.
                     */

                    _view.CSVData = _previousState.Copy();
                    _previousState.Clear();
                    _filters.RemoveAt(_filters.Count - 1);
                }
                else
                {
                    /* My original method for handling filters. For each filter, a new LINQ query is ran over a copy
                     * of the original dataset. Additive iterations of potentially large sets of data is what I wanted
                     * to avoid.
                     */

                    _filters.RemoveAt(_filters.Count - 1); /* Triggers an ArgumentOutOfRangeException
                                                            * if there are no filters to remove.
                                                            */
                    var result = _file.Data.Copy();
                    foreach(var filter in _filters)
                    {
                        result = result.AsEnumerable().Where(row => row.Field<string>(filter[0]) == filter[1]).CopyToDataTable();
                    }
                    _view.CSVData = result;
                }
                SetFilterText();
            }
            catch (ArgumentOutOfRangeException e)
            { 
                /* I chose not to handle this exception. The user doesn't need to be told there's no filters
                 * because that's the purpose of the FilterText on the View.
                 */
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        // Method called when the "Remove All Filters" button on the main view is pressed.

        public void RemoveAllFilters()
        {
            try
            {
                CheckForFile();
                _view.CSVData = _file.Data;
                _filters.Clear();
                SetFilterText();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        // Method called when the "No custom headings" button on the CustomHeadingsView is pressed.

        public void GetCSVData()
        {
            try
            {
                _file.RetrieveData();
                _view.CSVData = _file.Data;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                _customHeadings.Clear();
            }
        }

        /* Private method called from various points in the presenter when the view's current filter text
         * needs to be updated.
         */

        private void SetFilterText()
        {
            if (_filters.Count > 0)
            {
                var sb = new StringBuilder();
                Debug.WriteLine(_filters.Count);
                foreach (var filter in _filters)
                {
                    sb.Append($"{filter[0]} = {filter[1]} AND ");
                }
                var result = sb.ToString();
                result = result.TrimEnd('A', 'N', 'D', ' ');
                _view.CurrentFiltersText = result;
            }
            else
            {
                _view.CurrentFiltersText = "No current filters";
            }
        }

        /* Private method used by all methods triggered by View's filter buttons.
         * Even if only one line, seemed sensible to extract this to its own function
         * to stay DRY.
         */
        private void CheckForFile()
        {
            if (_file == null) throw new Exception("You haven't uploaded a file yet!");
        }
    }
}
