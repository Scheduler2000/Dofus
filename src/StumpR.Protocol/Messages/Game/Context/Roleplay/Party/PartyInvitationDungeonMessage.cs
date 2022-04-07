using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PartyInvitationDungeonMessage : PartyInvitationMessage
{
    public new const uint Id = 9837;

    public PartyInvitationDungeonMessage(uint partyId,
        sbyte partyType,
        string partyName,
        sbyte maxParticipants,
        ulong fromId,
        string fromName,
        ulong toId,
        ushort dungeonId)
    {
        PartyId = partyId;
        PartyType = partyType;
        PartyName = partyName;
        MaxParticipants = maxParticipants;
        FromId = fromId;
        FromName = fromName;
        ToId = toId;
        DungeonId = dungeonId;
    }

    public PartyInvitationDungeonMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort DungeonId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(DungeonId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        DungeonId = reader.ReadVarUShort();
    }
}