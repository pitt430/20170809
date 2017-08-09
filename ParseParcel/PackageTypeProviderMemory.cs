using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseParcel
{
    public class PackageTypeProviderMemory:IPackageTypeProvider
    {
        public List<PackageType> LoadPackageTypes()
        {
            var result = new List<PackageType>();
            result.Add(new PackageType()
            {
                Dimension = new Dimension()
                {
                    Length = 200,
                    Breadth = 300,
                    Height = 150
                },
                Cost = 5,
                PackageSize = EnumPackageSize.Small
            });

            result.Add(new PackageType()
            {
                Dimension = new Dimension()
                {
                    Length = 300,
                    Breadth = 400,
                    Height = 200
                },
                Cost = 7.5,
                PackageSize = EnumPackageSize.Medium
            });
            result.Add(new PackageType()
            {
                Dimension = new Dimension()
                {
                    Length = 400,
                    Breadth = 600,
                    Height = 250
                },
                Cost = 8.5,
                PackageSize = EnumPackageSize.Large
            });

            return result;
        }
    }
}
