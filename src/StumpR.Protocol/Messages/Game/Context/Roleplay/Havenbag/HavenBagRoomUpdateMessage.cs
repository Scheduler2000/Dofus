using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HavenBagRoomUpdateMessage : Message
{
    public const uint Id = 1606;

    public HavenBagRoomUpdateMessage(sbyte action, IEnumerable<HavenBagRoomPreviewInformation> roomsPreview)
    {
        Action = action;
        RoomsPreview = roomsPreview;
    }

    public HavenBagRoomUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte Action { get; set; }

    public IEnumerable<HavenBagRoomPreviewInformation> RoomsPreview { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(Action);
        writer.WriteShort((short) RoomsPreview.Count());
        foreach (HavenBagRoomPreviewInformation objectToSend in RoomsPreview) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        Action = reader.ReadSByte();
        ushort roomsPreviewCount = reader.ReadUShort();
        var roomsPreview_ = new HavenBagRoomPreviewInformation[roomsPreviewCount];

        for (var roomsPreviewIndex = 0; roomsPreviewIndex < roomsPreviewCount; roomsPreviewIndex++)
        {
            var objectToAdd = new HavenBagRoomPreviewInformation();
            objectToAdd.Deserialize(reader);
            roomsPreview_[roomsPreviewIndex] = objectToAdd;
        }
        RoomsPreview = roomsPreview_;
    }
}