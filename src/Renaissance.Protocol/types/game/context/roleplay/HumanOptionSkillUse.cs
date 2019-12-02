//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:30.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.context.roleplay
{
	public class HumanOptionSkillUse : HumanOption, IDofusType
	{
		public new const int NetworkId = 495;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<int> ElementId { get; set; }

		public CustomVar<short> SkillId { get; set; }

		public double SkillEndTime { get; set; }


		public HumanOptionSkillUse() { }


		public HumanOptionSkillUse InitHumanOptionSkillUse(CustomVar<int> _elementid, CustomVar<short> _skillid, double _skillendtime)
		{

			this.ElementId = _elementid;
			this.SkillId = _skillid;
			this.SkillEndTime = _skillendtime;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.ElementId);
			writer.Write(this.SkillId);
			writer.Write(this.SkillEndTime);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.ElementId = reader.Read<CustomVar<int>>();
			this.SkillId = reader.Read<CustomVar<short>>();
			this.SkillEndTime = reader.Read<double>();

		}


	}
}