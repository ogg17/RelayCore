using RelayCore.Domain;

namespace RelayCore.UnitTests;

public class DeviceTests
{
    private static readonly DateTimeOffset CreatedAt =
        new(2026, 10, 24, 16, 0, 0, TimeSpan.FromHours(4));

    [Fact]
    public void Constructor_WithValidArguments_CreatesActiveDevice()
    {
        var ownerId = Guid.NewGuid();

        var device = new Device(ownerId, "Test device", "credential-hash", CreatedAt);

        Assert.NotEqual(Guid.Empty, device.Id);
        Assert.Equal(ownerId, device.OwnerId);
        Assert.Equal("Test device", device.Name);
        Assert.Equal("credential-hash", device.CredentialHash);
        Assert.False(device.IsRevoked);
        Assert.Null(device.LastSeenAt);
        Assert.Equal(CreatedAt.ToUniversalTime(), device.CreatedAt);
        Assert.Equal(TimeSpan.Zero, device.CreatedAt.Offset);
    }

    [Fact]
    public void Constructor_WithEmptyOwner_ThrowsArgumentException()
    {
        var exception = Assert.Throws<ArgumentException>(() =>
            new Device(Guid.Empty, "Test device", "credential-hash", CreatedAt));

        Assert.Equal("owner", exception.ParamName);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" \t")]
    public void Constructor_WithBlankName_ThrowsArgumentException(string? name)
    {
        var exception = Assert.ThrowsAny<ArgumentException>(() =>
            new Device(Guid.NewGuid(), name!, "credential-hash", CreatedAt));

        Assert.Equal("name", exception.ParamName);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" \t")]
    public void Constructor_WithBlankCredentialHash_ThrowsArgumentException(string? credentialHash)
    {
        var exception = Assert.ThrowsAny<ArgumentException>(() =>
            new Device(Guid.NewGuid(), "Test device", credentialHash!, CreatedAt));

        Assert.Equal("credentialHash", exception.ParamName);
    }

    [Fact]
    public void Revoke_WhenCalled_DeviceIsRevoked()
    {
        var device = new Device(Guid.NewGuid(), "Test device", "credential-hash", CreatedAt);

        device.Revoke();

        Assert.True(device.IsRevoked);
    }

    [Fact]
    public void Revoke_WhenCalledTwice_DeviceRemainsRevoked()
    {
        // Arrange — подготовка
        var device = new Device(
            Guid.NewGuid(),
            "Test device",
            "test-credential-hash",
            DateTimeOffset.UtcNow);

        // Act — действие
        device.Revoke();
        device.Revoke();

        // Assert — проверка результата
        Assert.True(device.IsRevoked);
    }
}
