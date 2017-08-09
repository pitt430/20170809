using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseParcel
{
    public class ParcelCostGenerator : ICostGenerator
    {
        private readonly IPackageTypeProvider _packageTypeProvider;
        private readonly PackageTypeFactory _packageTypeFactory;

        public ParcelCostGenerator(IPackageTypeProvider packageTypeProvider, PackageTypeFactory packageTypeFactory)
        {
            _packageTypeProvider = packageTypeProvider;
            _packageTypeFactory = packageTypeFactory;
        }

        public PackageTypeBase GetCost(ParcelItem item)
        {
            var noSolution = _packageTypeFactory.GetPackageType();
            noSolution.PackageSize = EnumPackageSize.None;
            noSolution.Cost = 0;

            if (item.Weight > 25)
            {
              return noSolution;
            }
            var allPackageTypes = _packageTypeProvider.LoadPackageTypes().OrderBy(a=>a.Cost);
            var matchedPackageType = allPackageTypes.First(package => package.CanContain(item));
            if (matchedPackageType != null)
            {
                return matchedPackageType;
            }
            else
            {
                return noSolution;
            }
        }


       

    }
}
