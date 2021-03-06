//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:53.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.inventory.items
{
	public class ObjectDeletedMessage : IDofusMessage
	{
		public  const int NetworkId = 3024;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<int> ObjectUID { get; set; }


		public ObjectDeletedMessage() { }


		public ObjectDeletedMessage InitObjectDeletedMessage(CustomVar<int> _objectuid)
		{

			this.ObjectUID = _objectuid;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(ObjectUID);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.ObjectUID);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.ObjectUID = reader.Read<CustomVar<int>>();

		}


	}
}
