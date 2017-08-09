using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ParseParcel
{
    public class BoxPackageType: PackageTypeBase
    {
        public override bool CanContain(ParcelItem parcelItem)
        {
            var dimentsionBoxList = new List<decimal> { Dimension.Length, Dimension.Breadth, Dimension.Height };
            var  dimensionItemList = new List<decimal> { parcelItem.Dimension.Length, parcelItem.Dimension.Breadth, parcelItem.Dimension.Height };
            dimensionItemList.Sort();
            dimentsionBoxList.Sort();

            var result = true;
            for (int listCount = 0; listCount < dimensionItemList.Count; listCount++)
            {
                if (dimensionItemList[listCount] > dimentsionBoxList[listCount] || dimensionItemList[listCount] <= 0)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
    }

   
}
