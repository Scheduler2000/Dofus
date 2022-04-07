using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class SelectedServerRefusedMessage : Message
{
    public const uint Id = 8116;

    public SelectedServerRefusedMessage(ushort serverId, sbyte error, sbyte serverStatus)
    {
        ServerId = serverId;
        Error = error;
        ServerStatus = serverStatus;
    }

    public SelectedServerRefusedMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort ServerId { get; set; }

    public sbyte Error { get; set; }

    public sbyte ServerStatus { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(ServerId);
        writer.WriteSByte(Error);
        writer.WriteSByte(ServerStatus);
    }

    public override void Deserialize(IDataReader reader)
    {
        ServerId = reader.ReadVarUShort();
        Error = reader.ReadSByte();
        ServerStatus = reader.ReadSByte();
    }
}