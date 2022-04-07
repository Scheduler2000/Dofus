using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class UpdateMountCharacteristicsMessage : Message
{
    public const uint Id = 9937;

    public UpdateMountCharacteristicsMessage(int rideId, IEnumerable<UpdateMountCharacteristic> boostToUpdateList)
    {
        RideId = rideId;
        BoostToUpdateList = boostToUpdateList;
    }

    public UpdateMountCharacteristicsMessage()
    {
    }

    public override uint MessageId => Id;

    public int RideId { get; set; }

    public IEnumerable<UpdateMountCharacteristic> BoostToUpdateList { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarInt(RideId);
        writer.WriteShort((short) BoostToUpdateList.Count());

        foreach (UpdateMountCharacteristic objectToSend in BoostToUpdateList)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        RideId = reader.ReadVarInt();
        ushort boostToUpdateListCount = reader.ReadUShort();
        var boostToUpdateList_ = new UpdateMountCharacteristic[boostToUpdateListCount];

        for (var boostToUpdateListIndex = 0; boostToUpdateListIndex < boostToUpdateListCount; boostToUpdateListIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<UpdateMountCharacteristic>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            boostToUpdateList_[boostToUpdateListIndex] = objectToAdd;
        }
        BoostToUpdateList = boostToUpdateList_;
    }
}