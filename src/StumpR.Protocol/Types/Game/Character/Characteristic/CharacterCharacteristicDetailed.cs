using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class CharacterCharacteristicDetailed : CharacterCharacteristic
{
    public new const short Id = 9089;

    public CharacterCharacteristicDetailed(short characteristicId,
        short @base,
        short additional,
        short objectsAndMountBonus,
        short alignGiftBonus,
        short contextModif)
    {
        CharacteristicId = characteristicId;
        this.@base = @base;
        Additional = additional;
        ObjectsAndMountBonus = objectsAndMountBonus;
        AlignGiftBonus = alignGiftBonus;
        ContextModif = contextModif;
    }

    public CharacterCharacteristicDetailed()
    {
    }

    public override short TypeId => Id;

    public short @base { get; set; }

    public short Additional { get; set; }

    public short ObjectsAndMountBonus { get; set; }

    public short AlignGiftBonus { get; set; }

    public short ContextModif { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarShort(@base);
        writer.WriteVarShort(Additional);
        writer.WriteVarShort(ObjectsAndMountBonus);
        writer.WriteVarShort(AlignGiftBonus);
        writer.WriteVarShort(ContextModif);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        @base = reader.ReadVarShort();
        Additional = reader.ReadVarShort();
        ObjectsAndMountBonus = reader.ReadVarShort();
        AlignGiftBonus = reader.ReadVarShort();
        ContextModif = reader.ReadVarShort();
    }
}