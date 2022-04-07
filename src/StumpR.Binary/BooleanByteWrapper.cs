namespace StumpR.Binary;

/// <summary>
///     <see cref="BooleanByteWrapper" /> relates logic located in
///     com.ankamagames.jerakine.network.utils.BooleanByteWrapper
/// </summary>
public static class BooleanByteWrapper
{
    public static bool GetFlag(byte flag, byte offset)
    {
        if (offset >= 8) throw new ArgumentException("offset must be lesser than 8");
        return (flag & (uint) (byte) (1 << offset)) > 0U;
    }

    public static byte SetFlag(byte flag, byte offset, bool value)
    {
        if (offset >= 8) throw new ArgumentException("offset must be lesser than 8");
        return value ? (byte) (flag | (1U << offset)) : (byte) (flag & (uint) (byte.MaxValue - (1 << offset)));
    }

    public static byte SetFlag(int flag, byte offset, bool value)
    {
        if (offset >= 8) throw new ArgumentException("offset must be lesser than 8");
        return value ? (byte) (flag | (1 << offset)) : (byte) (flag & (byte.MaxValue - (1 << offset)));
    }
}