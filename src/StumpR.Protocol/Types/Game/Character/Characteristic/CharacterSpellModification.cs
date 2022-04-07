using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class CharacterSpellModification
{
    public const short Id = 4425;

    public CharacterSpellModification(sbyte modificationType, ushort spellId, CharacterCharacteristicDetailed value)
    {
        ModificationType = modificationType;
        SpellId = spellId;
        Value = value;
    }

    public CharacterSpellModification()
    {
    }

    public virtual short TypeId => Id;

    public sbyte ModificationType { get; set; }

    public ushort SpellId { get; set; }

    public CharacterCharacteristicDetailed Value { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(ModificationType);
        writer.WriteVarUShort(SpellId);
        Value.Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        ModificationType = reader.ReadSByte();
        SpellId = reader.ReadVarUShort();
        Value = new CharacterCharacteristicDetailed();
        Value.Deserialize(reader);
    }
}