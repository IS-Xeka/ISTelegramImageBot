namespace ISTelegramImageBot.Domain.Models;

public class User
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public long TelegramChatId { get; private set; }
    public string PasswordHash { get; private set; } = string.Empty;
    public DateTime CreatedAtUtc { get; private set; }

    private User(Guid id, string name)
    {
        Id = id;
        Name = name;
        CreatedAtUtc = DateTime.UtcNow;
    }

    public static User Create(string name)
    {
        return new User(Guid.NewGuid(), name);
    }
}
