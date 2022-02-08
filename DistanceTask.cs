using System;

namespace DistanceTask
{
	public static class DistanceTask
	{
		// Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
		public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
		{
			double cosA = ((ax - x) * (ax - x) + (ay - y) * (ay - y) + (ax - bx) * (ax - bx) + (ay - by) * (ay - by) - (bx - x) * (bx - x) - (by - y) * (by - y)) / (2 * Math.Sqrt(((ax - x) * (ax - x) + (ay - y) * (ay - y)) * ((ax - bx) * (ax - bx) + (ay - by) * (ay - by))));
			double cosB = ((bx - x) * (bx - x) + (by - y) * (by - y) + (ax - bx) * (ax - bx) + (ay - by) * (ay - by) - (ax - x) * (ax - x) - (ay - y) * (ay - y)) / (2 * Math.Sqrt(((bx - x) * (bx - x) + (by - y) * (by - y))*((ax - bx) * (ax - bx) + (ay - by) * (ay - by))));
			double xNormal;
			double yNormal; 
      if (ax == bx && ay == by)
      {
        return Math.Sqrt((ax - x) * (ax - x) + (ay - y) * (ay - y));
      }
      else if ((x - bx) / (ax - bx) == (y - by) / (ay - by) && (ax <= x && x <= bx || ax >= x && x >= bx) && (ay <= y && y <= by || ay >= y && y >= by))
      {
				return 0.0; 
			}
      else if (cosA < 0 || cosB < 0)
      {
        if (Math.Sqrt((ax - x) * (ax - x) + (ay - y) * (ay - y)) > Math.Sqrt((bx - x) * (bx - x) + (by - y) * (by - y)))
        {
					return Math.Sqrt((bx - x) * (bx - x) + (by - y) * (by - y));
				}
        else
        {
					return Math.Sqrt((ax - x) * (ax - x) + (ay - y) * (ay - y));
				}
      }
			else
      {
        if (ax - bx == 0)
        {
          xNormal = bx;
          yNormal = y;
        }
        else if (ay - by == 0)
        {
          xNormal = x;
          yNormal = by;
        }
        else
        {
          yNormal = ((((ax - bx) * (ax - bx)) / (ay - by)) * by + (ax - bx) * (x - bx) + (ay - by) * y) / ((((ax - bx) * (ax - bx)) / (ay - by)) + (ay - by));
          xNormal = ((ax - bx) / (ay - by)) * (yNormal - by) + bx;
        }
        return Math.Sqrt((xNormal - x) * (xNormal - x) + (yNormal - y) * (yNormal - y));
      }
		}
	}
}