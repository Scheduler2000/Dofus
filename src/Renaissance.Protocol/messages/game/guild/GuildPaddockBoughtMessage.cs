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
using    Renaissance.Protocol.types.game.paddock;

namespace Renaissance.Protocol.messages.game.guild
{
	public class GuildPaddockBoughtMessage : IDofusMessage
	{
		public  const int NetworkId = 5952;
		public  int ProtocolId { get { return NetworkId; } }

		public PaddockContentInformations PaddockInfo { get; set; }


		public GuildPaddockBoughtMessage() { }


		public GuildPaddockBoughtMessage InitGuildPaddockBoughtMessage(PaddockContentInformations _paddockinfo)
		{

			this.PaddockInfo = _paddockinfo;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.PaddockInfo.Serialize());

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.PaddockInfo = new PaddockContentInformations();
			this.PaddockInfo.Deserialize(reader);

		}


	}
}
