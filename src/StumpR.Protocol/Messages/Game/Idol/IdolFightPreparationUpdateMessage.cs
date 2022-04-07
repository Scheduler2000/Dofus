using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class IdolFightPreparationUpdateMessage : Message
{
    public const uint Id = 7338;

    public IdolFightPreparationUpdateMessage(sbyte idolSource, IEnumerable<Idol> idols)
    {
        IdolSource = idolSource;
        Idols = idols;
    }

    public IdolFightPreparationUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte IdolSource { get; set; }

    public IEnumerable<Idol> Idols { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(IdolSource);
        writer.WriteShort((short) Idols.Count());

        foreach (Idol objectToSend in Idols)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        IdolSource = reader.ReadSByte();
        ushort idolsCount = reader.ReadUShort();
        var idols_ = new Idol[idolsCount];

        for (var idolsIndex = 0; idolsIndex < idolsCount; idolsIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<Idol>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            idols_[idolsIndex] = objectToAdd;
        }
        Idols = idols_;
    }
}