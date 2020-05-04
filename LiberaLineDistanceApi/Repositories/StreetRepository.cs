using System.Collections.Generic;

namespace LiberaLineDistanceApi.Repositories
{
    public class StreetRepository : IStreetRepository
    {
        public StreetRepository()
        {
            Streets = new List<StreetDto>();
        }

        private List<StreetDto> Streets { get; set; }

        public void Add(StreetDto street)
        {
            Streets.Add(street);
        }

        public List<StreetDto> GetAll()
        {
            return Streets;
        }
    }
}