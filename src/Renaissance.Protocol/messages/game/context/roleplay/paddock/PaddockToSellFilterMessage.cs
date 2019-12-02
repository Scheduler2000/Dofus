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

namespace Renaissance.Protocol.messages.game.context.roleplay.paddock
{
	public class PaddockToSellFilterMessage : IDofusMessage
	{
		public  const int NetworkId = 6161;
		public  int ProtocolId { get { return NetworkId; } }

		public int AreaId { get; set; }

		public byte AtLeastNbMount { get; set; }

		public byte AtLeastNbMachine { get; set; }

		public CustomVar<long> MaxPrice { get; set; }

		public byte OrderBy { get; set; }


		public PaddockToSellFilterMessage() { }


		public PaddockToSellFilterMessage InitPaddockToSellFilterMessage(int _areaid, byte _atleastnbmount, byte _atleastnbmachine, CustomVar<long> _maxprice, byte _orderby)
		{

			this.AreaId = _areaid;
			this.AtLeastNbMount = _atleastnbmount;
			this.AtLeastNbMachine = _atleastnbmachine;
			this.MaxPrice = _maxprice;
			this.OrderBy = _orderby;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.AreaId);
			writer.Write(this.AtLeastNbMount);
			writer.Write(this.AtLeastNbMachine);
			writer.Write(this.MaxPrice);
			writer.Write(this.OrderBy);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.AreaId = reader.Read<int>();
			this.AtLeastNbMount = reader.Read<byte>();
			this.AtLeastNbMachine = reader.Read<byte>();
			this.MaxPrice = reader.Read<CustomVar<long>>();
			this.OrderBy = reader.Read<byte>();

		}


	}
}
