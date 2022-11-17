using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Fintrack.App.Functions.NetWorth.Commands.RemoveNetWorthPart;
using Fintrack.Database.Entities;
using FluentValidation.TestHelper;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Fintrack.Tests.Handlers.NetWorth;

[TestFixture]
public class RemoveNetWorthPartCommandTests : TestBase
{
    [OneTimeSetUp]
    public async Task SetUp()
    {
        await using var context = CreateContext();
        context.NetWorthParts.Add(new NetWorthPart
        {
            Id = new Guid("B25928DF-AC38-43A5-839E-9DF4F4DF62CE"),
            Name = "Test23",
            Type = "Asset",
            Currency = "PLN",
            IsVisible = true,
            Order = 1,
            UserId = UserId
        });
        context.NetWorthParts.Add(new NetWorthPart
        {
            Id = new Guid("92EA3A0F-EBB8-43CE-AF8F-F5A8807484B4"),
            Name = "Test23",
            Type = "Asset",
            Currency = "PLN",
            IsVisible = true,
            Order = 2,
            UserId = UserId
        });

        context.NetWorthEntries.Add(new NetWorthEntry
        {
            UserId = UserId,
            ExchangeRateDate = DateTime.Now,
            Date = DateTime.Now,
            EntryParts = new List<NetWorthEntryPart>
            {
                new()
                {
                    NetWorthPartId = Guid.Parse("92EA3A0F-EBB8-43CE-AF8F-F5A8807484B4"),
                    Value = 123
                }
            }
        });

        context.NetWorthGoals.Add(new NetWorthGoal
        {
            UserId = UserId,
            Name = "Name",
            Value = 132,
            ReturnRate = 10,
            Deadline = DateTime.Now,
            GoalParts = new List<NetWorthGoalPart>
            {
                new()
                {
                    NetWorthPartId = Guid.Parse("B25928DF-AC38-43A5-839E-9DF4F4DF62CE")
                }
            }
        });

        await context.SaveChangesAsync();
    }

    [Test]
    public async Task RemoveNetWorthPartCommandHandler_RemoveNetWorthPart()
    {
        await using var context = CreateContext();
        var handler = new RemoveNetWorthPartCommandHandler(context);

        await handler.Handle(new RemoveNetWorthPartCommand
            {
                PartId = new Guid("B25928DF-AC38-43A5-839E-9DF4F4DF62CE"),
                UserId = UserId
            },
            new CancellationToken());

        var parts = await context.NetWorthParts.ToListAsync();
        var goals = await context.NetWorthGoals.ToListAsync();

        Assert.AreEqual(1, parts.Count);
        Assert.AreEqual(0, goals.Count);
        Assert.AreEqual(1, parts[0].Order);
    }

    [Test]
    public async Task RemoveNetWorthPartCommandHandler_RemoveNetWorthPartWhenLast()
    {
        await using var context = CreateContext();
        context.RemoveRange(
            await context.NetWorthParts
                .Where(x => x.Id != Guid.Parse("92EA3A0F-EBB8-43CE-AF8F-F5A8807484B4"))
                .ToListAsync());
        await context.SaveChangesAsync();

        var handler = new RemoveNetWorthPartCommandHandler(context);

        await handler.Handle(new RemoveNetWorthPartCommand
            {
                PartId = new Guid("92EA3A0F-EBB8-43CE-AF8F-F5A8807484B4"),
                UserId = UserId
            },
            new CancellationToken());

        var parts = await context.NetWorthParts.ToListAsync();
        var entries = await context.NetWorthEntries.ToListAsync();

        Assert.AreEqual(0, parts.Count);
        Assert.AreEqual(0, entries.Count);
    }

    [Test]
    public async Task RemoveNetWorthPartCommandHandler_ThrowsException_WhenNetWorthPartDoesNotExist()
    {
        await using var context = CreateContext();
        var handler = new RemoveNetWorthPartCommandHandler(context);

        Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await handler.Handle(new RemoveNetWorthPartCommand
            {
                PartId = new Guid("92EA3A0F-EBB8-43CE-AF8F-F5A8807484B0"),
                UserId = UserId
            }, new CancellationToken()));
    }

    [Test]
    public async Task RemoveNetWorthPartCommandValidator_ValidatesFields()
    {
        var validator = new RemoveNetWorthPartCommandValidator();
        var result = await validator.TestValidateAsync(new RemoveNetWorthPartCommand
        {
            PartId = Guid.NewGuid(),
            UserId = UserId
        });
        result.ShouldNotHaveValidationErrorFor(x => x.UserId);
        result.ShouldNotHaveValidationErrorFor(x => x.PartId);
    }

    [Test]
    public async Task RemoveNetWorthPartCommandValidator_ThrowsException_WhenFieldsAreIncorrect()
    {
        var validator = new RemoveNetWorthPartCommandValidator();
        var result = await validator.TestValidateAsync(new RemoveNetWorthPartCommand
            { PartId = Guid.Empty, UserId = null });
        result.ShouldHaveValidationErrorFor(x => x.UserId);
        result.ShouldHaveValidationErrorFor(x => x.PartId);
    }
}