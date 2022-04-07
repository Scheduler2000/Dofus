using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PartyInvitationDungeonRequestMessage : PartyInvitationRequestMessage
{
    public new const uint Id = 8333;

    public PartyInvitationDungeonRequestMessage(AbstractPlayerSearchInformation target, ushort dungeonId)
    {
        Target = target;
        DungeonId = dungeonId;
    }

    public PartyInvitationDungeonRequestMessage()
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