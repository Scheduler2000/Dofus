using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class CharacterLevelUpMessage : Message
{
    public const uint Id = 6501;

    public CharacterLevelUpMessage(ushort newLevel)
    {
        NewLevel = newLevel;
    }

    public CharacterLevelUpMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort NewLevel { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(NewLevel);
    }

    public override void Deserialize(IDataReader reader)
    {
        NewLevel = reader.ReadVarUShort();
    }
}