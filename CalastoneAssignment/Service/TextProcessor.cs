using Calastone.Model;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace Calastone.Service
{
    internal class TextProcessor
    {
        private readonly IConfiguration configuration;
        private DirectoryPath directoryPath;        
        private ITextReader dataReader;
        ITextFilterService textFilterService;
        private StringBuilder fileContents;

        public TextProcessor(IConfiguration configuration, ITextReader dataReader, ITextFilterService textFilterService)
        {
            ArgumentNullException.ThrowIfNull(configuration);
            ArgumentNullException.ThrowIfNull(dataReader);
            ArgumentNullException.ThrowIfNull(textFilterService);
            this.configuration = configuration;
            this.dataReader = dataReader;  
            this.textFilterService = textFilterService;
            DisplayConfig();
        }

        public void ProcessText()
        {
            ReadFile();
            textFilterService.ApplyFilters(fileContents);
            ShowResults();
        }

        private void ReadFile()
        {
            dataReader.ReadTextFile(out fileContents);
            Console.WriteLine();
            Console.WriteLine("**************File contents BEFORE applying filters**************");
            Console.WriteLine(fileContents.ToString());
        }

        private void ShowResults()
        {
            Console.WriteLine();
            Console.WriteLine("**************File contents AFTER applying filters**************");
            Console.WriteLine(fileContents.ToString());
        }

        private void DisplayConfig()
        {
            directoryPath = configuration.GetSection("DirectoryPath").Get<DirectoryPath>();
            Console.WriteLine($"Input file is {directoryPath.InputFile}");            
        }
    }   
}
