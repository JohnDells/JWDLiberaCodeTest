using System;

namespace LiberaLineDistanceApi.Repositories
{
    public class DistanceStrategy : IDistanceStrategy
    {
        public double Distance(double x, double y, double x0, double y0, double x1, double y1)
        {
            var result = ObtuseValue(x, y, x0, y0, x1, y1);
            if (result != null) return (double)result;

            if (x0 != x1)
            {
                var slope = (y1 - y0) / (x1 - x0);
                var a = -1 * slope;
                var c = slope * x0 - y0;

                var d = Math.Abs(a * x + y + c) / Math.Sqrt(Math.Pow(a, 2) + 1);
                return d;
            }
            else
            {
                //  Slope is infinite, so we just return x offset.
                return x - x0;
            }
        }

        private double? ObtuseValue(double x, double y, double x0, double y0, double x1, double y1)
        {
            double? resultSquared = null;

            //  NOTE:  We're using the a^2 + b^2 < c^2 test to determine if the triangle is obtuse.

            var lineLengthSquared = LineLengthSquared(x0, y0, x1, y1);
            var pointToStartLengthSquared = LineLengthSquared(x, y, x0, y0);
            var pointToEndLengthSquared = LineLengthSquared(x, y, x1, y1);

            //  If the line length is the biggest, we don't have an obtuse triangle.
            if (lineLengthSquared < pointToStartLengthSquared || lineLengthSquared < pointToEndLengthSquared)
            {
                if (pointToStartLengthSquared > pointToEndLengthSquared)
                {
                    var isObtuse = pointToStartLengthSquared > lineLengthSquared + pointToEndLengthSquared;
                    if (isObtuse) resultSquared = pointToEndLengthSquared;
                }
                else
                {
                    var isObtuse = pointToEndLengthSquared > lineLengthSquared + pointToStartLengthSquared;
                    if (isObtuse) resultSquared = pointToStartLengthSquared;
                }
            }

            return resultSquared != null ? Math.Sqrt((double)resultSquared) : (double?)null;
        }

        private double LineLengthSquared(double x0, double y0, double x1, double y1)
        {
            return Math.Pow(y1 - y0, 2) + Math.Pow(x1 - x0, 2);
        }
    }
}