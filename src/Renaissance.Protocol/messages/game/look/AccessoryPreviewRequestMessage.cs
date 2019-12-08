//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:46.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
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

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.GenericId.Length));
			size += DofusBinaryFactory.Sizing.SizeOf(GenericId);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData((short)(this.GenericId.Length));
			writer.WriteDatas(GenericId);

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
