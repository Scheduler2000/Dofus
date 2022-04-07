using System.Net;
using System.Net.Sockets;
using StumpR.Binary;
using StumpR.Binary.BigEndian;
using StumpR.Protocol.Messages;
using Version = StumpR.Protocol.Types.Version;

Socket client = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

using IDataWriter credantialsWriter = new BigEndianWriter();

var account = "Arcadia01";
var password = "azerty";

credantialsWriter.WriteUTF(account);
credantialsWriter.WriteUTF(password);

IdentificationMessage identificationMessage =
    new(false,
        false,
        false,
        new Version(2, 0x3d, 0xa, 0x11, 0),
        "fr",
        credantialsWriter.Buffer.Select(x => (sbyte) x),
        1,
        0,
        ArraySegment<ushort>.Empty);

await client.ConnectAsync(new IPEndPoint(IPAddress.Parse("188.93.233.244"), 411));

using var writer = new BigEndianWriter();
identificationMessage.Pack(writer);

await client.SendAsync(writer.Buffer, SocketFlags.None);

/*string dataBin =
    "00100011110100001010000000000000000000000000000100010000000000000000000000100110011001110010001100110000000000001001010000010111001001100011011000010110010001101001011000010011000000110001000000000000011001100001011110100110010101110010011101000111100110101100101010011100100101010010110001100010010001101001001001000011001110111101001000010111000001100011000010101111000100000010110000111001011111111111100101001001001010000011001100110100100001110111000110011111001010111100100000110000100000011111000111100000000000000000000000000000000000000000";

int numOfBytes = dataBin.Length / 8;
byte[] bytes = new byte[numOfBytes];
for(int i = 0; i < numOfBytes; ++i)
{
    bytes[i] = Convert.ToByte(dataBin.Substring(8 * i, 8), 2);
}

var reader = new BigEndianReader(bytes);

var identication = new IdentificationMessage();
identication.Deserialize(reader);*/


Console.WriteLine("Press any key to exit...");
Console.ReadKey(true);