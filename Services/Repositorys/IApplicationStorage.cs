using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IApplicationStorage
    {
        string LogDirectory { get;}
        string BaseDirectory { get; }
    }
}
