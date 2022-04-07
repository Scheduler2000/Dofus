using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HouseGuildShareRequestMessage : Message
{
    public const uint Id = 5595;

    public HouseGuildShareRequestMessage(uint houseId, int instanceId, bool enable, uint rights)
    {
        HouseId = houseId;
        InstanceId = instanceId;
        Enable = enable;
        Rights = rights;
    }

    public HouseGuildShareRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public uint HouseId { get; set; }

    public int InstanceId { get; set; }

    public bool Enable { get; set; }

    public uint Rights { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(HouseId);
        writer.WriteInt(InstanceId);
        writer.WriteBoolean(Enable);
        writer.WriteVarUInt(Rights);
    }

    public override void Deserialize(IDataReader reader)
    {
        HouseId = reader.ReadVarUInt();
        InstanceId = reader.ReadInt();
        Enable = reader.ReadBoolean();
        Rights = reader.ReadVarUInt();
    }
}