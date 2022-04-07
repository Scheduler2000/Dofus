using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ItemsPreset : Preset
{
    public new const short Id = 5400;

    public ItemsPreset(short objectId, IEnumerable<ItemForPreset> items, bool mountEquipped, EntityLook look)
    {
        ObjectId = objectId;
        Items = items;
        MountEquipped = mountEquipped;
        Look = look;
    }

    public ItemsPreset()
    {
    }

    public override short TypeId => Id;

    public IEnumerable<ItemForPreset> Items { get; set; }

    public bool MountEquipped { get; set; }

    public EntityLook Look { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort((short) Items.Count());
        foreach (ItemForPreset objectToSend in Items) objectToSend.Serialize(writer);
        writer.WriteBoolean(MountEquipped);
        Look.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ushort itemsCount = reader.ReadUShort();
        var items_ = new ItemForPreset[itemsCount];

        for (var itemsIndex = 0; itemsIndex < itemsCount; itemsIndex++)
        {
            var objectToAdd = new ItemForPreset();
            objectToAdd.Deserialize(reader);
            items_[itemsIndex] = objectToAdd;
        }
        Items = items_;
        MountEquipped = reader.ReadBoolean();
        Look = new EntityLook();
        Look.Deserialize(reader);
    }
}