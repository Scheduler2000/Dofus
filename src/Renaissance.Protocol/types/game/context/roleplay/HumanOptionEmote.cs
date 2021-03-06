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
	public class HumanOptionEmote : HumanOption, IDofusType
	{
		public new const int NetworkId = 407;
		public new int ProtocolId { get { return NetworkId; } }

		public byte EmoteId { get; set; }

		public double EmoteStartTime { get; set; }


		public HumanOptionEmote() { }


		public HumanOptionEmote InitHumanOptionEmote(byte _emoteid, double _emotestarttime)
		{

			this.EmoteId = _emoteid;
			this.EmoteStartTime = _emotestarttime;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(EmoteId);
			size += DofusBinaryFactory.Sizing.SizeOf(EmoteStartTime);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData(this.EmoteId);
			writer.WriteData(this.EmoteStartTime);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.EmoteId = reader.Read<byte>();
			this.EmoteStartTime = reader.Read<double>();

		}


	}
}
