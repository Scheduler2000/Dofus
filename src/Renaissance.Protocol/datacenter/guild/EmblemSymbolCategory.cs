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

namespace Renaissance.Protocol.datacenter.guild
{
	[D2OClass("EmblemSymbolCategory", "com.ankamagames.dofus.datacenter.guild")]
	public class EmblemSymbolCategoryData : IDataCenter
	{

		private int m_id;
		private uint m_nameId;

		public int Id
		{
			get => m_id;
			set => m_id = value;
		}

		public uint NameId
		{
			get => m_nameId;
			set => m_nameId = value;
		}


	}
}