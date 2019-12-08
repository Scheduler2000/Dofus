//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:43.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
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


		public ChatServerMessage InitChatServerMessage(byte _channel, string _content, int _timestamp, string _fingerprint, double _senderid, string _sendername, string _prefix, int _senderaccountid)
		{

			base.Channel = _channel;
			base.Content = _content;
			base.Timestamp = _timestamp;
			base.Fingerprint = _fingerprint;
			this.SenderId = _senderid;
			this.SenderName = _sendername;
			this.Prefix = _prefix;
			this.SenderAccountId = _senderaccountid;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(SenderId);
			size += DofusBinaryFactory.Sizing.SizeOf(SenderName);
			size += DofusBinaryFactory.Sizing.SizeOf(Prefix);
			size += DofusBinaryFactory.Sizing.SizeOf(SenderAccountId);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData(this.SenderId);
			writer.WriteData(this.SenderName);
			writer.WriteData(this.Prefix);
			writer.WriteData(this.SenderAccountId);

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
