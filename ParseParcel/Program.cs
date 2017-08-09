using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace ParseParcel
{
    class Program
    {
        private static void Main(string[] args)
        {
            var container = new UnityContainer();
            container.RegisterType<ICostGenerator, ParcelCostGenerator>();
            container.RegisterType<IPackageTypeProvider, PackageTypeProviderMemory>().RegisterType<PackageTypeFactory,BoxPackageTypeFactory>();
            while (true)
            {
                try
                {
                    Console.Write("Length(mm):");
                    var length = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Breadth(mm):");
                    var breadth = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Height(mm):");
                    var height = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Weight(kg):");
                    var weight = Convert.ToDecimal(Console.ReadLine());
                    
                    var parcel = new ParcelItem(length, breadth, height, weight);
                    var packageType = container.Resolve<ICostGenerator>().GetCost(parcel);
                    
                    Console.WriteLine($"Package Size: {packageType.PackageSize}, Cost: ${packageType.Cost}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
