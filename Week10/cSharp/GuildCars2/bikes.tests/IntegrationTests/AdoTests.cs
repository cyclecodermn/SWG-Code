using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bikes.data.ADO;
using bikes.models.Queries;
using bikes.models.Tables;
using NUnit.Framework;

namespace bikes.tests.IntegrationTests
{
    [TestFixture]
    public class AdoTests
    {
        [SetUp]
        public void Init()
        {
            using (var cn =
                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd= new SqlCommand();
                cmd.CommandText = "DbReset";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
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

            Assert.AreEqual("RidgeBack", Models[1].BikeModel);
        }

        [Test]
        public void CanLoadBike()
        {
            var repo = new BikeRepoADO();
            var bike = repo.GetById(1);

            Assert.IsNotNull(bike);
//            Assert.AreEqual(1, bike.BikeId);
            Assert.AreEqual(2, bike.BikeMakeId);
            Assert.AreEqual(2, bike.BikeFrameColorId);
            Assert.AreEqual(1, bike.BikeTrimColorId);
            Assert.AreEqual(1, bike.BikeFrameId);
            Assert.AreEqual(1111.00M, bike.BikeMsrp);
            Assert.AreEqual(1100.00M, bike.BikeListPrice);
            Assert.AreEqual(2019, bike.BikeYear);
            Assert.AreEqual(true,bike.BikeIsNew);
            Assert.AreEqual(10, bike.BikeCondition);
            Assert.AreEqual(18, bike.BikeNumGears);
            Assert.AreEqual("1111111", bike.BikeSerialNum);
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

            BikeToAdd.BikeId =
            BikeToAdd.BikeMakeId = 3;
            BikeToAdd.BikeModelId = 3;
            BikeToAdd.BikeFrameColorId = 3;
            BikeToAdd.BikeTrimColorId = 3;
            BikeToAdd.BikeFrameId = 3;
            BikeToAdd.BikeMsrp = 3333.00M;
            BikeToAdd.BikeListPrice = 2222.00M;
            BikeToAdd.BikeYear = 2019;
            BikeToAdd.BikeIsNew = true;
            BikeToAdd.BikeCondition = 10;
            BikeToAdd.BikeNumGears = 1;
            BikeToAdd.BikeSerialNum = "34567890";
            BikeToAdd.BikeDescription = "New bike added from Cs";
            BikeToAdd.BikePictName = "bike3.png";

            repo.Insert(BikeToAdd);
            Assert.AreEqual(11,BikeToAdd.BikeId);

        }

        [Test]
        public void CanUpdateBike()
        {
            BikeTable BikeToAdd = new BikeTable();
            var repo = new BikeRepoADO();

            BikeToAdd.BikeMakeId = 3;
            BikeToAdd.BikeModelId = 3;
            BikeToAdd.BikeFrameColorId = 3;
            BikeToAdd.BikeTrimColorId = 3;
            BikeToAdd.BikeFrameId = 3;
            BikeToAdd.BikeMsrp = 3333.00M;
            BikeToAdd.BikeListPrice = 2222.00M;
            BikeToAdd.BikeYear = 2019;
            BikeToAdd.BikeIsNew = true;
            BikeToAdd.BikeCondition = 10;
            BikeToAdd.BikeNumGears = 1;
            BikeToAdd.BikeSerialNum = "34567890";
            BikeToAdd.BikeDescription = "New bike added from Cs";
            BikeToAdd.BikePictName = "bike3.png";

            repo.Insert(BikeToAdd);

            BikeTable BikeToUpdate = new BikeTable();

            BikeToAdd.BikeMakeId = 1;
            BikeToAdd.BikeModelId = 1;
            BikeToAdd.BikeFrameColorId = 1;
            BikeToAdd.BikeTrimColorId = 2;
            BikeToAdd.BikeFrameId = 1;
            BikeToAdd.BikeMsrp = 1234.00M;
            BikeToAdd.BikeListPrice = 1122.00M;
            BikeToAdd.BikeYear = 2018;
            BikeToAdd.BikeIsNew = false;
            BikeToAdd.BikeCondition = 8;
            BikeToAdd.BikeNumGears = 2;
            BikeToAdd.BikeSerialNum = "45678901";
            BikeToAdd.BikeDescription = "Upadeted info from Cs";
            BikeToAdd.BikePictName = "bike-update.png";

            repo.Update(BikeToAdd);

            var updatedBike = repo.GetById(3);

            Assert.AreEqual(1, BikeToAdd.BikeMakeId);
            Assert.AreEqual(1, BikeToAdd.BikeModelId);
            Assert.AreEqual(1, BikeToAdd.BikeFrameColorId);
            Assert.AreEqual(2, BikeToAdd.BikeTrimColorId);
            Assert.AreEqual(1, BikeToAdd.BikeFrameId);
            Assert.AreEqual(1234.00M, BikeToAdd.BikeMsrp);
            Assert.AreEqual(1122.00M, BikeToAdd.BikeListPrice);
            Assert.AreEqual(2018, BikeToAdd.BikeYear);
            Assert.AreEqual(false, BikeToAdd.BikeIsNew);
            Assert.AreEqual(8, BikeToAdd.BikeCondition);
            Assert.AreEqual(2, BikeToAdd.BikeNumGears);
            Assert.AreEqual("45678901", BikeToAdd.BikeSerialNum);
            Assert.AreEqual("Upadeted info from Cs", BikeToAdd.BikeDescription);
            Assert.AreEqual("bike-update.png", BikeToAdd.BikePictName);
        }

        [Test]
        public void CanDeleteBike()
        {
            BikeTable BikeToAdd = new BikeTable();
            var repo = new BikeRepoADO();

            BikeToAdd.BikeMakeId = 3;
            BikeToAdd.BikeModelId = 3;
            BikeToAdd.BikeFrameColorId = 3;
            BikeToAdd.BikeTrimColorId = 3;
            BikeToAdd.BikeFrameId = 3;
            BikeToAdd.BikeMsrp = 0.00M;
            BikeToAdd.BikeListPrice = 0.00M;
            BikeToAdd.BikeYear = 1984;
            BikeToAdd.BikeIsNew = true;
            BikeToAdd.BikeCondition = 0;
            BikeToAdd.BikeNumGears = 1;
            BikeToAdd.BikeSerialNum = "000000";
            BikeToAdd.BikeDescription = "New bike added from Cs for delete test";
            BikeToAdd.BikePictName = "delete.png";

            repo.Insert(BikeToAdd);

            var loaded = repo.GetById(3);
            Assert.IsNotNull(loaded);

            repo.Delete(3);
            loaded = repo.GetById(3);
            Assert.IsNull(loaded);
        }

        [Test]
        public void CanGetBikeDetails()
        {
            InvDetailedItem oneBike = null;
            var repo = new BikeRepoADO();

            oneBike = repo.GetBikeDetails(1);

          //  Assert.AreEqual(2, oneBike.BikeFrameColorId);
           // Assert.AreEqual(1, oneBike.BikeTrimColorId);
            Assert.AreEqual(1111.00M, oneBike.BikeSmrp);
            Assert.AreEqual(1100.00M, oneBike.BikeListPrice);
            Assert.AreEqual(2019, oneBike.BikeYear);
            Assert.AreEqual(true, oneBike.BikeIsNew);
            Assert.AreEqual(10, oneBike.BikeCondition);
            Assert.AreEqual(18, oneBike.BikeNumGears);
            Assert.AreEqual("1111111", oneBike.BikeSerialNum);
            Assert.AreEqual("Fresh out of the box", oneBike.BikeDescription);
            Assert.AreEqual("LongHaulTruckerPic1.jpg", oneBike.BikePictName);


            Assert.AreEqual("Surley", oneBike.BikeMake);
            Assert.AreEqual("Long Haul Trucker", oneBike.BikeModel);
            Assert.AreEqual("Light Grey", oneBike.FrameColor);
            Assert.AreEqual("White", oneBike.TrimColor);

            Assert.IsNotNull(oneBike);
        }
    }
}
