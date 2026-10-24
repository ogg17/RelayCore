namespace RelayCore.Domain;

public class User
{
    public Guid Id { get; private set; }
    public string Role { get; private set; }

    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }

    public User(string email, string passwordHash, DateTimeOffset createdAt)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(email);
        ArgumentException.ThrowIfNullOrWhiteSpace(passwordHash);

        Email = email;
        PasswordHash = passwordHash;
        CreatedAt = createdAt.ToUniversalTime();

        Id = Guid.NewGuid();
        Role = "user";
    }
}


