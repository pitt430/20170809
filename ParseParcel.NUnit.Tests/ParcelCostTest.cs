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
            costGenreator.LoadPackageTypes();
        }


        // 0 or less than 0
        [Test]
        public void ParcelCost_L0_B0_H0_W0_OutputNone()
        {
            var item =new ParcelItem(0,0,0,0);
            var result = costGenreator.GetParcelCost(item);
            Assert.AreEqual(0,result.Cost);
            Assert.AreEqual(EnumPackageSize.None, result.PackageSize);
        }


        public void ParcelCost_L1_B1_H1_W0_OutputNone()
        {
            var item = new ParcelItem(1, 1, 1, 0);
            var result = costGenreator.GetParcelCost(item);
            Assert.AreEqual(0, result.Cost);
            Assert.AreEqual(EnumPackageSize.None, result.PackageSize);
        }
        public void ParcelCost_LMinus1_B0_H0_W0_OutputNone()
        {
            var item = new ParcelItem(-1, 0, 0, 0);
            var result = costGenreator.GetParcelCost(item);
            Assert.AreEqual(0, result.Cost);
            Assert.AreEqual(EnumPackageSize.None, result.PackageSize);
        }

        //weight more than 25

        [Test]
        public void ParcelCost_L1_B1_H1_W26_OutputNone()
        {
            var item = new ParcelItem(1, 1, 1, 26);
            var result = costGenreator.GetParcelCost(item);
            Assert.AreEqual(0, result.Cost);
            Assert.AreEqual(EnumPackageSize.None, result.PackageSize);
        }

        //Range in samll box
        [Test]
        public void ParcelCost_L1_B1_H1_W1_OutputSmall()
        {
            var item = new ParcelItem(1, 1, 1, 1);
            var result = costGenreator.GetParcelCost(item);
            Assert.AreEqual(5, result.Cost);
            Assert.AreEqual(EnumPackageSize.Small, result.PackageSize);
        }

        [Test]
        public void ParcelCost_L300_B200_H150_W1_OutpuSmall()
        {
            var item = new ParcelItem(300, 200, 150, 1);
            var result = costGenreator.GetParcelCost(item);
            Assert.AreEqual(5, result.Cost);
            Assert.AreEqual(EnumPackageSize.Small, result.PackageSize);
        }

        //Range in Medium box
        [Test]
        public void ParcelCost_L301_B200_H150_W1_OutputMedium()
        {
            var item = new ParcelItem(301, 200, 150, 1);
            var result = costGenreator.GetParcelCost(item);
            Assert.AreEqual(7.5, result.Cost);
            Assert.AreEqual(EnumPackageSize.Medium, result.PackageSize);
        }

        [Test]
        public void ParcelCost_L300_B201_H150_W1_OutputMedium()
        {
            var item = new ParcelItem(300, 201, 150, 1);
            var result = costGenreator.GetParcelCost(item);
            Assert.AreEqual(7.5, result.Cost);
            Assert.AreEqual(EnumPackageSize.Medium, result.PackageSize);
        }

        [Test]
        public void ParcelCost_L300_B200_H151_W1_OutputMedium()
        {
            var item = new ParcelItem(300, 200, 151, 1);
            var result = costGenreator.GetParcelCost(item);
            Assert.AreEqual(7.5, result.Cost);
            Assert.AreEqual(EnumPackageSize.Medium, result.PackageSize);
        }



        [Test]
        public void ParcelCost_L400_B300_H200_W1_OutputMedium()
        {
            var item = new ParcelItem(400, 300, 200, 1);
            var result = costGenreator.GetParcelCost(item);
            Assert.AreEqual(7.5, result.Cost);
            Assert.AreEqual(EnumPackageSize.Medium, result.PackageSize);
        }

        [Test]
        //range for large box
        public void ParcelCost_L400_B300_H201_W1_OutputLarge()
        {
            var item = new ParcelItem(400, 300, 201, 1);
            var result = costGenreator.GetParcelCost(item);
            Assert.AreEqual(8.5, result.Cost);
            Assert.AreEqual(EnumPackageSize.Large, result.PackageSize);
        }

        [Test]
        public void ParcelCost_L400_B301_H200_W1_OutputLarge()
        {
            var item = new ParcelItem(400, 301, 200, 1);
            var result = costGenreator.GetParcelCost(item);
            Assert.AreEqual(8.5, result.Cost);
            Assert.AreEqual(EnumPackageSize.Large, result.PackageSize);
        }

        [Test]
        public void ParcelCost_L401_B300_H200_W1_OutputLarge()
        {
            var item = new ParcelItem(401, 300, 200, 1);
            var result = costGenreator.GetParcelCost(item);
            Assert.AreEqual(8.5, result.Cost);
            Assert.AreEqual(EnumPackageSize.Large, result.PackageSize);
        }

        [Test]
        public void ParcelCost_L600_B400_H250_W1_OutputLarge()
        {
            var item = new ParcelItem(600, 400, 250, 1);
            var result = costGenreator.GetParcelCost(item);
            Assert.AreEqual(8.5, result.Cost);
            Assert.AreEqual(EnumPackageSize.Large, result.PackageSize);
        }

        //Range out of space

        [Test]
        public void ParcelCost_L601_B400_H250_W1_OutputNone()
        {
            var item = new ParcelItem(601, 400, 250, 1);
            var result = costGenreator.GetParcelCost(item);
            Assert.AreEqual(0, result.Cost);
            Assert.AreEqual(EnumPackageSize.None, result.PackageSize);
        }

        [Test]
        public void ParcelCost_L600_B401_H250_W1_OutputNone()
        {
            var item = new ParcelItem(600, 401, 250, 1);
            var result = costGenreator.GetParcelCost(item);
            Assert.AreEqual(0, result.Cost);
            Assert.AreEqual(EnumPackageSize.None, result.PackageSize);
        }

        [Test]
        public void ParcelCost_L600_B400_H251_W1_OutputNone()
        {
            var item = new ParcelItem(600, 400, 251, 1);
            var result = costGenreator.GetParcelCost(item);
            Assert.AreEqual(0, result.Cost);
            Assert.AreEqual(EnumPackageSize.None, result.PackageSize);
        }


    }
}
