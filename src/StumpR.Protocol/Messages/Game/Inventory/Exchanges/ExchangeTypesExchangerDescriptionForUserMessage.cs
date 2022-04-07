using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeTypesExchangerDescriptionForUserMessage : Message
{
    public const uint Id = 8522;

    public ExchangeTypesExchangerDescriptionForUserMessage(int objectType, IEnumerable<uint> typeDescription)
    {
        ObjectType = objectType;
        TypeDescription = typeDescription;
    }

    public ExchangeTypesExchangerDescriptionForUserMessage()
    {
    }

    public override uint MessageId => Id;

    public int ObjectType { get; set; }

    public IEnumerable<uint> TypeDescription { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteInt(ObjectType);
        writer.WriteShort((short) TypeDescription.Count());
        foreach (uint objectToSend in TypeDescription) writer.WriteVarUInt(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ObjectType = reader.ReadInt();
        ushort typeDescriptionCount = reader.ReadUShort();
        var typeDescription_ = new uint[typeDescriptionCount];

        for (var typeDescriptionIndex = 0; typeDescriptionIndex < typeDescriptionCount; typeDescriptionIndex++)
            typeDescription_[typeDescriptionIndex] = reader.ReadVarUInt();
        TypeDescription = typeDescription_;
    }
}