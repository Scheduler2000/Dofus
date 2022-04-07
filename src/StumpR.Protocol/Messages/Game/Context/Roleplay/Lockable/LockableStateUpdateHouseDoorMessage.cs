using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class LockableStateUpdateHouseDoorMessage : LockableStateUpdateAbstractMessage
{
    public new const uint Id = 7958;

    public LockableStateUpdateHouseDoorMessage(bool locked, uint houseId, int instanceId, bool secondHand)
    {
        Locked = locked;
        HouseId = houseId;
        InstanceId = instanceId;
        SecondHand = secondHand;
    }

    public LockableStateUpdateHouseDoorMessage()
    {
    }

    public override uint MessageId => Id;

    public uint HouseId { get; set; }

    public int InstanceId { get; set; }

    public bool SecondHand { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUInt(HouseId);
        writer.WriteInt(InstanceId);
        writer.WriteBoolean(SecondHand);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        HouseId = reader.ReadVarUInt();
        InstanceId = reader.ReadInt();
        SecondHand = reader.ReadBoolean();
    }
}