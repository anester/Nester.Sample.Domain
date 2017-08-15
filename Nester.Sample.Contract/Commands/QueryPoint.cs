using MediatR;
using Nester.Sample.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nester.Sample.Contract.Commands
{
    public class QueryPoint : IRequest<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
