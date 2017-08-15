using MediatR;
using Nester.Sample.Contract.Commands;
using Nester.Sample.Contract.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nester.Sample.Contract.Services
{
    public interface ISumPointsSvc : IRequestHandler<SumPoints, Point>
    {
    }
}
