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
using    Renaissance.Protocol.types.game.character.choice;
using    Renaissance.Protocol.types.game.character.choice;

namespace Renaissance.Protocol.messages.game.character.choice
{
	public class CharactersListWithRemodelingMessage : CharactersListMessage, IDofusMessage
	{
		public new const int NetworkId = 6550;
		public new int ProtocolId { get { return NetworkId; } }

		public CharacterToRemodelInformations[] CharactersToRemodel { get; set; }


		public CharactersListWithRemodelingMessage() { }


		public CharactersListWithRemodelingMessage InitCharactersListWithRemodelingMessage(bool _hasstartupactions, CharacterBaseInformations[] _characters, CharacterToRemodelInformations[] _characterstoremodel)
		{

			base.HasStartupActions = _hasstartupactions;
			base.Characters = _characters;
			this.CharactersToRemodel = _characterstoremodel;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.CharactersToRemodel.Length));
			var memory1 = new Memory<byte>[CharactersToRemodel.Length];
			for(int i = 0; i < CharactersToRemodel.Length; i++)
			{
				memory1[i] = this.CharactersToRemodel[i].Serialize();
				size += memory1[i].Length;
			}
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData((short)(this.CharactersToRemodel.Length));
			for(int i = 0; i < memory1.Length; i++)
			{
				writer.WriteDatas(memory1[i]);
			}

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			int CharactersToRemodel_length = reader.Read<short>();
			this.CharactersToRemodel = new CharacterToRemodelInformations[CharactersToRemodel_length];
			for(int i = 0; i < CharactersToRemodel_length; i++)
			{
				this.CharactersToRemodel[i] = new CharacterToRemodelInformations();
				this.CharactersToRemodel[i].Deserialize(reader);
			}

		}


	}
}
