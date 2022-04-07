using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AcquaintanceServerListMessage : Message
{
    public const uint Id = 8752;

    public AcquaintanceServerListMessage(IEnumerable<ushort> servers)
    {
        Servers = servers;
    }

    public AcquaintanceServerListMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ushort> Servers { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Servers.Count());
        foreach (ushort objectToSend in Servers) writer.WriteVarUShort(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort serversCount = reader.ReadUShort();
        var servers_ = new ushort[serversCount];
        for (var serversIndex = 0; serversIndex < serversCount; serversIndex++) servers_[serversIndex] = reader.ReadVarUShort();
        Servers = servers_;
    }
}