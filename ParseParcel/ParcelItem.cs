using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseParcel
{
    public class ParcelItem
    {
        public Dimension Dimension { get; set; }
        public int Cost { get; set; }
        public int Weight { get; set; }

        public ParcelItem(int length, int breadth, int height, int weight)
        {
            Dimension=new Dimension()
            {
                Length = length,
                Breadth = breadth,
                Height = height
            };
            Weight = weight;
        }
    }

    public enum EnumPackageOption
    {
        Small,Medium,Large
    }


}
