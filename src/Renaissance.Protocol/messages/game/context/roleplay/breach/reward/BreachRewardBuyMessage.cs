//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:26.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.roleplay.breach.reward
{
	public class BreachRewardBuyMessage : IDofusMessage
	{
		public  const int NetworkId = 6803;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<int> Id { get; set; }


		public BreachRewardBuyMessage() { }


		public BreachRewardBuyMessage InitBreachRewardBuyMessage(CustomVar<int> _id)
		{

			this.Id = _id;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Id);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Id = reader.Read<CustomVar<int>>();

		}


	}
}