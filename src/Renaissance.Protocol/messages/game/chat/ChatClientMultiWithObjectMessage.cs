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
using    Renaissance.Protocol.types.game.data.items;

namespace Renaissance.Protocol.messages.game.chat
{
	public class ChatClientMultiWithObjectMessage : ChatClientMultiMessage, IDofusMessage
	{
		public new const int NetworkId = 862;
		public new int ProtocolId { get { return NetworkId; } }

		public ObjectItem[] Objects { get; set; }


		public ChatClientMultiWithObjectMessage() { }


		public ChatClientMultiWithObjectMessage InitChatClientMultiWithObjectMessage(byte _channel, string _content, ObjectItem[] _objects)
		{

			base.Channel = _channel;
			base.Content = _content;
			this.Objects = _objects;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Objects.Length));
			var memory1 = new Memory<byte>[Objects.Length];
			for(int i = 0; i < Objects.Length; i++)
			{
				memory1[i] = this.Objects[i].Serialize();
				size += memory1[i].Length;
			}
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData((short)(this.Objects.Length));
			for(int i = 0; i < memory1.Length; i++)
			{
				writer.WriteDatas(memory1[i]);
			}

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			int Objects_length = reader.Read<short>();
			this.Objects = new ObjectItem[Objects_length];
			for(int i = 0; i < Objects_length; i++)
			{
				this.Objects[i] = new ObjectItem();
				this.Objects[i].Deserialize(reader);
			}

		}


	}
}
