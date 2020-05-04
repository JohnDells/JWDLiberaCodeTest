using System.Collections.Generic;
using System.Linq;

namespace LiberaLineDistanceApi.Repositories
{
    public class StreetManager : IStreetManager
    {
        private readonly IStreetRepository _repository;
        private readonly IDistanceStrategy _strategy;

        public StreetManager(IStreetRepository repository, IDistanceStrategy strategy)
        {
            _repository = repository;
            _strategy = strategy;
        }

        public void Add(StreetDto street)
        {
            _repository.Add(street);
        }

        public List<string> GetClosest(double x, double y)
        {
            var streets = _repository.GetAll();

            var result = new List<StreetDto>();
            double? distance = null;

            foreach (var street in streets)
            {
                var x0 = street.Start[0];
                var x1 = street.End[0];
                var y0 = street.Start[1];
                var y1 = street.End[1];

                var streetDistance = _strategy.Distance(x, y, x0, y0, x1, y1);
                if (distance == null || streetDistance < distance)
                {
                    result = new List<StreetDto> { street };
                    distance = streetDistance;
                } else if (distance == null || streetDistance == distance)
                {
                    result.Add(street);
                }
            }

            return result.Select(x => x.Name).ToList();
        }
    }
}