using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Src
{
    public class ProjectConfig
    {
        public string ProjectName { get; set; }

        //public string Src { get; set; }

        public string DirectoryName { get; set; }

        //public string Out { get; set; }

        public List<Bundle> Bundles { get; set; }
    }

    public class Bundle
    {
        public string BundleName { get; set; }
        
        public List<string> Files { get; set; }

        public bool Minify { get; set; }
    }
}
