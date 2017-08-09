using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseParcel
{
    public class ParcelCostGenerator : ICostGenerator
    {

        public PackageType GetParcelCost(ParcelItem item)
        {

            if (item.Weight > 25)
            {
                return new PackageType()
                {
                    PackageSize = EnumPackageSize.None,
                    Cost = 0
                };
            }
            var allPackageTypes = LoadPackageTypes();
            var matchedPackageType = allPackageTypes.Find(a => CheckDeminsionAdapable(item.Dimension, a.Dimension));
            if (matchedPackageType != null)
            {
                return matchedPackageType;
            }
            else
            {
                return new PackageType()
                {
                    PackageSize = EnumPackageSize.None,
                    Cost = 0
                };
            }
        }

        public bool CheckDeminsionAdapable(Dimension dimensionItem, Dimension dimensionBox)
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
        
        public List<PackageType> LoadPackageTypes()
        {
            var result=new List<PackageType>();
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
