
using System.Text;

namespace Calastone.Service
{
    internal interface ITextFilterService
    {
        void ApplyFilters(StringBuilder fileContent);
    }
}
