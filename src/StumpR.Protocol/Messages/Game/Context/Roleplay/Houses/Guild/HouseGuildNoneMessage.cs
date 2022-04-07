using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HouseGuildNoneMessage : Message
{
    public const uint Id = 9562;

    public HouseGuildNoneMessage(uint houseId, int instanceId, bool secondHand)
    {
        HouseId = houseId;
        InstanceId = instanceId;
        SecondHand = secondHand;
    }

    public HouseGuildNoneMessage()
    {
    }

    public override uint MessageId => Id;

    public uint HouseId { get; set; }

    public int InstanceId { get; set; }

    public bool SecondHand { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(HouseId);
        writer.WriteInt(InstanceId);
        writer.WriteBoolean(SecondHand);
    }

    public override void Deserialize(IDataReader reader)
    {
        HouseId = reader.ReadVarUInt();
        InstanceId = reader.ReadInt();
        SecondHand = reader.ReadBoolean();
    }
}