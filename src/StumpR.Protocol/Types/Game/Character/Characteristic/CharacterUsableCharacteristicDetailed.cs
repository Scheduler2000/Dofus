using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class CharacterUsableCharacteristicDetailed : CharacterCharacteristicDetailed
{
    public new const short Id = 9575;

    public CharacterUsableCharacteristicDetailed(short characteristicId,
        short @base,
        short additional,
        short objectsAndMountBonus,
        short alignGiftBonus,
        short contextModif,
        ushort used)
    {
        CharacteristicId = characteristicId;
        this.@base = @base;
        Additional = additional;
        ObjectsAndMountBonus = objectsAndMountBonus;
        AlignGiftBonus = alignGiftBonus;
        ContextModif = contextModif;
        Used = used;
    }

    public CharacterUsableCharacteristicDetailed()
    {
    }

    public override short TypeId => Id;

    public ushort Used { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(Used);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Used = reader.ReadVarUShort();
    }
}