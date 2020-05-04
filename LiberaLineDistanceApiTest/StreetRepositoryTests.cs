using LiberaLineDistanceApi.Repositories;
using NUnit.Framework;
using System.Linq;

namespace LiberaLineDistanceApiTest
{
    public class StreetRepositoryTests
    {
        [Test]
        public void Can_Add_Streets()
        {
            var repository = new StreetRepository();

            repository.Add(new StreetDto { Name = "A", Start = new double[] { 1, 1 }, End = new double[] { 2, 2 } });

            Assert.AreEqual(1, repository.GetAll().Count);
            Assert.AreEqual("A", repository.GetAll().Select(x => x.Name).FirstOrDefault());
        }
    }
}