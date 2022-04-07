using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class StartupActionFinishedMessage : Message
{
    public const uint Id = 6394;

    public StartupActionFinishedMessage(bool success, bool automaticAction, int actionId)
    {
        Success = success;
        AutomaticAction = automaticAction;
        ActionId = actionId;
    }

    public StartupActionFinishedMessage()
    {
    }

    public override uint MessageId => Id;

    public bool Success { get; set; }

    public bool AutomaticAction { get; set; }

    public int ActionId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, Success);
        flag = BooleanByteWrapper.SetFlag(flag, 1, AutomaticAction);
        writer.WriteByte(flag);
        writer.WriteInt(ActionId);
    }

    public override void Deserialize(IDataReader reader)
    {
        byte flag = reader.ReadByte();
        Success = BooleanByteWrapper.GetFlag(flag, 0);
        AutomaticAction = BooleanByteWrapper.GetFlag(flag, 1);
        ActionId = reader.ReadInt();
    }
}