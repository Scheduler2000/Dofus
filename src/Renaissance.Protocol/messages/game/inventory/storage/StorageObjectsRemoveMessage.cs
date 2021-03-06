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

namespace Renaissance.Protocol.messages.game.inventory.storage
{
	public class StorageObjectsRemoveMessage : IDofusMessage
	{
		public  const int NetworkId = 6035;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<int>[] ObjectUIDList { get; set; }


		public StorageObjectsRemoveMessage() { }


		public StorageObjectsRemoveMessage InitStorageObjectsRemoveMessage(CustomVar<int>[] _objectuidlist)
		{

			this.ObjectUIDList = _objectuidlist;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.ObjectUIDList.Length));
			size += DofusBinaryFactory.Sizing.SizeOf(ObjectUIDList);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData((short)(this.ObjectUIDList.Length));
			writer.WriteDatas(ObjectUIDList);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int ObjectUIDList_length = reader.Read<short>();
			this.ObjectUIDList = new CustomVar<int>[ObjectUIDList_length];
			for(int i = 0; i < ObjectUIDList_length; i++)
				this.ObjectUIDList[i] = reader.Read<CustomVar<int>>();

		}


	}
}
