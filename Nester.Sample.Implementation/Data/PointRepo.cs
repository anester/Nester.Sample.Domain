using Nester.Sample.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nester.Sample.Domain.Models;

namespace Nester.Sample.Implementation.Data
{
    public class PointRepo : IPointRepo
    {
        public Point Get(int x, int y)
        {
            return new Point() { X = x, Y = y };
        }

        public IEnumerable<Point> GetAll(int min, int max)
        {
            List<Point> ret = new List<Point>();
            for (int i = min; i <= max; i++)
            {
                ret.Add(new Point { X = i, Y = i });
            }
            return ret;
        }
    }
}
