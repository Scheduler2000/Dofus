using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class DiceRollRequestMessage : Message
{
    public const uint Id = 932;

    public DiceRollRequestMessage(uint dice, uint faces, sbyte channel)
    {
        Dice = dice;
        Faces = faces;
        Channel = channel;
    }

    public DiceRollRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public uint Dice { get; set; }

    public uint Faces { get; set; }

    public sbyte Channel { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(Dice);
        writer.WriteVarUInt(Faces);
        writer.WriteSByte(Channel);
    }

    public override void Deserialize(IDataReader reader)
    {
        Dice = reader.ReadVarUInt();
        Faces = reader.ReadVarUInt();
        Channel = reader.ReadSByte();
    }
}