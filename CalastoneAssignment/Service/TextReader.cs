using Calastone.Model;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace Calastone.Service
{
    internal class TextReader : ITextReader
    {
        private IConfiguration configuration;
        private DirectoryPath directoryPath;

        public TextReader(IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(configuration);
            this.configuration = configuration;
            ReadConfig();
        }

        public void ReadTextFile(out StringBuilder stringBuilder)
        {
            using (StreamReader Reader = new StreamReader(directoryPath.InputFile))
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Append(Reader.ReadToEnd());
                {
                    Console.WriteLine($"Finish reading file{directoryPath.InputFile}");
                }
            }
        }

        private void ReadConfig()
        {
            directoryPath = configuration.GetSection("DirectoryPath").Get<DirectoryPath>();         
        }     
    }
}
