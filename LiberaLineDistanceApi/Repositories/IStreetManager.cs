using System.Collections.Generic;

namespace LiberaLineDistanceApi.Repositories
{
    public interface IStreetManager
    {
        void Add(StreetDto street);

        List<string> GetClosest(double x, double y);
    }
}