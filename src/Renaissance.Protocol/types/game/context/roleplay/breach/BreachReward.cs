//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:31.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.context.roleplay.breach
{
	public class BreachReward : IDofusType
	{
		public  const int NetworkId = 559;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<int> Id { get; set; }

		public byte[] BuyLocks { get; set; }

		public string BuyCriterion { get; set; }

		public bool Bought { get; set; }

		public CustomVar<int> Price { get; set; }


		public BreachReward() { }


		public BreachReward InitBreachReward(CustomVar<int> _id, byte[] _buylocks, string _buycriterion, bool _bought, CustomVar<int> _price)
		{

			this.Id = _id;
			this.BuyLocks = _buylocks;
			this.BuyCriterion = _buycriterion;
			this.Bought = _bought;
			this.Price = _price;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Id);
			writer.Write((short)(this.BuyLocks.Length));
			foreach(var item in BuyLocks)
				writer.Write(item);
			writer.Write(this.BuyCriterion);
			writer.Write(this.Bought);
			writer.Write(this.Price);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Id = reader.Read<CustomVar<int>>();
			int BuyLocks_length = reader.Read<short>();
			this.BuyLocks = new byte[BuyLocks_length];
			for(int i = 0; i < BuyLocks_length; i++)
				this.BuyLocks[i] = reader.Read<byte>();
			this.BuyCriterion = reader.Read<string>();
			this.Bought = reader.Read<bool>();
			this.Price = reader.Read<CustomVar<int>>();

		}


	}
}
