using Nester.Sample.Contract.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nester.Sample.Contract.Commands;
using Nester.Sample.Contract.Models;
using Nester.Sample.Domain.Data;

namespace Nester.Sample.Implementation.Services
{
    public class PointService : IPointService, IQueryPointSvc, ICreatePointsSvc
    {
        private readonly IPointRepo _pointRepo;

        public PointService(Domain.Data.IPointRepo pointRepo)
        {
            _pointRepo = pointRepo;
        }

        public IEnumerable<Point> CreatePoints(CreatePoints points)
        {
            List<Point> ret = new List<Point>();
            foreach (var xs in points.Xs)
            {
                foreach (var ys in points.Ys)
                {
                    var rpoint = _pointRepo.Get(xs, ys);
                    ret.Add(new Point { X = rpoint.X, Y = rpoint.Y });
                }
            }

            return ret;
        }

        public Point QueryPoint(QueryPoint point)
        {
            var rp = _pointRepo.Get(point.X, point.Y);
            return new Point { X = rp.X, Y = rp.Y };
        }

        public Point Handle(QueryPoint message)
        {
            return QueryPoint(message);
        }

        public IEnumerable<Point> Handle(CreatePoints message)
        {
            return CreatePoints(message);
        }
    }
}
