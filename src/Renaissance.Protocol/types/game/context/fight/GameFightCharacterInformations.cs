//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:30.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.character.alignment;
using    Renaissance.Protocol.types.game.character.status;
using    Renaissance.Protocol.types.game.context;
using    Renaissance.Protocol.types.game.look;

namespace Renaissance.Protocol.types.game.context.fight
{
	public class GameFightCharacterInformations : GameFightFighterNamedInformations, IDofusType
	{
		public new const int NetworkId = 46;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> Level { get; set; }

		public ActorAlignmentInformations AlignmentInfos { get; set; }

		public byte Breed { get; set; }

		public bool Sex { get; set; }


		public GameFightCharacterInformations() { }


		public GameFightCharacterInformations InitGameFightCharacterInformations(CustomVar<short> _level, ActorAlignmentInformations _alignmentinfos, byte _breed, bool _sex)
		{

			this.Level = _level;
			this.AlignmentInfos = _alignmentinfos;
			this.Breed = _breed;
			this.Sex = _sex;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.Level);
			writer.Write(this.AlignmentInfos.Serialize());
			writer.Write(this.Breed);
			writer.Write(this.Sex);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.Level = reader.Read<CustomVar<short>>();
			this.AlignmentInfos = new ActorAlignmentInformations();
			this.AlignmentInfos.Deserialize(reader);
			this.Breed = reader.Read<byte>();
			this.Sex = reader.Read<bool>();

		}


	}
}
