using AutoFixture;
using AutoFixture.AutoNSubstitute;

namespace LitePrimitives.TestHelpers.XUnit;

public static class FixtureFactory
{
    public static IFixture CreateFixture()
    {
        var fixture = new Fixture();

        fixture.Customize(new AutoNSubstituteCustomization { ConfigureMembers = true, });

        return fixture;
    }
}