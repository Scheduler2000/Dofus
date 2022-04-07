using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class DungeonKeyRingMessage : Message
{
    public const uint Id = 6497;

    public DungeonKeyRingMessage(IEnumerable<ushort> availables, IEnumerable<ushort> unavailables)
    {
        Availables = availables;
        Unavailables = unavailables;
    }

    public DungeonKeyRingMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ushort> Availables { get; set; }

    public IEnumerable<ushort> Unavailables { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Availables.Count());
        foreach (ushort objectToSend in Availables) writer.WriteVarUShort(objectToSend);
        writer.WriteShort((short) Unavailables.Count());
        foreach (ushort objectToSend in Unavailables) writer.WriteVarUShort(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort availablesCount = reader.ReadUShort();
        var availables_ = new ushort[availablesCount];

        for (var availablesIndex = 0; availablesIndex < availablesCount; availablesIndex++)
            availables_[availablesIndex] = reader.ReadVarUShort();
        Availables = availables_;
        ushort unavailablesCount = reader.ReadUShort();
        var unavailables_ = new ushort[unavailablesCount];

        for (var unavailablesIndex = 0; unavailablesIndex < unavailablesCount; unavailablesIndex++)
            unavailables_[unavailablesIndex] = reader.ReadVarUShort();
        Unavailables = unavailables_;
    }
}