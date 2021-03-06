//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 27/12/2019 11:41:21.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    System.Collections.Generic;
using    Renaissance.Protocol.datacenter.geometry;
using    Renaissance.Protocol.datacenter.npcs;

namespace Renaissance.Protocol.datacenter.quest
{
	[D2OClass("QuestStep", "com.ankamagames.dofus.datacenter.quest")]
	public class QuestStepData : IDataCenter
	{

		private uint m_id;
		private uint m_questId;
		private uint m_nameId;
		private uint m_descriptionId;
		private int m_dialogId;
		private uint m_optimalLevel;
		private double m_duration;
		private List<uint> m_objectiveIds;
		private List<uint> m_rewardsIds;

		public uint Id
		{
			get => m_id;
			set => m_id = value;
		}

		public uint QuestId
		{
			get => m_questId;
			set => m_questId = value;
		}

		public uint NameId
		{
			get => m_nameId;
			set => m_nameId = value;
		}

		public uint DescriptionId
		{
			get => m_descriptionId;
			set => m_descriptionId = value;
		}

		public int DialogId
		{
			get => m_dialogId;
			set => m_dialogId = value;
		}

		public uint OptimalLevel
		{
			get => m_optimalLevel;
			set => m_optimalLevel = value;
		}

		public double Duration
		{
			get => m_duration;
			set => m_duration = value;
		}

		public List<uint> ObjectiveIds
		{
			get => m_objectiveIds;
			set => m_objectiveIds = value;
		}

		public List<uint> RewardsIds
		{
			get => m_rewardsIds;
			set => m_rewardsIds = value;
		}


	}
}
