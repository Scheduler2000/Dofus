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
	public class CharacterNameSuggestionSuccessMessage : IDofusMessage
	{
		public  const int NetworkId = 5544;
		public  int ProtocolId { get { return NetworkId; } }

		public string Suggestion { get; set; }


		public CharacterNameSuggestionSuccessMessage() { }


		public CharacterNameSuggestionSuccessMessage InitCharacterNameSuggestionSuccessMessage(string _suggestion)
		{

			this.Suggestion = _suggestion;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Suggestion);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.Suggestion);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Suggestion = reader.Read<string>();

		}


	}
}
