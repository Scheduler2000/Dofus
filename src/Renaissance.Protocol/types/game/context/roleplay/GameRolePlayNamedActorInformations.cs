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
using    Renaissance.Protocol.types.game.context;
using    Renaissance.Protocol.types.game.look;

namespace Renaissance.Protocol.types.game.context.roleplay
{
	public class GameRolePlayNamedActorInformations : GameRolePlayActorInformations, IDofusType
	{
		public new const int NetworkId = 154;
		public new int ProtocolId { get { return NetworkId; } }

		public string Name { get; set; }


		public GameRolePlayNamedActorInformations() { }


		public GameRolePlayNamedActorInformations InitGameRolePlayNamedActorInformations(string _name)
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