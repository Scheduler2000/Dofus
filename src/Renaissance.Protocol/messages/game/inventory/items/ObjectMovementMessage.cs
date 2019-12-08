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
	public class ObjectMovementMessage : IDofusMessage
	{
		public  const int NetworkId = 3010;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<int> ObjectUID { get; set; }

		public short Position { get; set; }


		public ObjectMovementMessage() { }


		public ObjectMovementMessage InitObjectMovementMessage(CustomVar<int> _objectuid, short _position)
		{

			this.ObjectUID = _objectuid;
			this.Position = _position;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(ObjectUID);
			size += DofusBinaryFactory.Sizing.SizeOf(Position);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.ObjectUID);
			writer.WriteData(this.Position);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.ObjectUID = reader.Read<CustomVar<int>>();
			this.Position = reader.Read<short>();

		}


	}
}
