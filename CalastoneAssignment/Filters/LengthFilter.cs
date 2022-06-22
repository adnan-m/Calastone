using System.Text;

namespace CalastoneAssignment.Filters
{
    public class LengthFilter : IFilter
    {
        public void ApplyFilter(StringBuilder fileContent, string word)
        {
            if (word.Length < 3 )
            {
                fileContent.Replace($" {word} ", " ");
            }
        }
    }
}
