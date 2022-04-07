using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class IgnoredListMessage : Message
{
    public const uint Id = 1938;

    public IgnoredListMessage(IEnumerable<IgnoredInformations> ignoredList)
    {
        IgnoredList = ignoredList;
    }

    public IgnoredListMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<IgnoredInformations> IgnoredList { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) IgnoredList.Count());

        foreach (IgnoredInformations objectToSend in IgnoredList)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort ignoredListCount = reader.ReadUShort();
        var ignoredList_ = new IgnoredInformations[ignoredListCount];

        for (var ignoredListIndex = 0; ignoredListIndex < ignoredListCount; ignoredListIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<IgnoredInformations>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            ignoredList_[ignoredListIndex] = objectToAdd;
        }
        IgnoredList = ignoredList_;
    }
}