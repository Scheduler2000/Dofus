//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 2/19/2022 5:49:39 PM.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------


using System;
using System.Drawing;
using System.Collections.Generic;

namespace StumpR.Protocol.Datacenter;

public class PopupInformation
{

    public int Id { get; set; }

    public uint ParentId { get; set; }

    public uint TitleId { get; set; }

    public uint DescriptionId { get; set; }

    public string IlluName { get; set; }

    public List<PopupButton> Buttons { get; set; }

    public string Criterion { get; set; }

    public uint CacheType { get; set; }

    public bool AutoTrigger { get; set; }

}