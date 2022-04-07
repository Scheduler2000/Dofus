using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class PlayerSearchCharacterNameInformation : AbstractPlayerSearchInformation
{
    public new const short Id = 6431;

    public PlayerSearchCharacterNameInformation(string name)
    {
        Name = name;
    }

    public PlayerSearchCharacterNameInformation()
    {
    }

    public override short TypeId => Id;

    public string Name { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUTF(Name);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Name = reader.ReadUTF();
    }
}