using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Services
{
    public class ApplicationStorage : IApplicationStorage
    {
        public static ApplicationStorage Instance { get; } = new ApplicationStorage("AVALDir");
        private ApplicationStorage(string prefixAppPath)
        {
#if DEBUG
            prefixAppPath += "-dev";
#endif

            string BaseDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), prefixAppPath);
            Directory.CreateDirectory(BaseDirectory);

            LogDirectory = Path.Combine(BaseDirectory, "logs");
            Directory.CreateDirectory(LogDirectory);
        }
        public string LogDirectory { get; }
        public string BaseDirectory { get; }
    }
}
