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
	public class HumanOptionAlliance : HumanOption, IDofusType
	{
		public new const int NetworkId = 425;
		public new int ProtocolId { get { return NetworkId; } }

		public AllianceInformations AllianceInformations { get; set; }

		public byte Aggressable { get; set; }


		public HumanOptionAlliance() { }


		public HumanOptionAlliance InitHumanOptionAlliance(AllianceInformations _allianceinformations, byte _aggressable)
		{

			this.AllianceInformations = _allianceinformations;
			this.Aggressable = _aggressable;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			var serialized1 = this.AllianceInformations.Serialize();
			size += serialized1.Length;
			size += DofusBinaryFactory.Sizing.SizeOf(Aggressable);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteDatas(serialized1);
			writer.WriteData(this.Aggressable);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.AllianceInformations = new AllianceInformations();
			this.AllianceInformations.Deserialize(reader);
			this.Aggressable = reader.Read<byte>();

		}


	}
}
