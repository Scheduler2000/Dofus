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

public class MapPosition
{

    public double Id { get; set; }

    public int PosX { get; set; }

    public int PosY { get; set; }

    public bool Outdoor { get; set; }

    public int Capabilities { get; set; }

    public int NameId { get; set; }

    public bool ShowNameOnFingerpost { get; set; }

    public List<List<int>> Playlists { get; set; }

    public int SubAreaId { get; set; }

    public int WorldMap { get; set; }

    public bool HasPriorityOnWorldmap { get; set; }

    public bool AllowPrism { get; set; }

    public bool IsTransition { get; set; }

    public bool MapHasTemplate { get; set; }

    public uint TacticalModeTemplateId { get; set; }

    public bool HasPublicPaddock { get; set; }

}