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
            var len = reader.ReadValue<ushort>();
            var data = reader.ReadValues<byte>(len);
            return Encoding.UTF8.GetString(data);
        };

        public Action<IWriter, string> WriteValue => (writer, str) =>
        {
            byte[] data = Encoding.UTF8.GetBytes(str);
            ushort len = (ushort)data.Length;

            writer.WriteValue(len);
            writer.WriteBytes(data);
        };

    }
}
