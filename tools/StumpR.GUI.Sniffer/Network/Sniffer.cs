using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PacketDotNet;
using SharpPcap;
using SharpPcap.LibPcap;

namespace StumpR.GUI.Sniffer.Network;

public class Sniffer : IDisposable
{
    private readonly ILiveDevice _device;

    public event Action<Packet> OnPacketReceived;

    public string DeviceIp => (_device as LibPcapLiveDevice)?.Addresses.First().Addr.ToString();

    public Sniffer(ILiveDevice device, string filter, DeviceModes mode)
    {
        _device = device;

        _device.Open(mode);
        _device.Filter = filter;
    }

    public Sniffer(ILiveDevice device, string filter) : this(device, filter, DeviceModes.None)
    {
    }

    public Sniffer(ILiveDevice device)
        : this(device, string.Empty, DeviceModes.None)
    {
    }

    public Task StartCaptureAsync(CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            while (cancellationToken == default || !cancellationToken.IsCancellationRequested)
            {
                GetPacketStatus status = _device.GetNextPacket(out PacketCapture capture);

                if (status != GetPacketStatus.PacketRead) continue;

                RawCapture raw = capture.GetPacket();
                var packet = Packet.ParsePacket(raw.LinkLayerType, raw.Data);

                OnPacketReceived?.Invoke(packet);
            }
        }, cancellationToken);
    }

    public void Dispose()
    {
        _device.StopCapture();
        _device.Close();
    }
}