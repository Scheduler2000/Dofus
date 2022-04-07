namespace StumpR.GUI.Sniffer.Network.Frame.Architecture;

public record DofusPacketMetadata(int MessageId, int LengthBytesCount, int PayloadLength, uint InstanceId);