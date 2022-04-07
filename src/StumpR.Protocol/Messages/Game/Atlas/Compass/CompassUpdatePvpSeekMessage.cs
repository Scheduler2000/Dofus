using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class CompassUpdatePvpSeekMessage : CompassUpdateMessage
{
    public new const uint Id = 5714;

    public CompassUpdatePvpSeekMessage(sbyte type, MapCoordinates coords, ulong memberId, string memberName)
    {
        Type = type;
        Coords = coords;
        MemberId = memberId;
        MemberName = memberName;
    }

    public CompassUpdatePvpSeekMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong MemberId { get; set; }

    public string MemberName { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarULong(MemberId);
        writer.WriteUTF(MemberName);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        MemberId = reader.ReadVarULong();
        MemberName = reader.ReadUTF();
    }
}