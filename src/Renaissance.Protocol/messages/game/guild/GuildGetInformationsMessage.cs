//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:11.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.guild
{
	public class GuildGetInformationsMessage : IDofusMessage
	{
		public  const int NetworkId = 5550;
		public  int ProtocolId { get { return NetworkId; } }

		public byte InfoType { get; set; }


		public GuildGetInformationsMessage() { }


		public GuildGetInformationsMessage InitGuildGetInformationsMessage(byte _infotype)
		{

			this.InfoType = _infotype;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.InfoType);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.InfoType = reader.Read<byte>();

		}


	}
}
