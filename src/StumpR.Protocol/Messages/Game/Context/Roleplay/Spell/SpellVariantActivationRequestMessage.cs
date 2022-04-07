using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class SpellVariantActivationRequestMessage : Message
{
    public const uint Id = 4887;

    public SpellVariantActivationRequestMessage(ushort spellId)
    {
        SpellId = spellId;
    }

    public SpellVariantActivationRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort SpellId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(SpellId);
    }

    public override void Deserialize(IDataReader reader)
    {
        SpellId = reader.ReadVarUShort();
    }
}