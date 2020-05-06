using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Services
{
    public class ApplicationInfo : IApplicationInfo
    {
        public ApplicationInfo(Assembly assmbly)
        {
            var product = assmbly.GetCustomAttributes(typeof(AssemblyProductAttribute))
                .OfType<AssemblyProductAttribute>()
                .FirstOrDefault();

            Name = product?.Product;

            var versionInfo = FileVersionInfo.GetVersionInfo(assmbly.Location);
            Version = Version.Parse(versionInfo.FileVersion);
        }

        public string Name { get; }

        public Version Version { get; }
    }
}
