using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class BidExchangerObjectInfo
{
    public const short Id = 461;

    public BidExchangerObjectInfo(uint objectUID,
        ushort objectGID,
        int objectType,
        IEnumerable<ObjectEffect> effects,
        IEnumerable<ulong> prices)
    {
        ObjectUID = objectUID;
        ObjectGID = objectGID;
        ObjectType = objectType;
        Effects = effects;
        Prices = prices;
    }

    public BidExchangerObjectInfo()
    {
    }

    public virtual short TypeId => Id;

    public uint ObjectUID { get; set; }

    public ushort ObjectGID { get; set; }

    public int ObjectType { get; set; }

    public IEnumerable<ObjectEffect> Effects { get; set; }

    public IEnumerable<ulong> Prices { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(ObjectUID);
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

    public virtual void Deserialize(IDataReader reader)
    {
        ObjectUID = reader.ReadVarUInt();
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