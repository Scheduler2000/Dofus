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

namespace Renaissance.Protocol.messages.game.approach
{
	public class ServerOptionalFeaturesMessage : IDofusMessage
	{
		public  const int NetworkId = 6305;
		public  int ProtocolId { get { return NetworkId; } }

		public byte[] Features { get; set; }


		public ServerOptionalFeaturesMessage() { }


		public ServerOptionalFeaturesMessage InitServerOptionalFeaturesMessage(byte[] _features)
		{

			this.Features = _features;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write((short)(this.Features.Length));
			foreach(var item in Features)
				writer.Write(item);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int Features_length = reader.Read<short>();
			this.Features = new byte[Features_length];
			for(int i = 0; i < Features_length; i++)
				this.Features[i] = reader.Read<byte>();

		}


	}
}
