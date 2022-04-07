using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class TaxCollectorMovement
{
    public const short Id = 6775;

    public TaxCollectorMovement(sbyte movementType, TaxCollectorBasicInformations basicInfos, ulong playerId, string playerName)
    {
        MovementType = movementType;
        BasicInfos = basicInfos;
        PlayerId = playerId;
        PlayerName = playerName;
    }

    public TaxCollectorMovement()
    {
    }

    public virtual short TypeId => Id;

    public sbyte MovementType { get; set; }

    public TaxCollectorBasicInformations BasicInfos { get; set; }

    public ulong PlayerId { get; set; }

    public string PlayerName { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(MovementType);
        BasicInfos.Serialize(writer);
        writer.WriteVarULong(PlayerId);
        writer.WriteUTF(PlayerName);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        MovementType = reader.ReadSByte();
        BasicInfos = new TaxCollectorBasicInformations();
        BasicInfos.Deserialize(reader);
        PlayerId = reader.ReadVarULong();
        PlayerName = reader.ReadUTF();
    }
}