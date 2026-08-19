namespace ISTelegramImageBot.Domain.Models;

public class Image
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Url { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedAtUtc { get;}
    public int Width { get; private set; }
    public int Height { get; private set; }

    private Image(Guid id, string name, string url, string description, int width, int height)
    {
        Id = id;
        Name = name;
        Url = url;
        Description = description;
        CreatedAtUtc = DateTime.UtcNow;
        Width = width;
        Height = height;
    }

    public static Image Create(Guid id, string name, string url, string description, int width, int height)
    {
        return new Image(id, name, url, description, width, height);
    }
}
