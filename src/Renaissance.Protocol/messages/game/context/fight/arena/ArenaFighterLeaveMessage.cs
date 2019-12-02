//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:23.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.character;

namespace Renaissance.Protocol.messages.game.context.fight.arena
{
	public class ArenaFighterLeaveMessage : IDofusMessage
	{
		public  const int NetworkId = 6700;
		public  int ProtocolId { get { return NetworkId; } }

		public CharacterBasicMinimalInformations Leaver { get; set; }


		public ArenaFighterLeaveMessage() { }


		public ArenaFighterLeaveMessage InitArenaFighterLeaveMessage(CharacterBasicMinimalInformations _leaver)
		{

			this.Leaver = _leaver;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Leaver.Serialize());

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Leaver = new CharacterBasicMinimalInformations();
			this.Leaver.Deserialize(reader);

		}


	}
}
