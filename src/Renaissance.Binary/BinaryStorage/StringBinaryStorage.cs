using System;
using System.Text;
using Astron.Binary.Reader;
using Astron.Binary.Storage;
using Astron.Binary.Writer;

namespace Renaissance.Binary.BinaryStorage
{

    internal class StringBinaryStorage : IBinaryStorage<string>
    {
        public Func<IReader, string> ReadValue => (reader) =>
        {
            var len = reader.ReadValue<short>();
            return Encoding.UTF8.GetString(reader.ReadValues<byte>(len));
        };

        public Action<IWriter, string> WriteValue => (writer, str) =>
        {
            byte[] data = Encoding.UTF8.GetBytes(str);
            short len = (short)data.Length;

            writer.WriteValue(len);
            writer.WriteBytes(data);
        };

    }
}
