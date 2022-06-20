using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElcometerCSVReader.Views
{
    // Interface for CustomHeadingOptionView. (see ICSVReaderView for details on my use of interfaces).
    public interface ICustomHeadingOptionView
    {
        string DisplayText { get; set; }
        void EnterButton_Click(object sender, EventArgs e);
    }
}
