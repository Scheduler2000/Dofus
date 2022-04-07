using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HavenBagFurnituresRequestMessage : Message
{
    public const uint Id = 8486;

    public HavenBagFurnituresRequestMessage(IEnumerable<ushort> cellIds, IEnumerable<int> funitureIds, IEnumerable<byte> orientations)
    {
        CellIds = cellIds;
        FunitureIds = funitureIds;
        Orientations = orientations;
    }

    public HavenBagFurnituresRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ushort> CellIds { get; set; }

    public IEnumerable<int> FunitureIds { get; set; }

    public IEnumerable<byte> Orientations { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) CellIds.Count());
        foreach (ushort objectToSend in CellIds) writer.WriteVarUShort(objectToSend);
        writer.WriteShort((short) FunitureIds.Count());
        foreach (int objectToSend in FunitureIds) writer.WriteInt(objectToSend);
        writer.WriteShort((short) Orientations.Count());
        foreach (byte objectToSend in Orientations) writer.WriteByte(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort cellIdsCount = reader.ReadUShort();
        var cellIds_ = new ushort[cellIdsCount];
        for (var cellIdsIndex = 0; cellIdsIndex < cellIdsCount; cellIdsIndex++) cellIds_[cellIdsIndex] = reader.ReadVarUShort();
        CellIds = cellIds_;
        ushort funitureIdsCount = reader.ReadUShort();
        var funitureIds_ = new int[funitureIdsCount];

        for (var funitureIdsIndex = 0; funitureIdsIndex < funitureIdsCount; funitureIdsIndex++)
            funitureIds_[funitureIdsIndex] = reader.ReadInt();
        FunitureIds = funitureIds_;
        ushort orientationsCount = reader.ReadUShort();
        var orientations_ = new byte[orientationsCount];

        for (var orientationsIndex = 0; orientationsIndex < orientationsCount; orientationsIndex++)
            orientations_[orientationsIndex] = reader.ReadByte();
        Orientations = orientations_;
    }
}