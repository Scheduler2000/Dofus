using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class TaxCollectorMovementMessage : Message
{
    public const uint Id = 4589;

    public TaxCollectorMovementMessage(sbyte movementType, TaxCollectorBasicInformations basicInfos, ulong playerId, string playerName)
    {
        MovementType = movementType;
        BasicInfos = basicInfos;
        PlayerId = playerId;
        PlayerName = playerName;
    }

    public TaxCollectorMovementMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte MovementType { get; set; }

    public TaxCollectorBasicInformations BasicInfos { get; set; }

    public ulong PlayerId { get; set; }

    public string PlayerName { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(MovementType);
        BasicInfos.Serialize(writer);
        writer.WriteVarULong(PlayerId);
        writer.WriteUTF(PlayerName);
    }

    public override void Deserialize(IDataReader reader)
    {
        MovementType = reader.ReadSByte();
        BasicInfos = new TaxCollectorBasicInformations();
        BasicInfos.Deserialize(reader);
        PlayerId = reader.ReadVarULong();
        PlayerName = reader.ReadUTF();
    }
}