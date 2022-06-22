using CalastoneAssignment.Filters;
using System.Text;
using System.Text.RegularExpressions;

namespace Calastone.Service
{
    public class TextFilterService : ITextFilterService
    {
        private readonly List<IFilter> filters;

        public TextFilterService()
        {
            filters = new List<IFilter> {
                new VowelFilter(),
                new LengthFilter(),
                new TFilter()
            };
        }

        public void ApplyFilters(StringBuilder fileContent)
        {
            var input = fileContent.ToString();
            var words = Regex.Split(input, @"\W");
            foreach (var word in words)
            {
                if (word.Length > 0)
                {
                    foreach (var filter in filters)
                    {
                        filter.ApplyFilter(fileContent, word);
                    }                   
                }                     
            }            
        }            
        
    }
}
