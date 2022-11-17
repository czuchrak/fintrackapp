using Fintrack.App.Functions.Property.Models;
using MediatR;

namespace Fintrack.App.Functions.Property.Commands.AddProperty;

public class AddPropertyCommand : RequestBase, IRequest
{
    public PropertyModel Model { get; set; }
}