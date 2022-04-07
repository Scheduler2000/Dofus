using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildHouseRemoveMessage : Message
{
    public const uint Id = 1802;

    public GuildHouseRemoveMessage(uint houseId, int instanceId, bool secondHand)
    {
        HouseId = houseId;
        InstanceId = instanceId;
        SecondHand = secondHand;
    }

    public GuildHouseRemoveMessage()
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