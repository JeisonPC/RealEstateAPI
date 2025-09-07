using NUnit.Framework;
using RealEstate.Domain.Entities;

namespace RealEstate.Tests;

[TestFixture]
public class OwnerTests
{
    [Test]
    public void CreateOwner_WithValidData_Works()
    {
        var o = new Owner("Alice", "Main St 1");
        Assert.That(o.Name, Is.EqualTo("Alice"));
        Assert.That(o.Address, Is.EqualTo("Main St 1"));
    }

    [Test]
    public void CreateOwner_EmptyName_Throws()
    {
        Assert.Throws<ArgumentException>(() => new Owner("", "X"));
    }
}
