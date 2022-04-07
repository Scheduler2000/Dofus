namespace StumpR.Binary;

/// <summary>
///     <see cref="ISeekable" /> allows seeking. <br />
///     A <see cref="Stream" /> will implement this interface if it is capable of seeking to a particular position.
/// </summary>
public interface ISeekable
{
    /// <summary>
    ///     Sets the position within the current stream to the specified value.
    /// </summary>
    /// <param name="offset">
    ///     The new position within the stream. This is relative to the loc parameter, and can be positive or
    ///     negative.
    /// </param>
    /// <param name="seekOrigin">A value of type SeekOrigin, which acts as the seek reference point</param>
    void Seek(int offset, SeekOrigin seekOrigin);
}