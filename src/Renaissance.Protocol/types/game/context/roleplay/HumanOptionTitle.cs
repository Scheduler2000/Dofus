//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:51:01.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.context.roleplay
{
	public class HumanOptionTitle : HumanOption, IDofusType
	{
		public new const int NetworkId = 408;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> TitleId { get; set; }

		public string TitleParam { get; set; }


		public HumanOptionTitle() { }


		public HumanOptionTitle InitHumanOptionTitle(CustomVar<short> _titleid, string _titleparam)
		{

			this.TitleId = _titleid;
			this.TitleParam = _titleparam;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(TitleId);
			size += DofusBinaryFactory.Sizing.SizeOf(TitleParam);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData(this.TitleId);
			writer.WriteData(this.TitleParam);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.TitleId = reader.Read<CustomVar<short>>();
			this.TitleParam = reader.Read<string>();

		}


	}
}
