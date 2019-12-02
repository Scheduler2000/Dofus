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

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Suggestion);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Suggestion = reader.Read<string>();

		}


	}
}
