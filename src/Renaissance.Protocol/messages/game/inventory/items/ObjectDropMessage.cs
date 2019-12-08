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
	public class ObjectDropMessage : IDofusMessage
	{
		public  const int NetworkId = 3005;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<int> ObjectUID { get; set; }

		public CustomVar<int> Quantity { get; set; }


		public ObjectDropMessage() { }


		public ObjectDropMessage InitObjectDropMessage(CustomVar<int> _objectuid, CustomVar<int> _quantity)
		{

			this.ObjectUID = _objectuid;
			this.Quantity = _quantity;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(ObjectUID);
			size += DofusBinaryFactory.Sizing.SizeOf(Quantity);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.ObjectUID);
			writer.WriteData(this.Quantity);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.ObjectUID = reader.Read<CustomVar<int>>();
			this.Quantity = reader.Read<CustomVar<int>>();

		}


	}
}
