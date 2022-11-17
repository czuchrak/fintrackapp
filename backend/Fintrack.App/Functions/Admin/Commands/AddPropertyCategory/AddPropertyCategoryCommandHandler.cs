using Fintrack.Database;
using Fintrack.Database.Entities;
using MediatR;

namespace Fintrack.App.Functions.Admin.Commands.AddPropertyCategory;

public class AddPropertyCategoryCommandHandler : AdminBaseHandler, IRequestHandler<AddPropertyCategoryCommand, Unit>
{
    public AddPropertyCategoryCommandHandler(DatabaseContext context) : base(context)
    {
    }

    public async Task<Unit> Handle(AddPropertyCategoryCommand request, CancellationToken cancellationToken)
    {
        await CheckIsAdmin(request.UserId);
        var model = request.Model;

        Context.PropertyCategories.Add(new PropertyCategory
        {
            Name = model.Name,
            Type = model.Type,
            IsCost = model.IsCost
        });

        await Context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}