using ElcometerCSVReader.Views;

namespace ElcometerCSVReader
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new CSVReaderView());
        }
    }
}