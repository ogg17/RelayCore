namespace RelayCore.Domain;

public class Device
{
    public Guid Id { get; private set; }
    public Guid OwnerId { get; private set; }
    public string Name { get; private set; }
    public string CredentialHash { get; private set; }
    public bool IsRevoked { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset? LastSeenAt { get; private set; }

    public Device(Guid owner, string name, string credentialHash, DateTimeOffset createdAt)
    {
        if (owner == Guid.Empty)
            throw new ArgumentException("Owner must not be empty.", nameof(owner));

        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(credentialHash);

        Id = Guid.NewGuid();
        OwnerId = owner;
        Name = name;
        CredentialHash = credentialHash;
        IsRevoked = false;
        CreatedAt = createdAt.ToUniversalTime();
    }

    public void Revoke() => IsRevoked = true;
}
