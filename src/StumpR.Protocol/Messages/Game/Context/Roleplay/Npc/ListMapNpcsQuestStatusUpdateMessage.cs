using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ListMapNpcsQuestStatusUpdateMessage : Message
{
    public const uint Id = 5996;

    public ListMapNpcsQuestStatusUpdateMessage(IEnumerable<MapNpcQuestInfo> mapInfo)
    {
        MapInfo = mapInfo;
    }

    public ListMapNpcsQuestStatusUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<MapNpcQuestInfo> MapInfo { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) MapInfo.Count());
        foreach (MapNpcQuestInfo objectToSend in MapInfo) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort mapInfoCount = reader.ReadUShort();
        var mapInfo_ = new MapNpcQuestInfo[mapInfoCount];

        for (var mapInfoIndex = 0; mapInfoIndex < mapInfoCount; mapInfoIndex++)
        {
            var objectToAdd = new MapNpcQuestInfo();
            objectToAdd.Deserialize(reader);
            mapInfo_[mapInfoIndex] = objectToAdd;
        }
        MapInfo = mapInfo_;
    }
}