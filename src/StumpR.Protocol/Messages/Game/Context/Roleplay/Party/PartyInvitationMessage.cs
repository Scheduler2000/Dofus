using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PartyInvitationMessage : AbstractPartyMessage
{
    public new const uint Id = 1660;

    public PartyInvitationMessage(uint partyId,
        sbyte partyType,
        string partyName,
        sbyte maxParticipants,
        ulong fromId,
        string fromName,
        ulong toId)
    {
        PartyId = partyId;
        PartyType = partyType;
        PartyName = partyName;
        MaxParticipants = maxParticipants;
        FromId = fromId;
        FromName = fromName;
        ToId = toId;
    }

    public PartyInvitationMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte PartyType { get; set; }

    public string PartyName { get; set; }

    public sbyte MaxParticipants { get; set; }

    public ulong FromId { get; set; }

    public string FromName { get; set; }

    public ulong ToId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteSByte(PartyType);
        writer.WriteUTF(PartyName);
        writer.WriteSByte(MaxParticipants);
        writer.WriteVarULong(FromId);
        writer.WriteUTF(FromName);
        writer.WriteVarULong(ToId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        PartyType = reader.ReadSByte();
        PartyName = reader.ReadUTF();
        MaxParticipants = reader.ReadSByte();
        FromId = reader.ReadVarULong();
        FromName = reader.ReadUTF();
        ToId = reader.ReadVarULong();
    }
}