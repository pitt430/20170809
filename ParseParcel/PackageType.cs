using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ParseParcel
{
    public class PackageType
    {
        public Dimension Dimension { get; set; }

        public double Cost { get; set; }

        public EnumPackageSize PackageSize { get; set; }
    }

    public enum EnumPackageSize
    {
        None,Small, Medium, Large
    }
}
