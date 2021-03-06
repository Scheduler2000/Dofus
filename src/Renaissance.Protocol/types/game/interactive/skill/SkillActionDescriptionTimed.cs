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

namespace Renaissance.Protocol.types.game.interactive.skill
{
	public class SkillActionDescriptionTimed : SkillActionDescription, IDofusType
	{
		public new const int NetworkId = 103;
		public new int ProtocolId { get { return NetworkId; } }

		public byte Time { get; set; }


		public SkillActionDescriptionTimed() { }


		public SkillActionDescriptionTimed InitSkillActionDescriptionTimed(CustomVar<short> _skillid, byte _time)
		{

			base.SkillId = _skillid;
			this.Time = _time;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Time);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData(this.Time);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.Time = reader.Read<byte>();

		}


	}
}
