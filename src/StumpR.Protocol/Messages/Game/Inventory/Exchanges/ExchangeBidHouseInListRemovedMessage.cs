using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeBidHouseInListRemovedMessage : Message
{
    public const uint Id = 3610;

    public ExchangeBidHouseInListRemovedMessage(int itemUID, ushort objectGID, int objectType)
    {
        ItemUID = itemUID;
        ObjectGID = objectGID;
        ObjectType = objectType;
    }

    public ExchangeBidHouseInListRemovedMessage()
    {
    }

    public override uint MessageId => Id;

    public int ItemUID { get; set; }

    public ushort ObjectGID { get; set; }

    public int ObjectType { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteInt(ItemUID);
        writer.WriteVarUShort(ObjectGID);
        writer.WriteInt(ObjectType);
    }

    public override void Deserialize(IDataReader reader)
    {
        ItemUID = reader.ReadInt();
        ObjectGID = reader.ReadVarUShort();
        ObjectType = reader.ReadInt();
    }
}