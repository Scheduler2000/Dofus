using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text.Json;
using System.Windows;
using PacketDotNet;
using SharpPcap;
using StumpR.GUI.Sniffer.Models;
using StumpR.GUI.Sniffer.Network.Filter;
using StumpR.GUI.Sniffer.Network.Frame;
using StumpR.GUI.Sniffer.Network.Frame.Architecture;
using StumpR.Protocol;

namespace StumpR.GUI.Sniffer.ViewModels;

public class SnifferViewModel : IDisposable
{
    private readonly Network.Sniffer _sniffer;
    private readonly DofusPacketBuilder _packetBuilder;
    private readonly JsonSerializerOptions _serializerOptions;
    private readonly List<byte> _buffer;

    public ObservableCollection<SniffedPacket> SniffedPackets { get; }

    public SnifferViewModel(ILiveDevice device)
    {
        string pcapFilter = new PcapFilterBuilder()
            .SetTcpIpOnly()
            .And()
            .AddHost("172.65.254.13") /* Julith Server */
            .Build();

        _sniffer = new Network.Sniffer(device, pcapFilter, DeviceModes.None);
        _packetBuilder = new DofusPacketBuilder();
        _serializerOptions = new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true};
        _buffer = new List<byte>();

        SniffedPackets = new ObservableCollection<SniffedPacket>();

        ProtocolTypeManager.Initialize();
        MessageReceiver.Initialize();


        _sniffer.OnPacketReceived += SnifferOnOnPacketReceived;

        _sniffer.StartCaptureAsync(default);
    }


    private void SnifferOnOnPacketReceived(Packet packet)
    {
        var ipPacket = (IPPacket) ((EthernetPacket) packet).PayloadPacket;

        Packet payloadPacket = ipPacket.PayloadPacket;

        byte[] data = payloadPacket.PayloadData;

        if (data.Length <= 0 && (data.Length != 1 || data[0] == 0x00)) return;

        bool isClient = Equals(ipPacket.SourceAddress, IPAddress.Parse(_sniffer.DeviceIp));

        _buffer.AddRange(data);

        while (_packetBuilder.TryBuild(_buffer, out DofusPacket dofusPacket, isClient))
        {
            Message msg = MessageReceiver.ComputeMessage(dofusPacket.Metadata.MessageId, dofusPacket.Payload);
            Type downcastType = msg.GetType();
            object downcast = Convert.ChangeType(msg, downcastType);

            SniffedPacket sniffedPacket = new(DateTime.Now.ToString("T"),
                isClient ? "Client" : "Server",
                dofusPacket.Metadata.MessageId,
                downcastType.Name,
                JsonSerializer.Serialize(downcast, _serializerOptions),
                BitConverter.ToString(dofusPacket.Payload));

            Application.Current.Dispatcher.InvokeAsync(() => SniffedPackets.Add(sniffedPacket));
        }
    }

    public void Dispose()
    {
        _sniffer.Dispose();
    }
}