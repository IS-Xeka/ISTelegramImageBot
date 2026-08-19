using ISTelegramImageBot.Domain.Enums;

namespace ISTelegramImageBot.Domain.Models;

public class GenerationJob
{
    public Guid Id { get; private set; }
    public string? ExternalId { get; private set; }
    public Guid UserId { get; private set; }
    public Guid InputImageId { get; private set; }
    public Guid? ResultImageId { get; private set; }
    public string Prompt { get; private set; }
    public JobStatus Status { get; private set; }
    public string? ResultUrl { get; private set; }
    public int RetryCount { get; private set; }

    public DateTime CreatedAtUtc { get; private set; }
    public DateTime? CompletedAtUtc { get; private set; }

    public const int MaxRetries = 3;
    public bool CanBeRetried => Status == JobStatus.Failed && RetryCount < MaxRetries;

    public static GenerationJob Create(Guid userId, string prompt) => new()
    {
        Id = Guid.NewGuid(),
        UserId = userId,
        Prompt = prompt,
        CreatedAtUtc = DateTime.UtcNow,
        Status = JobStatus.Created
    };

    public void Start()
    {
        if (Status != JobStatus.Created && Status != JobStatus.Queued)
            throw new Exception($"Нельзя стартовать из {Status}");
        Status = JobStatus.Processing;
    }

    public void Complete(string resultUrl)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(resultUrl);
        Status = JobStatus.Success;
        CompletedAtUtc = DateTime.UtcNow;
        ResultUrl = resultUrl;
    }

    public void Fail()
    {
        Status = JobStatus.Failed;
        RetryCount++;
    }
}
