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

namespace Renaissance.Protocol.datacenter.mounts
{
	[D2OClass("RideFood", "com.ankamagames.dofus.datacenter.mounts")]
	public class RideFoodData : IDataCenter
	{

		private uint m_gid;
		private uint m_typeId;
		private uint m_familyId;

		public uint Gid
		{
			get => m_gid;
			set => m_gid = value;
		}

		public uint TypeId
		{
			get => m_typeId;
			set => m_typeId = value;
		}

		public uint FamilyId
		{
			get => m_familyId;
			set => m_familyId = value;
		}


	}
}