//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:49.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
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

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.PaddockItemDescription.Length));
			var memory1 = new Memory<byte>[PaddockItemDescription.Length];
			for(int i = 0; i < PaddockItemDescription.Length; i++)
			{
				memory1[i] = this.PaddockItemDescription[i].Serialize();
				size += memory1[i].Length;
			}


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData((short)(this.PaddockItemDescription.Length));
			for(int i = 0; i < memory1.Length; i++)
			{
				writer.WriteDatas(memory1[i]);
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
