using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameActionFightCastRequestMessage : Message
{
    public const uint Id = 4946;

    public GameActionFightCastRequestMessage(ushort spellId, short cellId)
    {
        SpellId = spellId;
        CellId = cellId;
    }

    public GameActionFightCastRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort SpellId { get; set; }

    public short CellId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(SpellId);
        writer.WriteShort(CellId);
    }

    public override void Deserialize(IDataReader reader)
    {
        SpellId = reader.ReadVarUShort();
        CellId = reader.ReadShort();
    }
}