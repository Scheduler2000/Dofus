//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:13.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.look
{
	public class AccessoryPreviewRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 6518;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short>[] GenericId { get; set; }


		public AccessoryPreviewRequestMessage() { }


		public AccessoryPreviewRequestMessage InitAccessoryPreviewRequestMessage(CustomVar<short>[] _genericid)
		{

			this.GenericId = _genericid;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write((short)(this.GenericId.Length));
			foreach(var item in GenericId)
				writer.Write(item);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int GenericId_length = reader.Read<short>();
			this.GenericId = new CustomVar<short>[GenericId_length];
			for(int i = 0; i < GenericId_length; i++)
				this.GenericId[i] = reader.Read<CustomVar<short>>();

		}


	}
}
