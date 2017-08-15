using MediatR;
using Nester.Sample.Contract.Models;
using Nester.Sample.Contract.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nester.Sample.Consumer
{
    public class PointWorker
    {
        private readonly IMediator _mediator;

        public PointWorker(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void DoWork(StringBuilder sb)
        {
            var res = _mediator.Send(new Contract.Commands.CreatePoints { Xs = new int[] { 1, 2 }, Ys = new int[] { 3, 4 } }).Result;
            var sum = _mediator.Send(new Contract.Commands.SumPoints { Points = res }).Result;
            sb.AppendLine($"{sum.X} {sum.Y}");
        }

        public Point GetPoint(int x, int y)
        {
            return _mediator.Send(new Contract.Commands.QueryPoint { X = x, Y = y }).Result;
        }
    }
}
