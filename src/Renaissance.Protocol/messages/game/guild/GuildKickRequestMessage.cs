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

namespace Renaissance.Protocol.messages.game.guild
{
	public class GuildKickRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 5887;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<long> KickedId { get; set; }


		public GuildKickRequestMessage() { }


		public GuildKickRequestMessage InitGuildKickRequestMessage(CustomVar<long> _kickedid)
		{

			this.KickedId = _kickedid;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.KickedId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.KickedId = reader.Read<CustomVar<long>>();

		}


	}
}
