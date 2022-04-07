using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class TitlesAndOrnamentsListMessage : Message
{
    public const uint Id = 6204;

    public TitlesAndOrnamentsListMessage(IEnumerable<ushort> titles,
        IEnumerable<ushort> ornaments,
        ushort activeTitle,
        ushort activeOrnament)
    {
        Titles = titles;
        Ornaments = ornaments;
        ActiveTitle = activeTitle;
        ActiveOrnament = activeOrnament;
    }

    public TitlesAndOrnamentsListMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ushort> Titles { get; set; }

    public IEnumerable<ushort> Ornaments { get; set; }

    public ushort ActiveTitle { get; set; }

    public ushort ActiveOrnament { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Titles.Count());
        foreach (ushort objectToSend in Titles) writer.WriteVarUShort(objectToSend);
        writer.WriteShort((short) Ornaments.Count());
        foreach (ushort objectToSend in Ornaments) writer.WriteVarUShort(objectToSend);
        writer.WriteVarUShort(ActiveTitle);
        writer.WriteVarUShort(ActiveOrnament);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort titlesCount = reader.ReadUShort();
        var titles_ = new ushort[titlesCount];
        for (var titlesIndex = 0; titlesIndex < titlesCount; titlesIndex++) titles_[titlesIndex] = reader.ReadVarUShort();
        Titles = titles_;
        ushort ornamentsCount = reader.ReadUShort();
        var ornaments_ = new ushort[ornamentsCount];

        for (var ornamentsIndex = 0; ornamentsIndex < ornamentsCount; ornamentsIndex++)
            ornaments_[ornamentsIndex] = reader.ReadVarUShort();
        Ornaments = ornaments_;
        ActiveTitle = reader.ReadVarUShort();
        ActiveOrnament = reader.ReadVarUShort();
    }
}