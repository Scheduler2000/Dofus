using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class MountFeedRequestMessage : Message
{
    public const uint Id = 8131;

    public MountFeedRequestMessage(uint mountUid, sbyte mountLocation, uint mountFoodUid, uint quantity)
    {
        MountUid = mountUid;
        MountLocation = mountLocation;
        MountFoodUid = mountFoodUid;
        Quantity = quantity;
    }

    public MountFeedRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public uint MountUid { get; set; }

    public sbyte MountLocation { get; set; }

    public uint MountFoodUid { get; set; }

    public uint Quantity { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(MountUid);
        writer.WriteSByte(MountLocation);
        writer.WriteVarUInt(MountFoodUid);
        writer.WriteVarUInt(Quantity);
    }

    public override void Deserialize(IDataReader reader)
    {
        MountUid = reader.ReadVarUInt();
        MountLocation = reader.ReadSByte();
        MountFoodUid = reader.ReadVarUInt();
        Quantity = reader.ReadVarUInt();
    }
}