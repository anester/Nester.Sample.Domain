using Nester.Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nester.Sample.Domain.Data
{
    public interface IPointRepo
    {
        IEnumerable<Point> GetAll(int min, int max);
        Point Get(int x, int y);
    }
}
