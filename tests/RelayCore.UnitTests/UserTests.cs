using RelayCore.Domain;

namespace RelayCore.UnitTests;

public class UserTests
{
    private static readonly DateTimeOffset CreatedAt =
        new(2026, 10, 24, 16, 0, 0, TimeSpan.FromHours(4));

    [Fact]
    public void Constructor_WithValidArguments_CreatesUserWithDefaultRole()
    {
        var user = new User("user@example.com", "password-hash", CreatedAt);

        Assert.NotEqual(Guid.Empty, user.Id);
        Assert.Equal("user", user.Role);
        Assert.Equal("user@example.com", user.Email);
        Assert.Equal("password-hash", user.PasswordHash);
        Assert.Equal(CreatedAt.ToUniversalTime(), user.CreatedAt);
        Assert.Equal(TimeSpan.Zero, user.CreatedAt.Offset);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" \t")]
    public void Constructor_WithBlankEmail_ThrowsArgumentException(string? email)
    {
        var exception = Assert.ThrowsAny<ArgumentException>(() =>
            new User(email!, "password-hash", CreatedAt));

        Assert.Equal("email", exception.ParamName);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" \t")]
    public void Constructor_WithBlankPasswordHash_ThrowsArgumentException(string? passwordHash)
    {
        var exception = Assert.ThrowsAny<ArgumentException>(() =>
            new User("user@example.com", passwordHash!, CreatedAt));

        Assert.Equal("passwordHash", exception.ParamName);
    }
}
