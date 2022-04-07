using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class RemodelingInformation
{
    public const short Id = 8002;

    public RemodelingInformation(string name, sbyte breed, bool sex, ushort cosmeticId, IEnumerable<int> colors)
    {
        Name = name;
        Breed = breed;
        Sex = sex;
        CosmeticId = cosmeticId;
        Colors = colors;
    }

    public RemodelingInformation()
    {
    }

    public virtual short TypeId => Id;

    public string Name { get; set; }

    public sbyte Breed { get; set; }

    public bool Sex { get; set; }

    public ushort CosmeticId { get; set; }

    public IEnumerable<int> Colors { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteUTF(Name);
        writer.WriteSByte(Breed);
        writer.WriteBoolean(Sex);
        writer.WriteVarUShort(CosmeticId);
        writer.WriteShort((short) Colors.Count());
        foreach (int objectToSend in Colors) writer.WriteInt(objectToSend);
    }

    public virtual void Deserialize(IDataReader reader)
    {
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