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

namespace Renaissance.Protocol.datacenter.communication
{
	[D2OClass("CensoredWord", "com.ankamagames.dofus.datacenter.communication")]
	public class CensoredWordData : IDataCenter
	{

		private uint m_id;
		private uint m_listId;
		private String m_language;
		private String m_word;
		private Boolean m_deepLooking;

		public uint Id
		{
			get => m_id;
			set => m_id = value;
		}

		public uint ListId
		{
			get => m_listId;
			set => m_listId = value;
		}

		public String Language
		{
			get => m_language;
			set => m_language = value;
		}

		public String Word
		{
			get => m_word;
			set => m_word = value;
		}

		public Boolean DeepLooking
		{
			get => m_deepLooking;
			set => m_deepLooking = value;
		}


	}
}