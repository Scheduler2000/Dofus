//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:18.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.paddock;

namespace Renaissance.Protocol.messages.game.context.mount
{
	public class GameDataPaddockObjectListAddMessage : IDofusMessage
	{
		public  const int NetworkId = 5992;
		public  int ProtocolId { get { return NetworkId; } }

		public PaddockItem[] PaddockItemDescription { get; set; }


		public GameDataPaddockObjectListAddMessage() { }


		public GameDataPaddockObjectListAddMessage InitGameDataPaddockObjectListAddMessage(PaddockItem[] _paddockitemdescription)
		{

			this.PaddockItemDescription = _paddockitemdescription;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write((short)(this.PaddockItemDescription.Length));
			foreach(var obj in PaddockItemDescription)
			{
				writer.Write(obj.Serialize());
			}

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int PaddockItemDescription_length = reader.Read<short>();
			this.PaddockItemDescription = new PaddockItem[PaddockItemDescription_length];
			for(int i = 0; i < PaddockItemDescription_length; i++)
			{
				this.PaddockItemDescription[i] = new PaddockItem();
				this.PaddockItemDescription[i].Deserialize(reader);
			}

		}


	}
}
