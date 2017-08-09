using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace ParseParcel.NUnit.Tests
{
    [TestFixture]
    public class ParcelCostTest
    {
        ICostGenerator costGenreator;

        [SetUp]
        public void Setup()
        {
            costGenreator = new ParcelCostGenerator();
            costGenreator.LoadPackageOptions();
        }

        [Test]
        public void ParcelCost_L0_B0_H0_W0_Output_None_0()
        {
            var item =new ParcelItem(0,0,0,0);
            var result = costGenreator.GetParcelCost(item);
            Assert.AreEqual(0,item.Cost);
            Assert.AreEqual(EnumPackageOption.None, item.PackageOption);
        }


        [Test]
        public void ParcelCost_L601_B1_H1_W1_Output_None_0()
        {
            var item = new ParcelItem(601, 1, 1, 1);
            var result = costGenreator.GetParcelCost(item);
            Assert.AreEqual(0, item.Cost);
        }

        [Test]
        public void ParcelCost_L1_B601_H1_W1_Output_None_0()
        {
            var item = new ParcelItem(1, 601, 1, 1);
            var result = costGenreator.GetParcelCost(item);
            Assert.AreEqual(0, item.Cost);
        }

        [Test]
        public void ParcelCost_L1_B1_H601_W1_Output_None_0()
        {
            var item = new ParcelItem(1, 1, 601, 1);
            var result = costGenreator.GetParcelCost(item);
            Assert.AreEqual(0, item.Cost);
        }

        [Test]
        public void ParcelCost_L1_B1_H1_W26_Output_None_0()
        {
            var item = new ParcelItem(1, 1, 601, 1);
            var result = costGenreator.GetParcelCost(item);
            Assert.AreEqual(0, item.Cost);
        }


    }
}
