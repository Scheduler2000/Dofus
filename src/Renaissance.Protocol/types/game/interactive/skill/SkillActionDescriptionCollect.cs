//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:31.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.interactive.skill
{
	public class SkillActionDescriptionCollect : SkillActionDescriptionTimed, IDofusType
	{
		public new const int NetworkId = 99;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> Min { get; set; }

		public CustomVar<short> Max { get; set; }


		public SkillActionDescriptionCollect() { }


		public SkillActionDescriptionCollect InitSkillActionDescriptionCollect(CustomVar<short> _min, CustomVar<short> _max)
		{

			this.Min = _min;
			this.Max = _max;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.Min);
			writer.Write(this.Max);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.Min = reader.Read<CustomVar<short>>();
			this.Max = reader.Read<CustomVar<short>>();

		}


	}
}