//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:16.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.character.choice;

namespace Renaissance.Protocol.messages.game.character.choice
{
	public class BasicCharactersListMessage : IDofusMessage
	{
		public  const int NetworkId = 6475;
		public  int ProtocolId { get { return NetworkId; } }

		public CharacterBaseInformations[] Characters { get; set; }


		public BasicCharactersListMessage() { }


		public BasicCharactersListMessage InitBasicCharactersListMessage(CharacterBaseInformations[] _characters)
		{

			this.Characters = _characters;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write((short)(this.Characters.Length));
			foreach(var obj in Characters)
			{
				writer.Write((short)(obj.ProtocolId));
				writer.Write(obj.Serialize());
			}

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int Characters_length = reader.Read<short>();
			this.Characters = new CharacterBaseInformations[Characters_length];
			for(int i = 0; i < Characters_length; i++)
			{
reader.Skip(2); // skip read short for protocolManager.GetInstance(short)
				this.Characters[i] = new CharacterBaseInformations();
				this.Characters[i].Deserialize(reader);
			}

		}


	}
}