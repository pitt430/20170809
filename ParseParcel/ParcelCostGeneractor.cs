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

        public ParcelCostGenerator(IPackageTypeProvider packageTypeProvider)
        {
            _packageTypeProvider = packageTypeProvider;
        }

        public PackageType GetCost(ParcelItem item)
        {
            var noSolution = new PackageType()
            {
                PackageSize = EnumPackageSize.None,
                Cost = 0
            };
            if (item.Weight > 25)
            {
              return noSolution;
            }
            var allPackageTypes = _packageTypeProvider.LoadPackageTypes();
            var matchedPackageType = allPackageTypes.Find(a => CheckDeminsionAdapable(item.Dimension, a.Dimension));
            if (matchedPackageType != null)
            {
                return matchedPackageType;
            }
            else
            {
                return noSolution;
            }
        }

        private bool CheckDeminsionAdapable(Dimension dimensionItem, Dimension dimensionBox)
        {
            var dimensionItemList = new List<decimal> {dimensionItem.Length, dimensionItem.Breadth, dimensionItem.Height};
            var dimentsionBoxList=new List<decimal> { dimensionBox.Length, dimensionBox.Breadth, dimensionBox.Height};
            dimensionItemList.Sort();
            dimentsionBoxList.Sort();

            var result = true;
            for (int listCount = 0; listCount < dimensionItemList.Count; listCount++)
            {
                if (dimensionItemList[listCount] > dimentsionBoxList[listCount] || dimensionItemList[listCount]<=0)
                {
                    result = false;
                }
            }
            return result;
        }
       

    }
}
