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

namespace Renaissance.Protocol.datacenter.misc
{
	[D2OClass("Subhint", "com.ankamagames.dofus.datacenter.misc")]
	public class SubhintData : IDataCenter
	{

		private int m_hint_id;
		private String m_hint_parent_uid;
		private String m_hint_anchored_element;
		private int m_hint_anchor;
		private int m_hint_position_x;
		private int m_hint_position_y;
		private int m_hint_width;
		private int m_hint_height;
		private String m_hint_highlighted_element;
		private int m_hint_order;
		private uint m_hint_tooltip_text;
		private int m_hint_tooltip_position_enum;
		private String m_hint_tooltip_url;
		private int m_hint_tooltip_offset_x;
		private int m_hint_tooltip_offset_y;
		private int m_hint_tooltip_width;
		private double m_hint_creation_date;

		public int Hint_id
		{
			get => m_hint_id;
			set => m_hint_id = value;
		}

		public String Hint_parent_uid
		{
			get => m_hint_parent_uid;
			set => m_hint_parent_uid = value;
		}

		public String Hint_anchored_element
		{
			get => m_hint_anchored_element;
			set => m_hint_anchored_element = value;
		}

		public int Hint_anchor
		{
			get => m_hint_anchor;
			set => m_hint_anchor = value;
		}

		public int Hint_position_x
		{
			get => m_hint_position_x;
			set => m_hint_position_x = value;
		}

		public int Hint_position_y
		{
			get => m_hint_position_y;
			set => m_hint_position_y = value;
		}

		public int Hint_width
		{
			get => m_hint_width;
			set => m_hint_width = value;
		}

		public int Hint_height
		{
			get => m_hint_height;
			set => m_hint_height = value;
		}

		public String Hint_highlighted_element
		{
			get => m_hint_highlighted_element;
			set => m_hint_highlighted_element = value;
		}

		public int Hint_order
		{
			get => m_hint_order;
			set => m_hint_order = value;
		}

		public uint Hint_tooltip_text
		{
			get => m_hint_tooltip_text;
			set => m_hint_tooltip_text = value;
		}

		public int Hint_tooltip_position_enum
		{
			get => m_hint_tooltip_position_enum;
			set => m_hint_tooltip_position_enum = value;
		}

		public String Hint_tooltip_url
		{
			get => m_hint_tooltip_url;
			set => m_hint_tooltip_url = value;
		}

		public int Hint_tooltip_offset_x
		{
			get => m_hint_tooltip_offset_x;
			set => m_hint_tooltip_offset_x = value;
		}

		public int Hint_tooltip_offset_y
		{
			get => m_hint_tooltip_offset_y;
			set => m_hint_tooltip_offset_y = value;
		}

		public int Hint_tooltip_width
		{
			get => m_hint_tooltip_width;
			set => m_hint_tooltip_width = value;
		}

		public double Hint_creation_date
		{
			get => m_hint_creation_date;
			set => m_hint_creation_date = value;
		}


	}
}