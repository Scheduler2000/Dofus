using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ObjectEffectDice : ObjectEffect
{
    public new const short Id = 1048;

    public ObjectEffectDice(ushort actionId, uint diceNum, uint diceSide, uint diceConst)
    {
        ActionId = actionId;
        DiceNum = diceNum;
        DiceSide = diceSide;
        DiceConst = diceConst;
    }

    public ObjectEffectDice()
    {
    }

    public override short TypeId => Id;

    public uint DiceNum { get; set; }

    public uint DiceSide { get; set; }

    public uint DiceConst { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUInt(DiceNum);
        writer.WriteVarUInt(DiceSide);
        writer.WriteVarUInt(DiceConst);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        DiceNum = reader.ReadVarUInt();
        DiceSide = reader.ReadVarUInt();
        DiceConst = reader.ReadVarUInt();
    }
}