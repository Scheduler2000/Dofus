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

namespace Renaissance.Protocol.datacenter.items
{
	[D2OClass("Incarnation", "com.ankamagames.dofus.datacenter.items")]
	public class IncarnationData : IDataCenter
	{

		private uint m_id;
		private String m_lookMale;
		private String m_lookFemale;

		public uint Id
		{
			get => m_id;
			set => m_id = value;
		}

		public String LookMale
		{
			get => m_lookMale;
			set => m_lookMale = value;
		}

		public String LookFemale
		{
			get => m_lookFemale;
			set => m_lookFemale = value;
		}


	}
}
