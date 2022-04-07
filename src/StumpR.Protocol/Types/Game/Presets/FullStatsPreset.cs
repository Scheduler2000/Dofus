using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class FullStatsPreset : Preset
{
    public new const short Id = 9471;

    public FullStatsPreset(short objectId, IEnumerable<CharacterCharacteristicForPreset> stats)
    {
        ObjectId = objectId;
        Stats = stats;
    }

    public FullStatsPreset()
    {
    }

    public override short TypeId => Id;

    public IEnumerable<CharacterCharacteristicForPreset> Stats { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort((short) Stats.Count());
        foreach (CharacterCharacteristicForPreset objectToSend in Stats) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ushort statsCount = reader.ReadUShort();
        var stats_ = new CharacterCharacteristicForPreset[statsCount];

        for (var statsIndex = 0; statsIndex < statsCount; statsIndex++)
        {
            var objectToAdd = new CharacterCharacteristicForPreset();
            objectToAdd.Deserialize(reader);
            stats_[statsIndex] = objectToAdd;
        }
        Stats = stats_;
    }
}