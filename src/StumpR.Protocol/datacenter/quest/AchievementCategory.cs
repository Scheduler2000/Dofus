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

public class AchievementCategory
{

    public uint Id { get; set; }

    public uint NameId { get; set; }

    public uint ParentId { get; set; }

    public string Icon { get; set; }

    public uint Order { get; set; }

    public string Color { get; set; }

    public List<uint> AchievementIds { get; set; }

    public string VisibilityCriterion { get; set; }

}