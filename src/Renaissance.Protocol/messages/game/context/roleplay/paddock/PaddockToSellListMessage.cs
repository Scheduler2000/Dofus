//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:55.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.paddock;

namespace Renaissance.Protocol.messages.game.context.roleplay.paddock
{
	public class PaddockToSellListMessage : IDofusMessage
	{
		public  const int NetworkId = 6138;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> PageIndex { get; set; }

		public CustomVar<short> TotalPage { get; set; }

		public PaddockInformationsForSell[] PaddockList { get; set; }


		public PaddockToSellListMessage() { }


		public PaddockToSellListMessage InitPaddockToSellListMessage(CustomVar<short> _pageindex, CustomVar<short> _totalpage, PaddockInformationsForSell[] _paddocklist)
		{

			this.PageIndex = _pageindex;
			this.TotalPage = _totalpage;
			this.PaddockList = _paddocklist;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(PageIndex);
			size += DofusBinaryFactory.Sizing.SizeOf(TotalPage);
			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.PaddockList.Length));
			var memory1 = new Memory<byte>[PaddockList.Length];
			for(int i = 0; i < PaddockList.Length; i++)
			{
				memory1[i] = this.PaddockList[i].Serialize();
				size += memory1[i].Length;
			}


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.PageIndex);
			writer.WriteData(this.TotalPage);
			writer.WriteData((short)(this.PaddockList.Length));
			for(int i = 0; i < memory1.Length; i++)
			{
				writer.WriteDatas(memory1[i]);
			}

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.PageIndex = reader.Read<CustomVar<short>>();
			this.TotalPage = reader.Read<CustomVar<short>>();
			int PaddockList_length = reader.Read<short>();
			this.PaddockList = new PaddockInformationsForSell[PaddockList_length];
			for(int i = 0; i < PaddockList_length; i++)
			{
				this.PaddockList[i] = new PaddockInformationsForSell();
				this.PaddockList[i].Deserialize(reader);
			}

		}


	}
}
