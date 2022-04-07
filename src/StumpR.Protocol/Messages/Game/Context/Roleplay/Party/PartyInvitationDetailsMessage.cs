using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PartyInvitationDetailsMessage : AbstractPartyMessage
{
    public new const uint Id = 3615;

    public PartyInvitationDetailsMessage(uint partyId,
        sbyte partyType,
        string partyName,
        ulong fromId,
        string fromName,
        ulong leaderId,
        IEnumerable<PartyInvitationMemberInformations> members,
        IEnumerable<PartyGuestInformations> guests)
    {
        PartyId = partyId;
        PartyType = partyType;
        PartyName = partyName;
        FromId = fromId;
        FromName = fromName;
        LeaderId = leaderId;
        Members = members;
        Guests = guests;
    }

    public PartyInvitationDetailsMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte PartyType { get; set; }

    public string PartyName { get; set; }

    public ulong FromId { get; set; }

    public string FromName { get; set; }

    public ulong LeaderId { get; set; }

    public IEnumerable<PartyInvitationMemberInformations> Members { get; set; }

    public IEnumerable<PartyGuestInformations> Guests { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteSByte(PartyType);
        writer.WriteUTF(PartyName);
        writer.WriteVarULong(FromId);
        writer.WriteUTF(FromName);
        writer.WriteVarULong(LeaderId);
        writer.WriteShort((short) Members.Count());

        foreach (PartyInvitationMemberInformations objectToSend in Members)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
        writer.WriteShort((short) Guests.Count());
        foreach (PartyGuestInformations objectToSend in Guests) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        PartyType = reader.ReadSByte();
        PartyName = reader.ReadUTF();
        FromId = reader.ReadVarULong();
        FromName = reader.ReadUTF();
        LeaderId = reader.ReadVarULong();
        ushort membersCount = reader.ReadUShort();
        var members_ = new PartyInvitationMemberInformations[membersCount];

        for (var membersIndex = 0; membersIndex < membersCount; membersIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<PartyInvitationMemberInformations>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            members_[membersIndex] = objectToAdd;
        }
        Members = members_;
        ushort guestsCount = reader.ReadUShort();
        var guests_ = new PartyGuestInformations[guestsCount];

        for (var guestsIndex = 0; guestsIndex < guestsCount; guestsIndex++)
        {
            var objectToAdd = new PartyGuestInformations();
            objectToAdd.Deserialize(reader);
            guests_[guestsIndex] = objectToAdd;
        }
        Guests = guests_;
    }
}