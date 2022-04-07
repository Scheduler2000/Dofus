using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PartyLocateMembersMessage : AbstractPartyMessage
{
    public new const uint Id = 3205;

    public PartyLocateMembersMessage(uint partyId, IEnumerable<PartyMemberGeoPosition> geopositions)
    {
        PartyId = partyId;
        Geopositions = geopositions;
    }

    public PartyLocateMembersMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<PartyMemberGeoPosition> Geopositions { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort((short) Geopositions.Count());
        foreach (PartyMemberGeoPosition objectToSend in Geopositions) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ushort geopositionsCount = reader.ReadUShort();
        var geopositions_ = new PartyMemberGeoPosition[geopositionsCount];

        for (var geopositionsIndex = 0; geopositionsIndex < geopositionsCount; geopositionsIndex++)
        {
            var objectToAdd = new PartyMemberGeoPosition();
            objectToAdd.Deserialize(reader);
            geopositions_[geopositionsIndex] = objectToAdd;
        }
        Geopositions = geopositions_;
    }
}