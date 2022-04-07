using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class CharacterCreationRequestMessage : Message
{
    public const uint Id = 5026;

    public CharacterCreationRequestMessage(string name, sbyte breed, bool sex, ushort cosmeticId)
    {
        Name = name;
        Breed = breed;
        Sex = sex;
        CosmeticId = cosmeticId;
    }

    public CharacterCreationRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public string Name { get; set; }

    public sbyte Breed { get; set; }

    public bool Sex { get; set; }

    public ushort CosmeticId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteUTF(Name);
        writer.WriteSByte(Breed);
        writer.WriteBoolean(Sex);
        writer.WriteVarUShort(CosmeticId);
    }

    public override void Deserialize(IDataReader reader)
    {
        Name = reader.ReadUTF();
        Breed = reader.ReadSByte();
        Sex = reader.ReadBoolean();
        CosmeticId = reader.ReadVarUShort();
    }
}