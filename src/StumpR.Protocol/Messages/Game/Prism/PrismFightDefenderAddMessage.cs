using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PrismFightDefenderAddMessage : Message
{
    public const uint Id = 58;

    public PrismFightDefenderAddMessage(ushort subAreaId, ushort fightId, CharacterMinimalPlusLookInformations defender)
    {
        SubAreaId = subAreaId;
        FightId = fightId;
        Defender = defender;
    }

    public PrismFightDefenderAddMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort SubAreaId { get; set; }

    public ushort FightId { get; set; }

    public CharacterMinimalPlusLookInformations Defender { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(SubAreaId);
        writer.WriteVarUShort(FightId);
        writer.WriteShort(Defender.TypeId);
        Defender.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        SubAreaId = reader.ReadVarUShort();
        FightId = reader.ReadVarUShort();
        Defender = ProtocolTypeManager.GetInstance<CharacterMinimalPlusLookInformations>(reader.ReadShort());
        Defender.Deserialize(reader);
    }
}