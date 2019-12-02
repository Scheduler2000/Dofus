//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:27.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.character
{
	public class CharacterBasicMinimalInformations : AbstractCharacterInformation, IDofusType
	{
		public new const int NetworkId = 503;
		public new int ProtocolId { get { return NetworkId; } }

		public string Name { get; set; }


		public CharacterBasicMinimalInformations() { }


		public CharacterBasicMinimalInformations InitCharacterBasicMinimalInformations(string _name)
		{

			this.Name = _name;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.Name);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.Name = reader.Read<string>();

		}


	}
}