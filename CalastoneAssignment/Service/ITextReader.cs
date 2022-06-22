using Calastone.Model;
using System.Text;


namespace Calastone.Service
{
    internal interface ITextReader
    {
        void  ReadTextFile(out StringBuilder stringBuilder);       
    }
}
