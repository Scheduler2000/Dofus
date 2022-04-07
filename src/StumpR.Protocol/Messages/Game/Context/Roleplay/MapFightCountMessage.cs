using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class MapFightCountMessage : Message
{
    public const uint Id = 9018;

    public MapFightCountMessage(ushort fightCount)
    {
        FightCount = fightCount;
    }

    public MapFightCountMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort FightCount { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(FightCount);
    }

    public override void Deserialize(IDataReader reader)
    {
        FightCount = reader.ReadVarUShort();
    }
}