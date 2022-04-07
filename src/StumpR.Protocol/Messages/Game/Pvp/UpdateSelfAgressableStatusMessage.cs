using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class UpdateSelfAgressableStatusMessage : Message
{
    public const uint Id = 4140;

    public UpdateSelfAgressableStatusMessage(sbyte status, int probationTime)
    {
        Status = status;
        ProbationTime = probationTime;
    }

    public UpdateSelfAgressableStatusMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte Status { get; set; }

    public int ProbationTime { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(Status);
        writer.WriteInt(ProbationTime);
    }

    public override void Deserialize(IDataReader reader)
    {
        Status = reader.ReadSByte();
        ProbationTime = reader.ReadInt();
    }
}