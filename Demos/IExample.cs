using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos
{
    public interface IExample
    {
        void Run();
        string Title { get; }
        string Description { get; }
    }
}
