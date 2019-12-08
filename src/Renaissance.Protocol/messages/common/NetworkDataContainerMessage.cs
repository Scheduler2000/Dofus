//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:41.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.common
{
	public class NetworkDataContainerMessage : IDofusMessage
	{
		public  const int NetworkId = 2;
		public  int ProtocolId { get { return NetworkId; } }

		public byte[] Content { get; set; }


		public NetworkDataContainerMessage() { }


		public NetworkDataContainerMessage InitNetworkDataContainerMessage(byte[] _content)
		{

			this.Content = _content;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Content);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.Content);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Content = reader.Read<byte[]>();

		}


	}
}
