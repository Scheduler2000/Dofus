//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 27/12/2019 11:41:19.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    System.Collections.Generic;
using    Renaissance.Protocol.datacenter.geometry;

namespace Renaissance.Protocol.datacenter.appearance
{
	[D2OClass("SkinMapping", "com.ankamagames.dofus.datacenter.appearance")]
	public class SkinMappingData : IDataCenter
	{

		private int m_id;
		private int m_lowDefId;

		public int Id
		{
			get => m_id;
			set => m_id = value;
		}

		public int LowDefId
		{
			get => m_lowDefId;
			set => m_lowDefId = value;
		}


	}
}
