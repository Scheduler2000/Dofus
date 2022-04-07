using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class NpcGenericActionRequestMessage : Message
{
    public const uint Id = 1598;

    public NpcGenericActionRequestMessage(int npcId, sbyte npcActionId, double npcMapId)
    {
        NpcId = npcId;
        NpcActionId = npcActionId;
        NpcMapId = npcMapId;
    }

    public NpcGenericActionRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public int NpcId { get; set; }

    public sbyte NpcActionId { get; set; }

    public double NpcMapId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteInt(NpcId);
        writer.WriteSByte(NpcActionId);
        writer.WriteDouble(NpcMapId);
    }

    public override void Deserialize(IDataReader reader)
    {
        NpcId = reader.ReadInt();
        NpcActionId = reader.ReadSByte();
        NpcMapId = reader.ReadDouble();
    }
}