using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IApplicationInfo
    {
        string Name { get; }
        Version Version { get; }
    }
}
