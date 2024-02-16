using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSource.Application.Orders.Commands;

public class CreateOrderCommand : IRequest<CreateOrderCommandComplete>
{
    public int? Id { get; set; }
}

public record CreateOrderCommandComplete
{
    public int? Id { get; set; }
}
