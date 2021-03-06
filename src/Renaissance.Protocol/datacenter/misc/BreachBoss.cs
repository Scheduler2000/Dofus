//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 27/12/2019 11:41:20.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    System.Collections.Generic;
using    Renaissance.Protocol.datacenter.geometry;

namespace Renaissance.Protocol.datacenter.misc
{
	[D2OClass("BreachBoss", "com.ankamagames.dofus.datacenter.misc")]
	public class BreachBossData : IDataCenter
	{

		private int m_id;
		private int m_monsterId;
		private int m_category;
		private String m_apparitionCriterion;
		private String m_accessCriterion;
		private int m_maxRewardQuantity;
		private List<int> m_incompatibleBosses;
		private uint m_rewardId;

		public int Id
		{
			get => m_id;
			set => m_id = value;
		}

		public int MonsterId
		{
			get => m_monsterId;
			set => m_monsterId = value;
		}

		public int Category
		{
			get => m_category;
			set => m_category = value;
		}

		public String ApparitionCriterion
		{
			get => m_apparitionCriterion;
			set => m_apparitionCriterion = value;
		}

		public String AccessCriterion
		{
			get => m_accessCriterion;
			set => m_accessCriterion = value;
		}

		public int MaxRewardQuantity
		{
			get => m_maxRewardQuantity;
			set => m_maxRewardQuantity = value;
		}

		public List<int> IncompatibleBosses
		{
			get => m_incompatibleBosses;
			set => m_incompatibleBosses = value;
		}

		public uint RewardId
		{
			get => m_rewardId;
			set => m_rewardId = value;
		}


	}
}
