using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class BasicStatWithDataMessage : BasicStatMessage
{
    public new const uint Id = 1144;

    public BasicStatWithDataMessage(double timeSpent, ushort statId, IEnumerable<StatisticData> datas)
    {
        TimeSpent = timeSpent;
        StatId = statId;
        Datas = datas;
    }

    public BasicStatWithDataMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<StatisticData> Datas { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort((short) Datas.Count());

        foreach (StatisticData objectToSend in Datas)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ushort datasCount = reader.ReadUShort();
        var datas_ = new StatisticData[datasCount];

        for (var datasIndex = 0; datasIndex < datasCount; datasIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<StatisticData>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            datas_[datasIndex] = objectToAdd;
        }
        Datas = datas_;
    }
}