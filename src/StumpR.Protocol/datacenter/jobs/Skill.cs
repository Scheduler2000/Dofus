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

public class Skill
{

    public int Id { get; set; }

    public uint NameId { get; set; }

    public int ParentJobId { get; set; }

    public bool IsForgemagus { get; set; }

    public List<int> ModifiableItemTypeIds { get; set; }

    public int GatheredRessourceItem { get; set; }

    public List<int> CraftableItemIds { get; set; }

    public int InteractiveId { get; set; }

    public int Range { get; set; }

    public bool UseRangeInClient { get; set; }

    public string UseAnimation { get; set; }

    public int Cursor { get; set; }

    public int ElementActionId { get; set; }

    public bool AvailableInHouse { get; set; }

    public uint LevelMin { get; set; }

    public bool ClientDisplay { get; set; }

}