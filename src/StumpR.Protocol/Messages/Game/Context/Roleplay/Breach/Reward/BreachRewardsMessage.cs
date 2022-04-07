using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class BreachRewardsMessage : Message
{
    public const uint Id = 3565;

    public BreachRewardsMessage(IEnumerable<BreachReward> rewards)
    {
        Rewards = rewards;
    }

    public BreachRewardsMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<BreachReward> Rewards { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Rewards.Count());
        foreach (BreachReward objectToSend in Rewards) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort rewardsCount = reader.ReadUShort();
        var rewards_ = new BreachReward[rewardsCount];

        for (var rewardsIndex = 0; rewardsIndex < rewardsCount; rewardsIndex++)
        {
            var objectToAdd = new BreachReward();
            objectToAdd.Deserialize(reader);
            rewards_[rewardsIndex] = objectToAdd;
        }
        Rewards = rewards_;
    }
}