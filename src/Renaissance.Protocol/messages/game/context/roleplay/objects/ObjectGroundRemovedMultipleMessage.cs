//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:25.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.roleplay.objects
{
	public class ObjectGroundRemovedMultipleMessage : IDofusMessage
	{
		public  const int NetworkId = 5944;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short>[] Cells { get; set; }


		public ObjectGroundRemovedMultipleMessage() { }


		public ObjectGroundRemovedMultipleMessage InitObjectGroundRemovedMultipleMessage(CustomVar<short>[] _cells)
		{

			this.Cells = _cells;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write((short)(this.Cells.Length));
			foreach(var item in Cells)
				writer.Write(item);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int Cells_length = reader.Read<short>();
			this.Cells = new CustomVar<short>[Cells_length];
			for(int i = 0; i < Cells_length; i++)
				this.Cells[i] = reader.Read<CustomVar<short>>();

		}


	}
}
