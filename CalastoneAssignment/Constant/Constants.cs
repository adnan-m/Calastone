using System.Xml.Linq;

namespace Calastone.Constant
{
	public class Constants
	{
		public const string regExpVowel = "^*[aeiou].*$";
		public const string regExpVowelAtEnds = "(^[aeiou].*)|(.*[aeiou]$)";		
	}
}