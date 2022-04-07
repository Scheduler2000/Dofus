using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeMountsTakenFromPaddockMessage : Message
{
    public const uint Id = 2526;

    public ExchangeMountsTakenFromPaddockMessage(string name, short worldX, short worldY, string ownername)
    {
        Name = name;
        WorldX = worldX;
        WorldY = worldY;
        Ownername = ownername;
    }

    public ExchangeMountsTakenFromPaddockMessage()
    {
    }

    public override uint MessageId => Id;

    public string Name { get; set; }

    public short WorldX { get; set; }

    public short WorldY { get; set; }

    public string Ownername { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteUTF(Name);
        writer.WriteShort(WorldX);
        writer.WriteShort(WorldY);
        writer.WriteUTF(Ownername);
    }

    public override void Deserialize(IDataReader reader)
    {
        Name = reader.ReadUTF();
        WorldX = reader.ReadShort();
        WorldY = reader.ReadShort();
        Ownername = reader.ReadUTF();
    }
}