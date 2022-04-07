using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PartyJoinMessage : AbstractPartyMessage
{
    public new const uint Id = 2536;

    public PartyJoinMessage(uint partyId,
        sbyte partyType,
        ulong partyLeaderId,
        sbyte maxParticipants,
        IEnumerable<PartyMemberInformations> members,
        IEnumerable<PartyGuestInformations> guests,
        bool restricted,
        string partyName)
    {
        PartyId = partyId;
        PartyType = partyType;
        PartyLeaderId = partyLeaderId;
        MaxParticipants = maxParticipants;
        Members = members;
        Guests = guests;
        Restricted = restricted;
        PartyName = partyName;
    }

    public PartyJoinMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte PartyType { get; set; }

    public ulong PartyLeaderId { get; set; }

    public sbyte MaxParticipants { get; set; }

    public IEnumerable<PartyMemberInformations> Members { get; set; }

    public IEnumerable<PartyGuestInformations> Guests { get; set; }

    public bool Restricted { get; set; }

    public string PartyName { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteSByte(PartyType);
        writer.WriteVarULong(PartyLeaderId);
        writer.WriteSByte(MaxParticipants);
        writer.WriteShort((short) Members.Count());

        foreach (PartyMemberInformations objectToSend in Members)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
        writer.WriteShort((short) Guests.Count());
        foreach (PartyGuestInformations objectToSend in Guests) objectToSend.Serialize(writer);
        writer.WriteBoolean(Restricted);
        writer.WriteUTF(PartyName);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        PartyType = reader.ReadSByte();
        PartyLeaderId = reader.ReadVarULong();
        MaxParticipants = reader.ReadSByte();
        ushort membersCount = reader.ReadUShort();
        var members_ = new PartyMemberInformations[membersCount];

        for (var membersIndex = 0; membersIndex < membersCount; membersIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<PartyMemberInformations>(reader.ReadShort());
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
        Restricted = reader.ReadBoolean();
        PartyName = reader.ReadUTF();
    }
}