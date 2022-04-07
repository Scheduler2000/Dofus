using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class RecycleResultMessage : Message
{
    public const uint Id = 2853;

    public RecycleResultMessage(uint nuggetsForPrism, uint nuggetsForPlayer)
    {
        NuggetsForPrism = nuggetsForPrism;
        NuggetsForPlayer = nuggetsForPlayer;
    }

    public RecycleResultMessage()
    {
    }

    public override uint MessageId => Id;

    public uint NuggetsForPrism { get; set; }

    public uint NuggetsForPlayer { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(NuggetsForPrism);
        writer.WriteVarUInt(NuggetsForPlayer);
    }

    public override void Deserialize(IDataReader reader)
    {
        NuggetsForPrism = reader.ReadVarUInt();
        NuggetsForPlayer = reader.ReadVarUInt();
    }
}