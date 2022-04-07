namespace StumpR.Binary;

public interface IDataWriter : ISeekable, IDisposable
{
    /// <summary>
    ///   Gets availiable bytes number in the buffer
    /// </summary>
    public long BytesAvailable { get; }
    
    /// <summary>
    ///     Buffer containing the written values
    /// </summary>
    byte[] Buffer { get; }

    long Position { get; }

    /// <summary>
    ///     Writes a short into the buffer
    /// </summary>
    /// <returns></returns>
    void WriteShort(short value);

    /// <summary>
    ///     Writes a int into the buffer
    /// </summary>
    /// <returns></returns>
    void WriteInt(int @int);

    /// <summary>
    ///     Writes a long into the buffer
    /// </summary>
    /// <returns></returns>
    void WriteLong(long @long);

    /// <summary>
    ///     Writes a ushort into the buffer
    /// </summary>
    /// <returns></returns>
    void WriteUShort(ushort @ushort);

    /// <summary>
    ///     Writes a int into the buffer
    /// </summary>
    /// <returns></returns>
    void WriteUInt(uint @uint);

    /// <summary>
    ///     Writes a long into the buffer
    /// </summary>
    /// <returns></returns>
    void WriteULong(ulong @ulong);

    /// <summary>
    ///     Writes a byte into the buffer
    /// </summary>
    /// <returns></returns>
    void WriteByte(byte @byte);


    /// <summary>
    ///     Writes a sbyte into the buffer
    /// </summary>
    /// <returns></returns>
    void WriteSByte(sbyte @byte);

    /// <summary>
    ///     Writes a float into the buffer
    /// </summary>
    /// <returns></returns>
    void WriteFloat(float @float);

    /// <summary>
    ///     Writes a boolean into the buffer
    /// </summary>
    /// <returns></returns>
    void WriteBoolean(bool @bool);

    /// <summary>
    ///     Writes a char into the buffer
    /// </summary>
    /// <returns></returns>
    void WriteChar(char @char);

    /// <summary>
    ///     Writes a double into the buffer
    /// </summary>
    void WriteDouble(double @double);

    /// <summary>
    ///     Writes a float into the buffer
    /// </summary>
    /// <returns></returns>
    void WriteSingle(float single);

    /// <summary>
    ///     Writes a string in the buffer in utf8 format after writing his length in ushort (2 bytes)
    /// </summary>
    /// <returns></returns>
    void WriteUTF(string str);

    /// <summary>
    ///     Writes a string into the buffer in utf8 format
    /// </summary>
    /// <returns></returns>
    void WriteUTFBytes(string str);

    /// <summary>
    ///     Writes a bytes array into the buffer
    /// </summary>
    /// <returns></returns>
    void WriteBytes(byte[] data);


    /* ---------------------- CUSTOM METHODS RELATED TO DOFUS 2.X ---------------------- */

    /* -------- RELATED TO : com.ankamagames.jerakine.network.CustomDataWrapper --------*/

    void WriteVarShort(short @short);

    void WriteVarUShort(ushort @ushort);

    void WriteVarInt(int @int);

    void WriteVarUInt(uint @uint);

    void WriteVarLong(long @long);

    void WriteVarULong(ulong @ulong);


    /* ---------------------- CUSTOM METHODS RELATED TO DOFUS 2.X ---------------------- */
}