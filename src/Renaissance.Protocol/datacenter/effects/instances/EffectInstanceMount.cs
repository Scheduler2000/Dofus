//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 27/12/2019 11:41:23.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    System.Collections.Generic;
using    Renaissance.Protocol.datacenter.geometry;
using    Renaissance.Protocol.datacenter.effects;

namespace Renaissance.Protocol.datacenter.effects.instances
{
	[Serializable]
	public class EffectInstanceMountData : EffectInstanceData
	{

		private double m_id;
		private double m_expirationDate;
		private uint m_model;
		private String m_name;
		private String m_owner;
		private uint m_level;
		private Boolean m_sex;
		private Boolean m_isRideable;
		private Boolean m_isFeconded;
		private Boolean m_isFecondationReady;
		private int m_reproductionCount;
		private uint m_reproductionCountMax;
		private List<EffectInstanceIntegerData> m_effects;
		private List<uint> m_capacities;

		public double Id
		{
			get => m_id;
			set => m_id = value;
		}

		public double ExpirationDate
		{
			get => m_expirationDate;
			set => m_expirationDate = value;
		}

		public uint Model
		{
			get => m_model;
			set => m_model = value;
		}

		public String Name
		{
			get => m_name;
			set => m_name = value;
		}

		public String Owner
		{
			get => m_owner;
			set => m_owner = value;
		}

		public uint Level
		{
			get => m_level;
			set => m_level = value;
		}

		public Boolean Sex
		{
			get => m_sex;
			set => m_sex = value;
		}

		public Boolean IsRideable
		{
			get => m_isRideable;
			set => m_isRideable = value;
		}

		public Boolean IsFeconded
		{
			get => m_isFeconded;
			set => m_isFeconded = value;
		}

		public Boolean IsFecondationReady
		{
			get => m_isFecondationReady;
			set => m_isFecondationReady = value;
		}

		public int ReproductionCount
		{
			get => m_reproductionCount;
			set => m_reproductionCount = value;
		}

		public uint ReproductionCountMax
		{
			get => m_reproductionCountMax;
			set => m_reproductionCountMax = value;
		}

		public List<EffectInstanceIntegerData> Effects
		{
			get => m_effects;
			set => m_effects = value;
		}

		public List<uint> Capacities
		{
			get => m_capacities;
			set => m_capacities = value;
		}


	}
}