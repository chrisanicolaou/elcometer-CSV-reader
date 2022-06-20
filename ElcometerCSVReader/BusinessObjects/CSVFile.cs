using ElcometerCSVReader.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElcometerCSVReader.Models
{
    /* Class for selected CSV file to be instantiated from. I originally wanted this to follow a more traditional Business Object format,
     * with Properties assigned to known columns; but, given that the data being read from CSV files can have varying columns with
     * varying headers, I decided to define a "one size fits all" class.
     */
    public class CSVFile
    {
        // FIELDS
        private string _filePath;

        // PROPERTIES
        public DataTable Data { get; set; } // Stores data retrieved from file into a datatable. (See constructor)
        public string[] CustomHeadings { get; set; } // Stores any custom headings user defines if they choose to do so.
        public string FilePath
        {
            get { return _filePath; }

            /* It seemed sensible to validate the file as a .csv in the setter, since the model 
             * represents data retrieved from the data access layer.
             */
            set
            {
                if (Path.GetExtension(value) != ".csv")
                {
                    throw new Exception("Must be a .csv file!");
                }
                _filePath = value;
            }
        }

        // CONSTRUCTORS

        public CSVFile(string filePath)
        {
            this.FilePath = filePath;
        }

        // METHODS

        /* I decided to handle custom headings through an overloaded RetrieveData method.
         * This kind of logic does not belong in the Business Object 
         * and instead should be refactored and handled solely by the Data Access layer through DI of a
         * CSV File object.
         */
        public void RetrieveData()
        {
            this.Data = CSVFileManager.ReadCSV(new StreamReader(FilePath), null); /*For example, the "ReadCSV" method
                                                                                   * can quite easily take a CSVFile
                                                                                   * object instead of a StreamReader
                                                                                   * and customHeadings.
                                                                                   */
        }
        public void RetrieveData(List<string> customHeadings)
        {
            this.Data = CSVFileManager.ReadCSV(new StreamReader(FilePath), customHeadings);
        }
    }
}
