using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_dotNet.entity;

[Table("conversations")]
public class Conversation
{
    [Column("conversation_id")]
    public long ConversationId { get; init; }
    
    [Column("user_id")]
    public long UserId { get; init; }
    
    [Column("tariff_id")]
    public long TariffId { get; init; }
    
    [Column("duration")]
    public int Duration { get; init; }
    
    [Column("date")]
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