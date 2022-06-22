using System.Text;

namespace CalastoneAssignment.Filters
{
    public class TFilter : IFilter
    {
        public void ApplyFilter(StringBuilder fileContent, string word)
        {
            if (word.IndexOf('T', StringComparison.OrdinalIgnoreCase) >= 0)
            {
                fileContent.Replace($" {word} ", " ");
            }
        }
    }
}
