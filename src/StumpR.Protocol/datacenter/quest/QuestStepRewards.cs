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

public class QuestStepRewards
{

    public uint Id { get; set; }

    public uint StepId { get; set; }

    public int LevelMin { get; set; }

    public int LevelMax { get; set; }

    public double KamasRatio { get; set; }

    public double ExperienceRatio { get; set; }

    public bool KamasScaleWithPlayerLevel { get; set; }

    public List<List<uint>> ItemsReward { get; set; }

    public List<uint> EmotesReward { get; set; }

    public List<uint> JobsReward { get; set; }

    public List<uint> SpellsReward { get; set; }

    public List<uint> TitlesReward { get; set; }

}