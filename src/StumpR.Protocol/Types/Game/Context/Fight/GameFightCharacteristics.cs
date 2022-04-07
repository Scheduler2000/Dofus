using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameFightCharacteristics
{
    public const short Id = 7425;

    public GameFightCharacteristics(CharacterCharacteristics characteristics, double summoner, bool summoned, sbyte invisibilityState)
    {
        Characteristics = characteristics;
        Summoner = summoner;
        Summoned = summoned;
        InvisibilityState = invisibilityState;
    }

    public GameFightCharacteristics()
    {
    }

    public virtual short TypeId => Id;

    public CharacterCharacteristics Characteristics { get; set; }

    public double Summoner { get; set; }

    public bool Summoned { get; set; }

    public sbyte InvisibilityState { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        Characteristics.Serialize(writer);
        writer.WriteDouble(Summoner);
        writer.WriteBoolean(Summoned);
        writer.WriteSByte(InvisibilityState);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        Characteristics = new CharacterCharacteristics();
        Characteristics.Deserialize(reader);
        Summoner = reader.ReadDouble();
        Summoned = reader.ReadBoolean();
        InvisibilityState = reader.ReadSByte();
    }
}