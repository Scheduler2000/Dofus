using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeMountFreeFromPaddockMessage : Message
{
    public const uint Id = 4810;

    public ExchangeMountFreeFromPaddockMessage(string name, short worldX, short worldY, string liberator)
    {
        Name = name;
        WorldX = worldX;
        WorldY = worldY;
        Liberator = liberator;
    }

    public ExchangeMountFreeFromPaddockMessage()
    {
    }

    public override uint MessageId => Id;

    public string Name { get; set; }

    public short WorldX { get; set; }

    public short WorldY { get; set; }

    public string Liberator { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteUTF(Name);
        writer.WriteShort(WorldX);
        writer.WriteShort(WorldY);
        writer.WriteUTF(Liberator);
    }

    public override void Deserialize(IDataReader reader)
    {
        Name = reader.ReadUTF();
        WorldX = reader.ReadShort();
        WorldY = reader.ReadShort();
        Liberator = reader.ReadUTF();
    }
}