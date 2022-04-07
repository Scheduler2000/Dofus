using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeBidHouseInListAddedMessage : Message
{
    public const uint Id = 213;

    public ExchangeBidHouseInListAddedMessage(int itemUID,
        ushort objectGID,
        int objectType,
        IEnumerable<ObjectEffect> effects,
        IEnumerable<ulong> prices)
    {
        ItemUID = itemUID;
        ObjectGID = objectGID;
        ObjectType = objectType;
        Effects = effects;
        Prices = prices;
    }

    public ExchangeBidHouseInListAddedMessage()
    {
    }

    public override uint MessageId => Id;

    public int ItemUID { get; set; }

    public ushort ObjectGID { get; set; }

    public int ObjectType { get; set; }

    public IEnumerable<ObjectEffect> Effects { get; set; }

    public IEnumerable<ulong> Prices { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteInt(ItemUID);
        writer.WriteVarUShort(ObjectGID);
        writer.WriteInt(ObjectType);
        writer.WriteShort((short) Effects.Count());

        foreach (ObjectEffect objectToSend in Effects)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
        writer.WriteShort((short) Prices.Count());
        foreach (ulong objectToSend in Prices) writer.WriteVarULong(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ItemUID = reader.ReadInt();
        ObjectGID = reader.ReadVarUShort();
        ObjectType = reader.ReadInt();
        ushort effectsCount = reader.ReadUShort();
        var effects_ = new ObjectEffect[effectsCount];

        for (var effectsIndex = 0; effectsIndex < effectsCount; effectsIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<ObjectEffect>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            effects_[effectsIndex] = objectToAdd;
        }
        Effects = effects_;
        ushort pricesCount = reader.ReadUShort();
        var prices_ = new ulong[pricesCount];
        for (var pricesIndex = 0; pricesIndex < pricesCount; pricesIndex++) prices_[pricesIndex] = reader.ReadVarULong();
        Prices = prices_;
    }
}