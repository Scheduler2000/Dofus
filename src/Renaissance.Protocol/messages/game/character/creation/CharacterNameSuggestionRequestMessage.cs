//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:48.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.character.creation
{
	public class CharacterNameSuggestionRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 162;
		public  int ProtocolId { get { return NetworkId; } }


		public CharacterNameSuggestionRequestMessage() { }


		public CharacterNameSuggestionRequestMessage InitCharacterNameSuggestionRequestMessage()
		{


			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;



			using DofusWriter writer = new DofusWriter(size);


			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{


		}


	}
}
