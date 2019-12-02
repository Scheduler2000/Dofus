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

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.PageIndex);
			writer.Write(this.TotalPage);
			writer.Write((short)(this.PaddockList.Length));
			foreach(var obj in PaddockList)
			{
				writer.Write(obj.Serialize());
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
