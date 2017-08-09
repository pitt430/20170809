using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseParcel
{
    public abstract class PackageTypeBase
    {
        public Dimension Dimension { get; set; }
        public decimal Cost { get; set; }
        public EnumPackageSize PackageSize { get; set; }
        public abstract bool CanContain(ParcelItem parcelItem);

    }

    public enum EnumPackageSize
    {
        None, Small, Medium, Large
    }
}