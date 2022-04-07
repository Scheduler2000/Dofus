using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class StartupActionAddObject
{
    public const short Id = 6157;

    public StartupActionAddObject(int uid,
        string title,
        string text,
        string descUrl,
        string pictureUrl,
        IEnumerable<ObjectItemInformationWithQuantity> items)
    {
        Uid = uid;
        Title = title;
        Text = text;
        DescUrl = descUrl;
        PictureUrl = pictureUrl;
        Items = items;
    }

    public StartupActionAddObject()
    {
    }

    public virtual short TypeId => Id;

    public int Uid { get; set; }

    public string Title { get; set; }

    public string Text { get; set; }

    public string DescUrl { get; set; }

    public string PictureUrl { get; set; }

    public IEnumerable<ObjectItemInformationWithQuantity> Items { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteInt(Uid);
        writer.WriteUTF(Title);
        writer.WriteUTF(Text);
        writer.WriteUTF(DescUrl);
        writer.WriteUTF(PictureUrl);
        writer.WriteShort((short) Items.Count());
        foreach (ObjectItemInformationWithQuantity objectToSend in Items) objectToSend.Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        Uid = reader.ReadInt();
        Title = reader.ReadUTF();
        Text = reader.ReadUTF();
        DescUrl = reader.ReadUTF();
        PictureUrl = reader.ReadUTF();
        ushort itemsCount = reader.ReadUShort();
        var items_ = new ObjectItemInformationWithQuantity[itemsCount];

        for (var itemsIndex = 0; itemsIndex < itemsCount; itemsIndex++)
        {
            var objectToAdd = new ObjectItemInformationWithQuantity();
            objectToAdd.Deserialize(reader);
            items_[itemsIndex] = objectToAdd;
        }
        Items = items_;
    }
}