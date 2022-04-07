using System.Text;

namespace StumpR.GUI.Sniffer.Network.Filter;

/// <summary>
///     Pcap filter builder
///     <remarks>see https://www.tcpdump.org/manpages/pcap-filter.7.html</remarks>
/// </summary>
public class PcapFilterBuilder
{
    private readonly StringBuilder _underlying;

    public PcapFilterBuilder()
    {
        _underlying = new StringBuilder();
    }

    public PcapFilterBuilder SetTcpIpOnly()
    {
        _underlying.Append("ip and tcp ");
        return this;
    }

    public PcapFilterBuilder AddHost(string host)
    {
        _underlying.Append($"host {host} ");
        return this;
    }

    public PcapFilterBuilder AddPort(string port)
    {
        _underlying.Append($"port {port} ");
        return this;
    }

    public PcapFilterBuilder AddSourceHost(string host)
    {
        _underlying.Append($"src host {host} ");
        return this;
    }

    public PcapFilterBuilder AddDestinationHost(string host)
    {
        _underlying.Append($"dst host {host} ");
        return this;
    }

    public PcapFilterBuilder AddSourcePort(string port)
    {
        _underlying.Append($"src port {port} ");
        return this;
    }

    public PcapFilterBuilder AddDestinationPort(string port)
    {
        _underlying.Append($"dst port {port} ");
        return this;
    }

    public PcapFilterBuilder And()
    {
        _underlying.Append("and ");
        return this;
    }

    public PcapFilterBuilder Or()
    {
        _underlying.Append("or ");
        return this;
    }

    public string Build()
    {
        return _underlying.ToString();
    }
}