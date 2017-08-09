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
            var smallPackageType = _packageTypeFactory.GetPackageType();
            smallPackageType.Dimension = new Dimension()
            {
                Length = 200,
                Breadth = 300,
                Height = 150
            };
            smallPackageType.Cost = 5;
            smallPackageType.PackageSize = EnumPackageSize.Small;
            result.Add(smallPackageType);
            var mediumPackageType = _packageTypeFactory.GetPackageType();
            mediumPackageType.Dimension = new Dimension()
            {
                Length = 300,
                Breadth = 400,
                Height = 200
            };
            mediumPackageType.Cost = 7.5m;
            mediumPackageType.PackageSize = EnumPackageSize.Medium;
            result.Add(mediumPackageType);

            var largePackageType = _packageTypeFactory.GetPackageType();
            largePackageType.Dimension = new Dimension()
            {
                Length = 400,
                Breadth = 600,
                Height = 250
            };
            largePackageType.Cost = 8.5m;
            largePackageType.PackageSize = EnumPackageSize.Large;
            result.Add(largePackageType);

            return result;
        }
    }
}
