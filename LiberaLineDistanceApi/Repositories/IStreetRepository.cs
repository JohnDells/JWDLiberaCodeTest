using System.Collections.Generic;

namespace LiberaLineDistanceApi.Repositories
{
    public interface IStreetRepository
    {
        void Add(StreetDto street);

        List<StreetDto> GetAll();
    }
}