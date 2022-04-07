using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ForgettableSpellClientActionMessage : Message
{
    public const uint Id = 6523;

    public ForgettableSpellClientActionMessage(int spellId, sbyte action)
    {
        SpellId = spellId;
        Action = action;
    }

    public ForgettableSpellClientActionMessage()
    {
    }

    public override uint MessageId => Id;

    public int SpellId { get; set; }

    public sbyte Action { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteInt(SpellId);
        writer.WriteSByte(Action);
    }

    public override void Deserialize(IDataReader reader)
    {
        SpellId = reader.ReadInt();
        Action = reader.ReadSByte();
    }
}