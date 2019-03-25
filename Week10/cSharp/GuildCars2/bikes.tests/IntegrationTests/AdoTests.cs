using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bikes.data.ADO;
using bikes.models.Tables;
using NUnit.Framework;

namespace bikes.tests.IntegrationTests
{
    [TestFixture]
    public class AdoTests
    {
        [Test]
        public void CanLoadFrames()
        {
            var repo = new FrameRepoADO();
            var frames = repo.GetAll();

            int frameCount = frames.Count();
            Assert.AreEqual(3, frameCount);

            Assert.AreEqual("Touring", frames[0].BikeFrame);
        }

        [Test]
        public void CanLoadModels()
        {
            var repo = new ModelRepoADO();
            var Models = repo.GetAll();

            int ModelCount = Models.Count();
            Assert.AreEqual(3, ModelCount);

            Assert.AreEqual("Long Haul Trucker", Models[1].BikeModel);
        }

        [Test]
        public void CanLoadBike()
        {
            var repo = new BikeRepoADO();
            var bike = repo.GetById(1);

            Assert.IsNotNull(bike);
            Assert.AreEqual(1, bike.BikeId);
            Assert.AreEqual(1, bike.BikeMakeId);
            Assert.AreEqual(1, bike.BikeFrameColorId);
            Assert.AreEqual(1, bike.BikeTrimColorId);
            Assert.AreEqual(1, bike.BikeFrameId);
            Assert.AreEqual(1000.00M, bike.BikeMsrp);
            Assert.AreEqual(990.00M, bike.BikeListPrice);
            Assert.AreEqual(2019, bike.BikeYear);
            Assert.AreEqual(true,bike.BikeIsNew);
            Assert.AreEqual(10, bike.BikeCondition);
            Assert.AreEqual(18, bike.BikeNumGears);
            Assert.AreEqual("12345678", bike.BikeSerialNum);
            Assert.AreEqual("Fresh out of the box", bike.BikeDescription);
            Assert.AreEqual("LongHaulTruckerPic1.jpg", bike.BikePictName);
     
            //BikeTable(BikeId, BikeMakeId, BikeModelId, BikeFrameColorId, BikeTrimColorId, BikeFrameId, BikeMsrp, BikeListPrice, BikeYear, BikeIsNew, BikeCondition, BikeNumGears, BikeSerialNum, BikeDescription, BikeDateAdded, BikePictName)

            //(1, 1, 1, 1, 1, 1, 1000.00, 990.00, 2019, 1, 10, 18, 12345678, 'Fresh out of the box', GETDATE(), 'LongHaulTruckerPic1.jpg'),

        }

        [Test]
        public void NotFoundListingReturnsNull()
        {
            var repo=new BikeRepoADO();
            var bike = repo.GetById(999999);
            Assert.IsNull(bike);
        }

        [Test]
        public void CanAddBike()
        {
            BikeTable BikeToAdd = new BikeTable();
            var repo = new BikeRepoADO();

//            BikeToAdd.BikeId =
            BikeToAdd.BikeMakeId = 3;
            BikeToAdd.BikeModelId = 3;
            BikeToAdd.BikeFrameColorId = 3;
            BikeToAdd.BikeTrimColorId = 3;
            BikeToAdd.BikeFrameId = 3;
            BikeToAdd.BikeMsrp = 3333M;
            BikeToAdd.BikeListPrice = 2222M;
            BikeToAdd.BikeYear = 2019;
            BikeToAdd.BikeIsNew = true;
            BikeToAdd.BikeCondition = 10;
            BikeToAdd.BikeNumGears = 1;
            BikeToAdd.BikeSerialNum = "34567890";
            BikeToAdd.BikeDescription = "New bike added from Cs";
            BikeToAdd.BikePictName = "bike3.png";

            repo.Insert(BikeToAdd);
            Assert.AreEqual(4,BikeToAdd.BikeId);

        }
    }
}
