//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 27/12/2019 11:41:22.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    System.Collections.Generic;
using    Renaissance.Protocol.datacenter.geometry;

namespace Renaissance.Protocol.datacenter.world
{
	[D2OClass("Waypoint", "com.ankamagames.dofus.datacenter.world")]
	public class WaypointData : IDataCenter
	{

		private uint m_id;
		private double m_mapId;
		private uint m_subAreaId;
		private Boolean m_activated;

		public uint Id
		{
			get => m_id;
			set => m_id = value;
		}

		public double MapId
		{
			get => m_mapId;
			set => m_mapId = value;
		}

		public uint SubAreaId
		{
			get => m_subAreaId;
			set => m_subAreaId = value;
		}

		public Boolean Activated
		{
			get => m_activated;
			set => m_activated = value;
		}


	}
}