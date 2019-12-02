//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:13.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.character;

namespace Renaissance.Protocol.messages.game.prism
{
	public class PrismFightAttackerAddMessage : IDofusMessage
	{
		public  const int NetworkId = 5893;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> SubAreaId { get; set; }

		public CustomVar<short> FightId { get; set; }

		public CharacterMinimalPlusLookInformations Attacker { get; set; }


		public PrismFightAttackerAddMessage() { }


		public PrismFightAttackerAddMessage InitPrismFightAttackerAddMessage(CustomVar<short> _subareaid, CustomVar<short> _fightid, CharacterMinimalPlusLookInformations _attacker)
		{

			this.SubAreaId = _subareaid;
			this.FightId = _fightid;
			this.Attacker = _attacker;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.SubAreaId);
			writer.Write(this.FightId);
			writer.Write((short)(Attacker.ProtocolId));
			writer.Write(this.Attacker.Serialize());

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.SubAreaId = reader.Read<CustomVar<short>>();
			this.FightId = reader.Read<CustomVar<short>>();
reader.Skip(2); // skip read short
			this.Attacker = new CharacterMinimalPlusLookInformations();
			this.Attacker.Deserialize(reader);

		}


	}
}
