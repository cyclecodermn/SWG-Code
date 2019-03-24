using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bikes.data.ADO;
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
    }
}
