using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HouseTeleportRequestMessage : Message
{
    public const uint Id = 4012;

    public HouseTeleportRequestMessage(uint houseId, int houseInstanceId)
    {
        HouseId = houseId;
        HouseInstanceId = houseInstanceId;
    }

    public HouseTeleportRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public uint HouseId { get; set; }

    public int HouseInstanceId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(HouseId);
        writer.WriteInt(HouseInstanceId);
    }

    public override void Deserialize(IDataReader reader)
    {
        HouseId = reader.ReadVarUInt();
        HouseInstanceId = reader.ReadInt();
    }
}