using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class SpellVariantActivationMessage : Message
{
    public const uint Id = 8666;

    public SpellVariantActivationMessage(ushort spellId, bool result)
    {
        SpellId = spellId;
        Result = result;
    }

    public SpellVariantActivationMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort SpellId { get; set; }

    public bool Result { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(SpellId);
        writer.WriteBoolean(Result);
    }

    public override void Deserialize(IDataReader reader)
    {
        SpellId = reader.ReadVarUShort();
        Result = reader.ReadBoolean();
    }
}