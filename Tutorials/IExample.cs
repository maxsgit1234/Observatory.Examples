using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    public interface IExample
    {
        void Run();
        string Title { get; }
        string Description { get; }
    }
}
