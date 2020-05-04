using LiberaLineDistanceApi.Repositories;
using NUnit.Framework;

namespace LiberaLineDistanceApiTest
{
    public class DistanceStrategyTests
    {
        [Test]
        public void Distance_Is_Correct()
        {
            var strategy = new DistanceStrategy();

            //  XAxis (slope = zero) to point [1,1]
            Assert.AreEqual(1, strategy.Distance(1, 1, 0, 0, 2, 0));

            //  XAxis (slope = zero) to point [1,1]
            Assert.AreEqual(1, strategy.Distance(1, 1, 0, 0, 4, 0));

            //  XAxis (slope = zero) to point on line.
            Assert.AreEqual(0, strategy.Distance(1, 0, 0, 0, 4, 0));

            //  1 up from XAxis (slope = zero) to point [1, 2]
            Assert.AreEqual(1, strategy.Distance(1, 2, 0, 1, 2, 1));

            //  1 up from XAxis (slope = zero) to point [1, 2]
            Assert.AreEqual(1, strategy.Distance(1, 2, 0, 1, 2, 1));
        }

        [Test]
        public void Distance_When_Point_Is_On_Line()
        {
            var strategy = new DistanceStrategy();

            Assert.AreEqual(0, strategy.Distance(1, 0, 0, 0, 2, 0));
            Assert.AreEqual(0, strategy.Distance(1, 1, 2, 0, 0, 2));
        }

        [Test]
        public void Distance_When_Point_Is_Endpoint()
        {
            var strategy = new DistanceStrategy();

            Assert.AreEqual(0, strategy.Distance(1, 0, 1, 0, 2, 0));
            Assert.AreEqual(0, strategy.Distance(0, 2, 2, 0, 0, 2));
        }

        [Test]
        public void Distance_Is_Correct_Negative()
        {
            var strategy = new DistanceStrategy();

            //  XAxis (slope = zero) to point [1,-1]
            Assert.AreEqual(1, strategy.Distance(1, -1, 0, 0, 2, 0));

            //  1 up from XAxis (slope = zero) to point [1,-1]
            Assert.AreEqual(2, strategy.Distance(1, -1, 0, 1, 2, 1));
        }

        [Test]
        public void Distance_Is_Correct_Vertical()
        {
            var strategy = new DistanceStrategy();

            //  YAxis (slope = infinite) to point [1, 1]
            Assert.AreEqual(1, strategy.Distance(1, 1, 0, 0, 0, 2));

            //  YAxis (slope = infinite) to point on line.
            Assert.AreEqual(0, strategy.Distance(0, 1, 0, 0, 0, 2));

            //  YAxis (slope = infinite) to point [1, 1]
            Assert.AreEqual(2, strategy.Distance(2, 1, 0, 0, 0, 4));

            //  1 right of YAxis (slope = infinite) to point [2, 1]
            Assert.AreEqual(2, strategy.Distance(3, 1, 1, 0, 1, 2));
        }

        [Test]
        public void Distance_Is_Correct_To_Endpoint()
        {
            var strategy = new DistanceStrategy();

            //  Horizontal
            Assert.AreEqual(5, strategy.Distance(-3, 4, 0, 0, 2, 0));
            Assert.AreEqual(5, strategy.Distance(3, 4, 0, 0, -2, 0));
            Assert.AreEqual(5, strategy.Distance(-3, -4, 0, 0, 2, 0));
            Assert.AreEqual(5, strategy.Distance(-2, -4, 1, 0, 3, 0));

            //  Vertical
            Assert.AreEqual(5, strategy.Distance(-3, -4, 0, 0, 0, 2));
            Assert.AreEqual(5, strategy.Distance(-3, -4, 0, 0, 0, 2));

            //  Slope
            Assert.AreEqual(2, strategy.Distance(-2, 2, 2, 0, 0, 2));
            Assert.AreEqual(2, strategy.Distance(4, 0, 2, 0, 0, 2));
        }
    }
}