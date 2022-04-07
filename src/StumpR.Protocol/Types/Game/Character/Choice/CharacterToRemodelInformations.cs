using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class CharacterToRemodelInformations : CharacterRemodelingInformation
{
    public new const short Id = 2646;

    public CharacterToRemodelInformations(ulong objectId,
        string name,
        sbyte breed,
        bool sex,
        ushort cosmeticId,
        IEnumerable<int> colors,
        sbyte possibleChangeMask,
        sbyte mandatoryChangeMask)
    {
        ObjectId = objectId;
        Name = name;
        Breed = breed;
        Sex = sex;
        CosmeticId = cosmeticId;
        Colors = colors;
        PossibleChangeMask = possibleChangeMask;
        MandatoryChangeMask = mandatoryChangeMask;
    }

    public CharacterToRemodelInformations()
    {
    }

    public override short TypeId => Id;

    public sbyte PossibleChangeMask { get; set; }

    public sbyte MandatoryChangeMask { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteSByte(PossibleChangeMask);
        writer.WriteSByte(MandatoryChangeMask);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        PossibleChangeMask = reader.ReadSByte();
        MandatoryChangeMask = reader.ReadSByte();
    }
}