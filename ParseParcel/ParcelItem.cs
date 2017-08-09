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
        public decimal Cost { get; set; }
        public decimal Weight { get; set; }

        public ParcelItem(decimal length, decimal breadth, decimal height, decimal weight)
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




}
