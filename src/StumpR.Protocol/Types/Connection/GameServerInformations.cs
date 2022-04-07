using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameServerInformations
{
    public const short Id = 5238;

    public GameServerInformations(bool isMonoAccount,
        bool isSelectable,
        ushort objectId,
        sbyte type,
        sbyte status,
        sbyte completion,
        sbyte charactersCount,
        sbyte charactersSlots,
        double date)
    {
        IsMonoAccount = isMonoAccount;
        IsSelectable = isSelectable;
        ObjectId = objectId;
        Type = type;
        Status = status;
        Completion = completion;
        CharactersCount = charactersCount;
        CharactersSlots = charactersSlots;
        Date = date;
    }

    public GameServerInformations()
    {
    }

    public virtual short TypeId => Id;

    public bool IsMonoAccount { get; set; }

    public bool IsSelectable { get; set; }

    public ushort ObjectId { get; set; }

    public sbyte Type { get; set; }

    public sbyte Status { get; set; }

    public sbyte Completion { get; set; }

    public sbyte CharactersCount { get; set; }

    public sbyte CharactersSlots { get; set; }

    public double Date { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, IsMonoAccount);
        flag = BooleanByteWrapper.SetFlag(flag, 1, IsSelectable);
        writer.WriteByte(flag);
        writer.WriteVarUShort(ObjectId);
        writer.WriteSByte(Type);
        writer.WriteSByte(Status);
        writer.WriteSByte(Completion);
        writer.WriteSByte(CharactersCount);
        writer.WriteSByte(CharactersSlots);
        writer.WriteDouble(Date);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        byte flag = reader.ReadByte();
        IsMonoAccount = BooleanByteWrapper.GetFlag(flag, 0);
        IsSelectable = BooleanByteWrapper.GetFlag(flag, 1);
        ObjectId = reader.ReadVarUShort();
        Type = reader.ReadSByte();
        Status = reader.ReadSByte();
        Completion = reader.ReadSByte();
        CharactersCount = reader.ReadSByte();
        CharactersSlots = reader.ReadSByte();
        Date = reader.ReadDouble();
    }
}