using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GoldAddedMessage : Message
{
    public const uint Id = 1408;

    public GoldAddedMessage(GoldItem gold)
    {
        Gold = gold;
    }

    public GoldAddedMessage()
    {
    }

    public override uint MessageId => Id;

    public GoldItem Gold { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        Gold.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        Gold = new GoldItem();
        Gold.Deserialize(reader);
    }
}