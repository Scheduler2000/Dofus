//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:54.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.house;

namespace Renaissance.Protocol.messages.game.context.roleplay.houses
{
	public class HouseToSellListMessage : IDofusMessage
	{
		public  const int NetworkId = 6140;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> PageIndex { get; set; }

		public CustomVar<short> TotalPage { get; set; }

		public HouseInformationsForSell[] HouseList { get; set; }


		public HouseToSellListMessage() { }


		public HouseToSellListMessage InitHouseToSellListMessage(CustomVar<short> _pageindex, CustomVar<short> _totalpage, HouseInformationsForSell[] _houselist)
		{

			this.PageIndex = _pageindex;
			this.TotalPage = _totalpage;
			this.HouseList = _houselist;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(PageIndex);
			size += DofusBinaryFactory.Sizing.SizeOf(TotalPage);
			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.HouseList.Length));
			var memory1 = new Memory<byte>[HouseList.Length];
			for(int i = 0; i < HouseList.Length; i++)
			{
				memory1[i] = this.HouseList[i].Serialize();
				size += memory1[i].Length;
			}


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.PageIndex);
			writer.WriteData(this.TotalPage);
			writer.WriteData((short)(this.HouseList.Length));
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
			int HouseList_length = reader.Read<short>();
			this.HouseList = new HouseInformationsForSell[HouseList_length];
			for(int i = 0; i < HouseList_length; i++)
			{
				this.HouseList[i] = new HouseInformationsForSell();
				this.HouseList[i].Deserialize(reader);
			}

		}


	}
}
