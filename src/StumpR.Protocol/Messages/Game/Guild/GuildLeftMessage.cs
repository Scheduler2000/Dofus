using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildLeftMessage : Message
{
    public const uint Id = 2770;

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
}