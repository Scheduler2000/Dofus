using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class StatsPreset : Preset
{
    public new const short Id = 6559;

    public StatsPreset(short objectId, IEnumerable<SimpleCharacterCharacteristicForPreset> stats)
    {
        ObjectId = objectId;
        Stats = stats;
    }

    public StatsPreset()
    {
    }

    public override short TypeId => Id;

    public IEnumerable<SimpleCharacterCharacteristicForPreset> Stats { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort((short) Stats.Count());
        foreach (SimpleCharacterCharacteristicForPreset objectToSend in Stats) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ushort statsCount = reader.ReadUShort();
        var stats_ = new SimpleCharacterCharacteristicForPreset[statsCount];

        for (var statsIndex = 0; statsIndex < statsCount; statsIndex++)
        {
            var objectToAdd = new SimpleCharacterCharacteristicForPreset();
            objectToAdd.Deserialize(reader);
            stats_[statsIndex] = objectToAdd;
        }
        Stats = stats_;
    }
}