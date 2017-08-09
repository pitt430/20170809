using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseParcel
{
    public class ParcelCostGenerator:ICostGenerator
    {
        public ParcelItem GetParcelCost(ParcelItem item)
        {
            
        }

        public CheckDeminsionAdapable(Dimension dimensionA, Dimension dimensionB)
        {
            
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
               Cost = 5
            });

            result.Add(new PackageType()
            {
                Dimension = new Dimension()
                {
                    Length = 300,
                    Breadth = 400,
                    Height = 200
                },
                Cost = 7.5
            });
            result.Add(new PackageType()
            {
                Dimension = new Dimension()
                {
                    Length = 400,
                    Breadth = 600,
                    Height = 250
                },
                Cost = 8.5
            });

            return result;
        }
    }
}
