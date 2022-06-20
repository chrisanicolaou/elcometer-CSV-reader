using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElcometerCSVReader.Views
{
    // Interface for CustomHeadingsView. (see ICSVReaderView for details on my use of interfaces).
    public interface ICustomHeadingsView
    {
        void DeclineCustomHeadingsButton_Click(object sender, EventArgs e);
        void ConfirmCustomHeadingsButton_Click(object sender, EventArgs e);
    }
}
