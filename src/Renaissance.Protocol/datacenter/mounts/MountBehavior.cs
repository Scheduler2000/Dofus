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
	[D2OClass("MountBehavior", "com.ankamagames.dofus.datacenter.mounts")]
	public class MountBehaviorData : IDataCenter
	{

		private uint m_id;
		private uint m_nameId;
		private uint m_descriptionId;

		public uint Id
		{
			get => m_id;
			set => m_id = value;
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


	}
}