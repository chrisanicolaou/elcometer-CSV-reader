using System.Data;

namespace ElcometerCSVReader.Views
{
    // Interface for ApplyFilterView. (see ICSVReaderView for details on my use of interfaces).
    public interface IApplyFilterView
    {
        List<string> FilterBox { set; }
    }
}