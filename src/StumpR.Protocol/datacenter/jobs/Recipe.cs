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

public class Recipe
{

    public int ResultId { get; set; }

    public uint ResultNameId { get; set; }

    public uint ResultTypeId { get; set; }

    public uint ResultLevel { get; set; }

    public List<int> IngredientIds { get; set; }

    public List<uint> Quantities { get; set; }

    public int JobId { get; set; }

    public int SkillId { get; set; }

    public string ChangeVersion { get; set; }

    public double TooltipExpirationDate { get; set; }

}