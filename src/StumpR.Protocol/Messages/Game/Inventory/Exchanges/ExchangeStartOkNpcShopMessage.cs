using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeStartOkNpcShopMessage : Message
{
    public const uint Id = 8584;

    public ExchangeStartOkNpcShopMessage(double npcSellerId, ushort tokenId, IEnumerable<ObjectItemToSellInNpcShop> objectsInfos)
    {
        NpcSellerId = npcSellerId;
        TokenId = tokenId;
        ObjectsInfos = objectsInfos;
    }

    public ExchangeStartOkNpcShopMessage()
    {
    }

    public override uint MessageId => Id;

    public double NpcSellerId { get; set; }

    public ushort TokenId { get; set; }

    public IEnumerable<ObjectItemToSellInNpcShop> ObjectsInfos { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(NpcSellerId);
        writer.WriteVarUShort(TokenId);
        writer.WriteShort((short) ObjectsInfos.Count());
        foreach (ObjectItemToSellInNpcShop objectToSend in ObjectsInfos) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        NpcSellerId = reader.ReadDouble();
        TokenId = reader.ReadVarUShort();
        ushort objectsInfosCount = reader.ReadUShort();
        var objectsInfos_ = new ObjectItemToSellInNpcShop[objectsInfosCount];

        for (var objectsInfosIndex = 0; objectsInfosIndex < objectsInfosCount; objectsInfosIndex++)
        {
            var objectToAdd = new ObjectItemToSellInNpcShop();
            objectToAdd.Deserialize(reader);
            objectsInfos_[objectsInfosIndex] = objectToAdd;
        }
        ObjectsInfos = objectsInfos_;
    }
}