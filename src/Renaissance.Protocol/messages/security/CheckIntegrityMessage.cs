//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:07.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.security
{
	public class CheckIntegrityMessage : IDofusMessage
	{
		public  const int NetworkId = 6372;
		public  int ProtocolId { get { return NetworkId; } }

		public byte[] Data { get; set; }


		public CheckIntegrityMessage() { }


		public CheckIntegrityMessage InitCheckIntegrityMessage(byte[] _data)
		{

			this.Data = _data;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write((CustomVar<int>)(this.Data.Length));
			foreach(var item in Data)
				writer.Write(item);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int Data_length = reader.Read<CustomVar<int>>();
			this.Data = new byte[Data_length];
			for(int i = 0; i < Data_length; i++)
				this.Data[i] = reader.Read<byte>();

		}


	}
}
