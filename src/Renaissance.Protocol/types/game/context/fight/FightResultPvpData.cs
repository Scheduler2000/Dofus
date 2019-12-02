//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:29.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.context.fight
{
	public class FightResultPvpData : FightResultAdditionalData, IDofusType
	{
		public new const int NetworkId = 190;
		public new int ProtocolId { get { return NetworkId; } }

		public byte Grade { get; set; }

		public CustomVar<short> MinHonorForGrade { get; set; }

		public CustomVar<short> MaxHonorForGrade { get; set; }

		public CustomVar<short> Honor { get; set; }

		public CustomVar<short> HonorDelta { get; set; }


		public FightResultPvpData() { }


		public FightResultPvpData InitFightResultPvpData(byte _grade, CustomVar<short> _minhonorforgrade, CustomVar<short> _maxhonorforgrade, CustomVar<short> _honor, CustomVar<short> _honordelta)
		{

			this.Grade = _grade;
			this.MinHonorForGrade = _minhonorforgrade;
			this.MaxHonorForGrade = _maxhonorforgrade;
			this.Honor = _honor;
			this.HonorDelta = _honordelta;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.Grade);
			writer.Write(this.MinHonorForGrade);
			writer.Write(this.MaxHonorForGrade);
			writer.Write(this.Honor);
			writer.Write(this.HonorDelta);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.Grade = reader.Read<byte>();
			this.MinHonorForGrade = reader.Read<CustomVar<short>>();
			this.MaxHonorForGrade = reader.Read<CustomVar<short>>();
			this.Honor = reader.Read<CustomVar<short>>();
			this.HonorDelta = reader.Read<CustomVar<short>>();

		}


	}
}
