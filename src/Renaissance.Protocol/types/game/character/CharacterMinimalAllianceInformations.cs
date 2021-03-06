//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:57.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.context.roleplay;
using    Renaissance.Protocol.types.game.context.roleplay;
using    Renaissance.Protocol.types.game.look;

namespace Renaissance.Protocol.types.game.character
{
	public class CharacterMinimalAllianceInformations : CharacterMinimalGuildInformations, IDofusType
	{
		public new const int NetworkId = 444;
		public new int ProtocolId { get { return NetworkId; } }

		public BasicAllianceInformations Alliance { get; set; }


		public CharacterMinimalAllianceInformations() { }


		public CharacterMinimalAllianceInformations InitCharacterMinimalAllianceInformations(BasicAllianceInformations _alliance)
		{

			this.Alliance = _alliance;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			var serialized1 = this.Alliance.Serialize();
			size += serialized1.Length;
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteDatas(serialized1);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.Alliance = new BasicAllianceInformations();
			this.Alliance.Deserialize(reader);

		}


	}
}
