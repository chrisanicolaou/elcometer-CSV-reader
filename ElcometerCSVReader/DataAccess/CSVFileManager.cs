using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ElcometerCSVReader.DataAccess
{
    /* Static class consisting of methods for handling the retrieving of data from the provided CSVFile filepath.
     * I decided on static since the filemanager has none of its own properties/object specific methods that
     * would require instantiating this class.
     * I tried to keep all logic that involves data retrieving here. However, as I got towards the end
     * of the tech test, too much of my logic ended up in my Presenter layer (ie filtering).
     * This should be easy enough to refactor and clean up with more time.
     */
    public static class CSVFileManager
    {
        /* Main method for populating the CSVFile object once the user has decided on customHeadings or not
         * (see Presenter layer). I decided on an optional null argument for customHeadings; the method is
         * not small, so overloading created clutter when a simple if null statement would handle the 
         * column names just as well.
         */
        public static DataTable ReadCSV(StreamReader file, List<string>? customHeadings)
        {
            var dataTable = new DataTable();
            if (customHeadings != null)
            {
                foreach (var row in customHeadings)
                {
                    /* Here is where I handled empty column inputs from the user for 4a of the task. This was definitely the wrong
                     * way to handle it, since this exception will only be thrown once all column names
                     * have been entered (ie a user could end up missing 1 column name, inputting 20
                     * correct ones, and have to repeat the process again).
                     */
                    if (row == "") throw new Exception("Column name must not be empty!"); 
                    dataTable.Columns.Add(row);
                }
            }
            else
            {
                // The below regex ensures CSV files with commas inside quotes will be handled correctly.
                var currentRow = Regex.Split(file.ReadLine(), ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                foreach (var row in currentRow)
                {
                    dataTable.Columns.Add(row);
                }
            }
            while (!file.EndOfStream)
            {
                try
                {
                    var currentRow = Regex.Split(file.ReadLine(), ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                    dataTable.Rows.Add(currentRow);
                } catch (ArgumentException e)
                {
                    /* This seemed like the easiest way to check for missing cells in the first row of the CSV file (4b).
                     * If cells were missing, an ArgumentException would be thrown here if the program tries to add
                     * rows with more fields than available columns to the dataTable.
                     */
                    throw new Exception("There is something wrong with the first row of your CSV file. (Are there any empty cells?)");
                }
            }
            return dataTable;
        }

        /* Used in the Presenter to generate the required number of prompts for customHeadings from the user,
         * without having to read the entire CSV file.
         */
        public static int GetColumnCount(string filePath)
        {
            var firstLine = File.ReadLines(filePath).First();
            var columns = Regex.Split(firstLine, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
            return columns.Length;
        }
    }
}
