using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class CharacterRemodelingInformation : AbstractCharacterInformation
{
    public new const short Id = 5402;

    public CharacterRemodelingInformation(ulong objectId, string name, sbyte breed, bool sex, ushort cosmeticId, IEnumerable<int> colors)
    {
        ObjectId = objectId;
        Name = name;
        Breed = breed;
        Sex = sex;
        CosmeticId = cosmeticId;
        Colors = colors;
    }

    public CharacterRemodelingInformation()
    {
    }

    public override short TypeId => Id;

    public string Name { get; set; }

    public sbyte Breed { get; set; }

    public bool Sex { get; set; }

    public ushort CosmeticId { get; set; }

    public IEnumerable<int> Colors { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUTF(Name);
        writer.WriteSByte(Breed);
        writer.WriteBoolean(Sex);
        writer.WriteVarUShort(CosmeticId);
        writer.WriteShort((short) Colors.Count());
        foreach (int objectToSend in Colors) writer.WriteInt(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Name = reader.ReadUTF();
        Breed = reader.ReadSByte();
        Sex = reader.ReadBoolean();
        CosmeticId = reader.ReadVarUShort();
        ushort colorsCount = reader.ReadUShort();
        var colors_ = new int[colorsCount];
        for (var colorsIndex = 0; colorsIndex < colorsCount; colorsIndex++) colors_[colorsIndex] = reader.ReadInt();
        Colors = colors_;
    }
}