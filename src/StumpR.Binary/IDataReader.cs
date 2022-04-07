namespace StumpR.Binary;

public interface IDataReader : ISeekable
{
    /// <summary>
    ///   Gets availiable bytes number in the buffer
    /// </summary>
    public long Remaining { get; }

    public int BytesRead { get; }
    
    /// <summary>
    ///     Reads a short from the Buffer
    /// </summary>
    /// <returns></returns>
    short ReadShort();

    /// <summary>
    ///     Reads an int from the Buffer
    /// </summary>
    /// <returns></returns>
    int ReadInt();

    /// <summary>
    ///     Reads a long from the Buffer
    /// </summary>
    /// <returns></returns>
    long ReadLong();


    /// <summary>
    ///     Reads an ushort from the Buffer
    /// </summary>
    /// <returns></returns>
    ushort ReadUShort();

    /// <summary>
    ///     Reads an uint from the Buffer
    /// </summary>
    /// <returns></returns>
    uint ReadUInt();

    /// <summary>
    ///     Reads an ulong from the Buffer
    /// </summary>
    /// <returns></returns>
    ulong ReadULong();

    /// <summary>
    ///     Reads a byte from the Buffer
    /// </summary>
    /// <returns></returns>
    byte ReadByte();

    /// <summary>
    ///     Reads a sbyte from the Buffer
    /// </summary>
    /// <returns></returns>
    sbyte ReadSByte();

    /// <summary>
    ///     Reads N bytes from the buffer
    /// </summary>
    /// <param name="n">Number of bytes Reads.</param>
    /// <returns></returns>
    byte[] ReadBytes(int n);

    /// <summary>
    ///     Reads a boolean from the Buffer
    /// </summary>
    /// <returns></returns>
    bool ReadBoolean();

    /// <summary>
    ///     Reads a char from the Buffer
    /// </summary>
    /// <returns></returns>
    char ReadChar();

    /// <summary>
    ///     Reads a double from the Buffer
    /// </summary>
    /// <returns></returns>
    double ReadDouble();

    /// <summary>
    ///     Reads a float from the Buffer
    /// </summary>
    /// <returns></returns>
    float ReadFloat();

    /// <summary>
    ///     Reads a string in the buffer in utf8 format after reading his length in ushort (2 bytes)
    /// </summary>
    /// <returns></returns>
    string ReadUTF();

    /// <summary>
    ///     Reads a string from the Buffer in utf8 format
    /// </summary>
    /// <returns></returns>
    string ReadUTFBytes(ushort len);

    /* ---------------------- CUSTOM METHODS RELATED TO DOFUS 2.X ---------------------- */

    /* -------- RELATED TO : com.ankamagames.jerakine.network.CustomDataWrapper --------*/

    short ReadVarShort();

    ushort ReadVarUShort();

    int ReadVarInt();

    uint ReadVarUInt();

    long ReadVarLong();

    ulong ReadVarULong();


    /* ---------------------- CUSTOM METHODS RELATED TO DOFUS 2.X ---------------------- */
}