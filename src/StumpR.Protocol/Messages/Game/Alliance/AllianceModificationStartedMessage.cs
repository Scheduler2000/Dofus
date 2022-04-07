using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AllianceModificationStartedMessage : Message
{
    public const uint Id = 6240;

    public AllianceModificationStartedMessage(bool canChangeName, bool canChangeTag, bool canChangeEmblem)
    {
        CanChangeName = canChangeName;
        CanChangeTag = canChangeTag;
        CanChangeEmblem = canChangeEmblem;
    }

    public AllianceModificationStartedMessage()
    {
    }

    public override uint MessageId => Id;

    public bool CanChangeName { get; set; }

    public bool CanChangeTag { get; set; }

    public bool CanChangeEmblem { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, CanChangeName);
        flag = BooleanByteWrapper.SetFlag(flag, 1, CanChangeTag);
        flag = BooleanByteWrapper.SetFlag(flag, 2, CanChangeEmblem);
        writer.WriteByte(flag);
    }

    public override void Deserialize(IDataReader reader)
    {
        byte flag = reader.ReadByte();
        CanChangeName = BooleanByteWrapper.GetFlag(flag, 0);
        CanChangeTag = BooleanByteWrapper.GetFlag(flag, 1);
        CanChangeEmblem = BooleanByteWrapper.GetFlag(flag, 2);
    }
}