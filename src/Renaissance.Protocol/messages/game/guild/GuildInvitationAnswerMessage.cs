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
	public class GuildInvitationAnswerMessage : IDofusMessage
	{
		public  const int NetworkId = 5556;
		public  int ProtocolId { get { return NetworkId; } }

		public bool Accept { get; set; }


		public GuildInvitationAnswerMessage() { }


		public GuildInvitationAnswerMessage InitGuildInvitationAnswerMessage(bool _accept)
		{

			this.Accept = _accept;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Accept);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Accept = reader.Read<bool>();

		}


	}
}
