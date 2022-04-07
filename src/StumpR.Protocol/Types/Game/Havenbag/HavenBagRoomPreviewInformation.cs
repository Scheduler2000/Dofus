using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class HavenBagRoomPreviewInformation
{
    public const short Id = 8913;

    public HavenBagRoomPreviewInformation(byte roomId, sbyte themeId)
    {
        RoomId = roomId;
        ThemeId = themeId;
    }

    public HavenBagRoomPreviewInformation()
    {
    }

    public virtual short TypeId => Id;

    public byte RoomId { get; set; }

    public sbyte ThemeId { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteByte(RoomId);
        writer.WriteSByte(ThemeId);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        RoomId = reader.ReadByte();
        ThemeId = reader.ReadSByte();
    }
}