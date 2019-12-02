//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:12.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.context.roleplay;

namespace Renaissance.Protocol.messages.game.guild
{
	public class GuildListMessage : IDofusMessage
	{
		public  const int NetworkId = 6413;
		public  int ProtocolId { get { return NetworkId; } }

		public GuildInformations[] Guilds { get; set; }


		public GuildListMessage() { }


		public GuildListMessage InitGuildListMessage(GuildInformations[] _guilds)
		{

			this.Guilds = _guilds;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write((short)(this.Guilds.Length));
			foreach(var obj in Guilds)
			{
				writer.Write(obj.Serialize());
			}

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int Guilds_length = reader.Read<short>();
			this.Guilds = new GuildInformations[Guilds_length];
			for(int i = 0; i < Guilds_length; i++)
			{
				this.Guilds[i] = new GuildInformations();
				this.Guilds[i].Deserialize(reader);
			}

		}


	}
}
