using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class MigratedServerListMessage : Message
{
    public const uint Id = 970;

    public MigratedServerListMessage(IEnumerable<ushort> migratedServerIds)
    {
        MigratedServerIds = migratedServerIds;
    }

    public MigratedServerListMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ushort> MigratedServerIds { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) MigratedServerIds.Count());
        foreach (ushort objectToSend in MigratedServerIds) writer.WriteVarUShort(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort migratedServerIdsCount = reader.ReadUShort();
        var migratedServerIds_ = new ushort[migratedServerIdsCount];

        for (var migratedServerIdsIndex = 0; migratedServerIdsIndex < migratedServerIdsCount; migratedServerIdsIndex++)
            migratedServerIds_[migratedServerIdsIndex] = reader.ReadVarUShort();
        MigratedServerIds = migratedServerIds_;
    }
}