using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class HumanOptionEmote : HumanOption
{
    public new const short Id = 3456;

    public HumanOptionEmote(ushort emoteId, double emoteStartTime)
    {
        EmoteId = emoteId;
        EmoteStartTime = emoteStartTime;
    }

    public HumanOptionEmote()
    {
    }

    public override short TypeId => Id;

    public ushort EmoteId { get; set; }

    public double EmoteStartTime { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUShort(EmoteId);
        writer.WriteDouble(EmoteStartTime);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        EmoteId = reader.ReadUShort();
        EmoteStartTime = reader.ReadDouble();
    }
}