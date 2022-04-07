using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AlmanachCalendarDateMessage : Message
{
    public const uint Id = 2577;

    public AlmanachCalendarDateMessage(int date)
    {
        Date = date;
    }

    public AlmanachCalendarDateMessage()
    {
    }

    public override uint MessageId => Id;

    public int Date { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteInt(Date);
    }

    public override void Deserialize(IDataReader reader)
    {
        Date = reader.ReadInt();
    }
}