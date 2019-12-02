//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:09.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.chat
{
	public class ChatServerMessage : ChatAbstractServerMessage, IDofusMessage
	{
		public new const int NetworkId = 881;
		public new int ProtocolId { get { return NetworkId; } }

		public double SenderId { get; set; }

		public string SenderName { get; set; }

		public string Prefix { get; set; }

		public int SenderAccountId { get; set; }


		public ChatServerMessage() { }


		public ChatServerMessage InitChatServerMessage(double _senderid, string _sendername, string _prefix, int _senderaccountid)
		{

			this.SenderId = _senderid;
			this.SenderName = _sendername;
			this.Prefix = _prefix;
			this.SenderAccountId = _senderaccountid;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.SenderId);
			writer.Write(this.SenderName);
			writer.Write(this.Prefix);
			writer.Write(this.SenderAccountId);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.SenderId = reader.Read<double>();
			this.SenderName = reader.Read<string>();
			this.Prefix = reader.Read<string>();
			this.SenderAccountId = reader.Read<int>();

		}


	}
}