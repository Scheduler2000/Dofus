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
	public class ChatServerCopyMessage : ChatAbstractServerMessage, IDofusMessage
	{
		public new const int NetworkId = 882;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<long> ReceiverId { get; set; }

		public string ReceiverName { get; set; }


		public ChatServerCopyMessage() { }


		public ChatServerCopyMessage InitChatServerCopyMessage(byte _channel, string _content, int _timestamp, string _fingerprint, CustomVar<long> _receiverid, string _receivername)
		{

			base.Channel = _channel;
			base.Content = _content;
			base.Timestamp = _timestamp;
			base.Fingerprint = _fingerprint;
			this.ReceiverId = _receiverid;
			this.ReceiverName = _receivername;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(ReceiverId);
			size += DofusBinaryFactory.Sizing.SizeOf(ReceiverName);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData(this.ReceiverId);
			writer.WriteData(this.ReceiverName);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.ReceiverId = reader.Read<CustomVar<long>>();
			this.ReceiverName = reader.Read<string>();

		}


	}
}
