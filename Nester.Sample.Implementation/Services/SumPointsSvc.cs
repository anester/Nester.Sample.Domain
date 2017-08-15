using Nester.Sample.Contract.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nester.Sample.Contract.Commands;
using Nester.Sample.Contract.Models;

namespace Nester.Sample.Implementation.Services
{
    public class SumPointsSvc : ISumPointsSvc
    {
        public Point Handle(SumPoints message)
        {
            Point ret = new Point() { X = 0, Y = 0 };
            foreach (var point in message.Points)
            {
                ret.X += point.X;
                ret.Y += point.Y;
            }
            return ret;
        }
    }
}
