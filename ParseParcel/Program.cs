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
            container.RegisterType<IPackageTypeProvider, PackageTypeProviderMemory>();
            while (true)
            {
                try
                {
                    Console.Write("Length(mm):");
                    var length = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Length(mm):");
                    var breadth = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Length(mm):");
                    var height = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Weight(kg):");
                    var weight = Convert.ToInt32(Console.ReadLine());
                    
                    var parcel = new ParcelItem(length, breadth, height, weight);
                    var packageType = container.Resolve<ICostGenerator>().GetCost(parcel);
                    
                    Console.WriteLine($"Package Size: {packageType.PackageSize.ToString()}, Cost: ${packageType.Cost}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
