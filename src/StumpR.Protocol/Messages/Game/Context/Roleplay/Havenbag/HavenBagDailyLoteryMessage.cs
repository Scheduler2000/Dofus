using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HavenBagDailyLoteryMessage : Message
{
    public const uint Id = 2198;

    public HavenBagDailyLoteryMessage(sbyte returnType, string gameActionId)
    {
        ReturnType = returnType;
        GameActionId = gameActionId;
    }

    public HavenBagDailyLoteryMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte ReturnType { get; set; }

    public string GameActionId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(ReturnType);
        writer.WriteUTF(GameActionId);
    }

    public override void Deserialize(IDataReader reader)
    {
        ReturnType = reader.ReadSByte();
        GameActionId = reader.ReadUTF();
    }
}