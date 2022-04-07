using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class SpawnCharacterInformation : SpawnInformation
{
    public new const short Id = 457;

    public SpawnCharacterInformation(string name, ushort level)
    {
        Name = name;
        Level = level;
    }

    public SpawnCharacterInformation()
    {
    }

    public override short TypeId => Id;

    public string Name { get; set; }

    public ushort Level { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUTF(Name);
        writer.WriteVarUShort(Level);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Name = reader.ReadUTF();
        Level = reader.ReadVarUShort();
    }
}