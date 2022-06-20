using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElcometerCSVReader.Views
{    
    /* Interface for CSVReaderView. Currently, I am in the middle of a Udemy course specifically on Unit Testing
     * and correct use of interfaces. Although I understand the concept of interfaces and the importance of dependency injection
     * for testing & building of loosely coupled programs, my experience implementing them has been limited.
     * As such, I am aware that my interfaces in this test do nothing other than provide a set of rules for the views,
     * and are not correctly implemented by the presenter. I'm excited to learn more about interfaces and 
     * gain some more experience implementing them correctly in the future.
     */

    public interface ICSVReaderView
    {
        DataTable CSVData { get; set; }
        string CurrentFiltersText { get; set; }
        void BrowseButton_Click(object sender, EventArgs e);
        void ApplyFilterButton_Click(object sender, EventArgs e);
    }
}
