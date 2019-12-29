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
using    Renaissance.Protocol.datacenter.effects;

namespace Renaissance.Protocol.datacenter.mounts
{
	[D2OClass("Mount", "com.ankamagames.dofus.datacenter.mounts")]
	public class MountData : IDataCenter
	{

		private uint m_id;
		private uint m_familyId;
		private uint m_nameId;
		private String m_look;
		private uint m_certificateId;
		private List<EffectInstanceData> m_effects;

		public uint Id
		{
			get => m_id;
			set => m_id = value;
		}

		public uint FamilyId
		{
			get => m_familyId;
			set => m_familyId = value;
		}

		public uint NameId
		{
			get => m_nameId;
			set => m_nameId = value;
		}

		public String Look
		{
			get => m_look;
			set => m_look = value;
		}

		public uint CertificateId
		{
			get => m_certificateId;
			set => m_certificateId = value;
		}

		public List<EffectInstanceData> Effects
		{
			get => m_effects;
			set => m_effects = value;
		}


	}
}
