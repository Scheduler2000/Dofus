using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ShortcutObjectItem : ShortcutObject
{
    public new const short Id = 6510;

    public ShortcutObjectItem(sbyte slot, int itemUID, int itemGID)
    {
        Slot = slot;
        ItemUID = itemUID;
        ItemGID = itemGID;
    }

    public ShortcutObjectItem()
    {
    }

    public override short TypeId => Id;

    public int ItemUID { get; set; }

    public int ItemGID { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt(ItemUID);
        writer.WriteInt(ItemGID);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ItemUID = reader.ReadInt();
        ItemGID = reader.ReadInt();
    }
}