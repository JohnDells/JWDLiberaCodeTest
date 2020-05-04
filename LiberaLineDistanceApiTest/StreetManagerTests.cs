using LiberaLineDistanceApi.Repositories;
using NUnit.Framework;

namespace LiberaLineDistanceApiTest
{
    public class StreetManagerTests
    {
        [Test]
        public void No_Streets_Returns_Nothing()
        {
            var strategy = new DistanceStrategy();
            var repository = new StreetRepository();
            var manager = new StreetManager(repository, strategy);

            var result = manager.GetClosest(0, 0);

            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void Single_Street_Is_Found()
        {
            var strategy = new DistanceStrategy();
            var repository = new StreetRepository();
            var manager = new StreetManager(repository, strategy);

            repository.Add(new StreetDto { Name = "A", Start = new double[] { 1, 1 }, End = new double[] { 2, 2, } });

            var result = manager.GetClosest(0, 0);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("A", result[0]);
        }

        [Test]
        public void Easy_Street_Is_Found()
        {
            var strategy = new DistanceStrategy();
            var repository = new StreetRepository();
            var manager = new StreetManager(repository, strategy);

            //  A horizontal line along the X axis from the origin to 2.
            repository.Add(new StreetDto { Name = "A", Start = new double[] { 0, 0 }, End = new double[] { 2, 0, } });
            //  A horizontal line 1 up from the X axis.
            repository.Add(new StreetDto { Name = "B", Start = new double[] { 0, 1 }, End = new double[] { 2, 1, } });

            //  A point on the Y axis 2 up from the origin.
            var result = manager.GetClosest(0, 2);

            //  The top horizontal line should be returned because it is 1 unit from line B.
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("B", result[0]);
        }


                    [Test]
        public void Multiple_Streets_Are_Found()
        {
            var strategy = new DistanceStrategy();
            var repository = new StreetRepository();
            var manager = new StreetManager(repository, strategy);

            //  A horizontal line along the X axis from the origin to 2.
            repository.Add(new StreetDto { Name = "A", Start = new double[] { 0, 0 }, End = new double[] { 2, 0, } });
            //  A horizontal line 2 up from the X axis.
            repository.Add(new StreetDto { Name = "B", Start = new double[] { 0, 2 }, End = new double[] { 2, 2, } });

            //  A point on the Y axis 2 up from the origin.
            var result = manager.GetClosest(1, 1);

            //  The top horizontal line should be returned because it is 1 unit from line B.
            Assert.AreEqual(2, result.Count);
        }
    }
}