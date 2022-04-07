namespace StumpR.GUI.Sniffer.Network.Frame.Architecture;

public class DofusPacket
{
    public DofusPacketMetadata Metadata { get; }
    
    public byte[] Payload { get; }


    public DofusPacket(DofusPacketMetadata metadata, byte[] payload)
    {
        Metadata = metadata;
        Payload = payload;
    }
}