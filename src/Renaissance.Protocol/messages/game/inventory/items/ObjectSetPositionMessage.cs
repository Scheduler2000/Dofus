//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:22.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.inventory.items
{
	public class ObjectSetPositionMessage : IDofusMessage
	{
		public  const int NetworkId = 3021;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<int> ObjectUID { get; set; }

		public short Position { get; set; }

		public CustomVar<int> Quantity { get; set; }


		public ObjectSetPositionMessage() { }


		public ObjectSetPositionMessage InitObjectSetPositionMessage(CustomVar<int> _objectuid, short _position, CustomVar<int> _quantity)
		{

			this.ObjectUID = _objectuid;
			this.Position = _position;
			this.Quantity = _quantity;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.ObjectUID);
			writer.Write(this.Position);
			writer.Write(this.Quantity);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.ObjectUID = reader.Read<CustomVar<int>>();
			this.Position = reader.Read<short>();
			this.Quantity = reader.Read<CustomVar<int>>();

		}


	}
}