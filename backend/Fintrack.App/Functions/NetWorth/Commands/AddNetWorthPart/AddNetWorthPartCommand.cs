using Fintrack.App.Functions.NetWorth.Models;
using MediatR;

namespace Fintrack.App.Functions.NetWorth.Commands.AddNetWorthPart;

public class AddNetWorthPartCommand : RequestBase, IRequest
{
    public NetWorthPartModel Model { get; set; }
}