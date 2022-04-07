using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class JobBookSubscriptionMessage : Message
{
    public const uint Id = 8266;

    public JobBookSubscriptionMessage(IEnumerable<JobBookSubscription> subscriptions)
    {
        Subscriptions = subscriptions;
    }

    public JobBookSubscriptionMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<JobBookSubscription> Subscriptions { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Subscriptions.Count());
        foreach (JobBookSubscription objectToSend in Subscriptions) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort subscriptionsCount = reader.ReadUShort();
        var subscriptions_ = new JobBookSubscription[subscriptionsCount];

        for (var subscriptionsIndex = 0; subscriptionsIndex < subscriptionsCount; subscriptionsIndex++)
        {
            var objectToAdd = new JobBookSubscription();
            objectToAdd.Deserialize(reader);
            subscriptions_[subscriptionsIndex] = objectToAdd;
        }
        Subscriptions = subscriptions_;
    }
}