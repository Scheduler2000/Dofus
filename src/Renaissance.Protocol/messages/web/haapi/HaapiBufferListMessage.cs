//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:15.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.web.haapi;

namespace Renaissance.Protocol.messages.web.haapi
{
	public class HaapiBufferListMessage : IDofusMessage
	{
		public  const int NetworkId = 6845;
		public  int ProtocolId { get { return NetworkId; } }

		public BufferInformation[] Buffers { get; set; }


		public HaapiBufferListMessage() { }


		public HaapiBufferListMessage InitHaapiBufferListMessage(BufferInformation[] _buffers)
		{

			this.Buffers = _buffers;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write((short)(this.Buffers.Length));
			foreach(var obj in Buffers)
			{
				writer.Write(obj.Serialize());
			}

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int Buffers_length = reader.Read<short>();
			this.Buffers = new BufferInformation[Buffers_length];
			for(int i = 0; i < Buffers_length; i++)
			{
				this.Buffers[i] = new BufferInformation();
				this.Buffers[i].Deserialize(reader);
			}

		}


	}
}