using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AreaFightModificatorUpdateMessage : Message
{
    public const uint Id = 4779;

    public AreaFightModificatorUpdateMessage(int spellPairId)
    {
        SpellPairId = spellPairId;
    }

    public AreaFightModificatorUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public int SpellPairId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteInt(SpellPairId);
    }

    public override void Deserialize(IDataReader reader)
    {
        SpellPairId = reader.ReadInt();
    }
}