//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:59.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.character.alignment
{
	public class ActorExtendedAlignmentInformations : ActorAlignmentInformations, IDofusType
	{
		public new const int NetworkId = 202;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> Honor { get; set; }

		public CustomVar<short> HonorGradeFloor { get; set; }

		public CustomVar<short> HonorNextGradeFloor { get; set; }

		public byte Aggressable { get; set; }


		public ActorExtendedAlignmentInformations() { }


		public ActorExtendedAlignmentInformations InitActorExtendedAlignmentInformations(byte _alignmentside, byte _alignmentvalue, byte _alignmentgrade, double _characterpower, CustomVar<short> _honor, CustomVar<short> _honorgradefloor, CustomVar<short> _honornextgradefloor, byte _aggressable)
		{

			base.AlignmentSide = _alignmentside;
			base.AlignmentValue = _alignmentvalue;
			base.AlignmentGrade = _alignmentgrade;
			base.CharacterPower = _characterpower;
			this.Honor = _honor;
			this.HonorGradeFloor = _honorgradefloor;
			this.HonorNextGradeFloor = _honornextgradefloor;
			this.Aggressable = _aggressable;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Honor);
			size += DofusBinaryFactory.Sizing.SizeOf(HonorGradeFloor);
			size += DofusBinaryFactory.Sizing.SizeOf(HonorNextGradeFloor);
			size += DofusBinaryFactory.Sizing.SizeOf(Aggressable);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData(this.Honor);
			writer.WriteData(this.HonorGradeFloor);
			writer.WriteData(this.HonorNextGradeFloor);
			writer.WriteData(this.Aggressable);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.Honor = reader.Read<CustomVar<short>>();
			this.HonorGradeFloor = reader.Read<CustomVar<short>>();
			this.HonorNextGradeFloor = reader.Read<CustomVar<short>>();
			this.Aggressable = reader.Read<byte>();

		}


	}
}
