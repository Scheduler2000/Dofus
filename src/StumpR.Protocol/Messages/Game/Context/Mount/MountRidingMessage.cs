using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class MountRidingMessage : Message
{
    public const uint Id = 6231;

    public MountRidingMessage(bool isRiding, bool isAutopilot)
    {
        IsRiding = isRiding;
        IsAutopilot = isAutopilot;
    }

    public MountRidingMessage()
    {
    }

    public override uint MessageId => Id;

    public bool IsRiding { get; set; }

    public bool IsAutopilot { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, IsRiding);
        flag = BooleanByteWrapper.SetFlag(flag, 1, IsAutopilot);
        writer.WriteByte(flag);
    }

    public override void Deserialize(IDataReader reader)
    {
        byte flag = reader.ReadByte();
        IsRiding = BooleanByteWrapper.GetFlag(flag, 0);
        IsAutopilot = BooleanByteWrapper.GetFlag(flag, 1);
    }
}