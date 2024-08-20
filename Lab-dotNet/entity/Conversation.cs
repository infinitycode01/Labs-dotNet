namespace Lab_dotNet.entity;

public class Conversation
{
    public long ConversationId { get; init; }
    public long UserId { get; init; }
    public long TariffId { get; init; }
    public int Duration { get; init; }
    public DateTime Date { get; init; }

    public Conversation(long conversationId, long userId, long tariffId, int duration, DateTime date)
    {
        ConversationId = conversationId;
        UserId = userId;
        TariffId = tariffId;
        Duration = duration;
        Date = date;
    }

    public Conversation()
    {
    }

    public override string ToString()
    {
        return $"ConversationId: {ConversationId}, UserId: {UserId}, TariffId: {TariffId}, Durability: {Duration}, Date: {Date}";
    }
}