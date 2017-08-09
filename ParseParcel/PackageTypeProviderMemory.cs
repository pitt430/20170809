using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseParcel
{
    public class PackageTypeProviderMemory:IPackageTypeProvider
    {
        private readonly PackageTypeFactory _packageTypeFactory;
        public PackageTypeProviderMemory(PackageTypeFactory packageTypeFactory)
        {
            _packageTypeFactory = packageTypeFactory;
        }
        public List<PackageTypeBase> LoadPackageTypes()
        {
            var result = new List<PackageTypeBase>();
            var packageType = _packageTypeFactory.GetPackageType();
            packageType.Dimension = new Dimension()
            {
                Length = 200,
                Breadth = 300,
                Height = 150
            };
            packageType.Cost = 5;
            packageType.PackageSize = EnumPackageSize.Small;
            result.Add(packageType);

            packageType.Dimension = new Dimension()
            {
                Length = 300,
                Breadth = 400,
                Height = 200
            };
            packageType.Cost = 7.5m;
            packageType.PackageSize = EnumPackageSize.Medium;
            result.Add(packageType);

            packageType.Dimension = new Dimension()
            {
                Length = 400,
                Breadth = 600,
                Height = 250
            };
            packageType.Cost = 8.5m;
            packageType.PackageSize = EnumPackageSize.Large;
            result.Add(packageType);

            return result;
        }
    }
}
