﻿namespace LiberaLineDistanceApi.Repositories
{
    public interface IDistanceStrategy
    {
        double Distance(double x, double y, double x0, double y0, double x1, double y1);
    }
}