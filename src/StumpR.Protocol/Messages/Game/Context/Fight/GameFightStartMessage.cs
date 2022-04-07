using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameFightStartMessage : Message
{
    public const uint Id = 5357;

    public GameFightStartMessage(IEnumerable<Idol> idols)
    {
        Idols = idols;
    }

    public GameFightStartMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<Idol> Idols { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Idols.Count());
        foreach (Idol objectToSend in Idols) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort idolsCount = reader.ReadUShort();
        var idols_ = new Idol[idolsCount];

        for (var idolsIndex = 0; idolsIndex < idolsCount; idolsIndex++)
        {
            var objectToAdd = new Idol();
            objectToAdd.Deserialize(reader);
            idols_[idolsIndex] = objectToAdd;
        }
        Idols = idols_;
    }
}