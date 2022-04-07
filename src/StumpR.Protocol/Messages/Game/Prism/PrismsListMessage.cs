using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PrismsListMessage : Message
{
    public const uint Id = 3236;

    public PrismsListMessage(IEnumerable<PrismSubareaEmptyInfo> prisms)
    {
        Prisms = prisms;
    }

    public PrismsListMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<PrismSubareaEmptyInfo> Prisms { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Prisms.Count());

        foreach (PrismSubareaEmptyInfo objectToSend in Prisms)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort prismsCount = reader.ReadUShort();
        var prisms_ = new PrismSubareaEmptyInfo[prismsCount];

        for (var prismsIndex = 0; prismsIndex < prismsCount; prismsIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<PrismSubareaEmptyInfo>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            prisms_[prismsIndex] = objectToAdd;
        }
        Prisms = prisms_;
    }
}