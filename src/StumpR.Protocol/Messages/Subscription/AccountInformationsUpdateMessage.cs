using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AccountInformationsUpdateMessage : Message
{
    public const uint Id = 3664;

    public AccountInformationsUpdateMessage(double subscriptionEndDate)
    {
        SubscriptionEndDate = subscriptionEndDate;
    }

    public AccountInformationsUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public double SubscriptionEndDate { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(SubscriptionEndDate);
    }

    public override void Deserialize(IDataReader reader)
    {
        SubscriptionEndDate = reader.ReadDouble();
    }
}