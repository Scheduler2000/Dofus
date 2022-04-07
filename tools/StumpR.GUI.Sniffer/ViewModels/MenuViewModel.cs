using System.Collections.Generic;
using System.Linq;
using SharpPcap;
using StumpR.GUI.Sniffer.Models;

namespace StumpR.GUI.Sniffer.ViewModels;

public class MenuViewModel
{
    public List<Device> Devices { get; }

    public MenuViewModel()
    {
        Devices = new List<Device>();

        var devices = CaptureDeviceList.Instance;

        for (var i = 0; i < devices.Count; i++) Devices.Add(new Device(i + 1, devices[i].Name, devices[i].Description));
    }

    public ILiveDevice GetLiveDevice(Device device)
    {
        return CaptureDeviceList.Instance.FirstOrDefault(x => x.Name == device.Name);
    }

}