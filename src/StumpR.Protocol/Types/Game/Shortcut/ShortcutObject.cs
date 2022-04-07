using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ShortcutObject : Shortcut
{
    public new const short Id = 8583;

    public ShortcutObject(sbyte slot)
    {
        Slot = slot;
    }

    public ShortcutObject()
    {
    }

    public override short TypeId => Id;

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
    }
}