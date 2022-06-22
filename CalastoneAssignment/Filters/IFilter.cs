using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalastoneAssignment.Filters
{
    public interface IFilter
    {
        void ApplyFilter(StringBuilder fileContent, string word);
    }
}
