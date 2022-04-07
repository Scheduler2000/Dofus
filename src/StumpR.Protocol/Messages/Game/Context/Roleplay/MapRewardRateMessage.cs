using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class MapRewardRateMessage : Message
{
    public const uint Id = 1514;

    public MapRewardRateMessage(short mapRate, short subAreaRate, short totalRate)
    {
        MapRate = mapRate;
        SubAreaRate = subAreaRate;
        TotalRate = totalRate;
    }

    public MapRewardRateMessage()
    {
    }

    public override uint MessageId => Id;

    public short MapRate { get; set; }

    public short SubAreaRate { get; set; }

    public short TotalRate { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarShort(MapRate);
        writer.WriteVarShort(SubAreaRate);
        writer.WriteVarShort(TotalRate);
    }

    public override void Deserialize(IDataReader reader)
    {
        MapRate = reader.ReadVarShort();
        SubAreaRate = reader.ReadVarShort();
        TotalRate = reader.ReadVarShort();
    }
}