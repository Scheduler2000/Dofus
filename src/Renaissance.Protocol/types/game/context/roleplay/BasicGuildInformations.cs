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
using    Renaissance.Protocol.types.game.social;

namespace Renaissance.Protocol.types.game.context.roleplay
{
	public class BasicGuildInformations : AbstractSocialGroupInfos, IDofusType
	{
		public new const int NetworkId = 365;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<int> GuildId { get; set; }

		public string GuildName { get; set; }

		public byte GuildLevel { get; set; }


		public BasicGuildInformations() { }


		public BasicGuildInformations InitBasicGuildInformations(CustomVar<int> _guildid, string _guildname, byte _guildlevel)
		{

			this.GuildId = _guildid;
			this.GuildName = _guildname;
			this.GuildLevel = _guildlevel;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.GuildId);
			writer.Write(this.GuildName);
			writer.Write(this.GuildLevel);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.GuildId = reader.Read<CustomVar<int>>();
			this.GuildName = reader.Read<string>();
			this.GuildLevel = reader.Read<byte>();

		}


	}
}