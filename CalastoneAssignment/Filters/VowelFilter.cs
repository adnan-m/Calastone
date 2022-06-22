using Calastone.Constant;
using System.Text;
using System.Text.RegularExpressions;

namespace CalastoneAssignment.Filters
{
    public class VowelFilter : IFilter
    {        
        public void ApplyFilter(StringBuilder fileContent, string word)
        {
            if (FindVowel(word))
            {
                fileContent.Replace($" {word} ", " ");
            }
        }

        private bool FindVowel(string input)
        {

            if (Regex.IsMatch(input, Constants.regExpVowelAtEnds))
            {
                return false;
            }

            var offset = input.Length % 2 == 0 ? 1 : 0;
            var middle = input.Substring(input.Length / 2 - offset, offset + 1);

            if (Regex.IsMatch(middle, Constants.regExpVowel))
            {
                return true;
            }
            return false;
        }
    }
}
