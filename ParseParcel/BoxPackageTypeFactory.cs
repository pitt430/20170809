using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseParcel
{
    public class BoxPackageTypeFactory : PackageTypeFactory
    {
        public override PackageTypeBase GetPackageType()
        {
            return new BoxPackageType();
        }
    }
}
