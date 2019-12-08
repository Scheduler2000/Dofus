//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:53.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.context.fight;

namespace Renaissance.Protocol.messages.game.context.fight.character
{
	public class GameFightShowFighterMessage : IDofusMessage
	{
		public  const int NetworkId = 5864;
		public  int ProtocolId { get { return NetworkId; } }

		public GameFightFighterInformations Informations { get; set; }


		public GameFightShowFighterMessage() { }


		public GameFightShowFighterMessage InitGameFightShowFighterMessage(GameFightFighterInformations _informations)
		{

			this.Informations = _informations;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += 2;
			var serialized1 = this.Informations.Serialize();
			size += serialized1.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData((short)(Informations.ProtocolId));
			writer.WriteDatas(serialized1);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			reader.Skip(2); // skip protocolManager.GetInstance(short)
			this.Informations = new GameFightFighterInformations();
			this.Informations.Deserialize(reader);

		}


	}
}
