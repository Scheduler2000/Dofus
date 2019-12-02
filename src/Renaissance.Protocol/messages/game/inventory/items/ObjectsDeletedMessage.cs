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
	public class ObjectsDeletedMessage : IDofusMessage
	{
		public  const int NetworkId = 6034;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<int>[] ObjectUID { get; set; }


		public ObjectsDeletedMessage() { }


		public ObjectsDeletedMessage InitObjectsDeletedMessage(CustomVar<int>[] _objectuid)
		{

			this.ObjectUID = _objectuid;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write((short)(this.ObjectUID.Length));
			foreach(var item in ObjectUID)
				writer.Write(item);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int ObjectUID_length = reader.Read<short>();
			this.ObjectUID = new CustomVar<int>[ObjectUID_length];
			for(int i = 0; i < ObjectUID_length; i++)
				this.ObjectUID[i] = reader.Read<CustomVar<int>>();

		}


	}
}