using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AchievementAlmostFinishedDetailedListRequestMessage : Message
{
    public const uint Id = 3810;

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
}