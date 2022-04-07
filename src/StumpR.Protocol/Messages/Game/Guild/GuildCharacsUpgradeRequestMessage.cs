using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildCharacsUpgradeRequestMessage : Message
{
    public const uint Id = 3240;

    public GuildCharacsUpgradeRequestMessage(sbyte charaTypeTarget)
    {
        CharaTypeTarget = charaTypeTarget;
    }

    public GuildCharacsUpgradeRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte CharaTypeTarget { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(CharaTypeTarget);
    }

    public override void Deserialize(IDataReader reader)
    {
        CharaTypeTarget = reader.ReadSByte();
    }
}