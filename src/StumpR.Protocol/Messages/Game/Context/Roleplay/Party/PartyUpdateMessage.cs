using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PartyUpdateMessage : AbstractPartyEventMessage
{
    public new const uint Id = 1769;

    public PartyUpdateMessage(uint partyId, PartyMemberInformations memberInformations)
    {
        PartyId = partyId;
        MemberInformations = memberInformations;
    }

    public PartyUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public PartyMemberInformations MemberInformations { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort(MemberInformations.TypeId);
        MemberInformations.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        MemberInformations = ProtocolTypeManager.GetInstance<PartyMemberInformations>(reader.ReadShort());
        MemberInformations.Deserialize(reader);
    }
}