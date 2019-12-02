//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:21.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.inventory.exchanges
{
	public class ExchangeStartOkMulticraftCrafterMessage : IDofusMessage
	{
		public  const int NetworkId = 5818;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<int> SkillId { get; set; }


		public ExchangeStartOkMulticraftCrafterMessage() { }


		public ExchangeStartOkMulticraftCrafterMessage InitExchangeStartOkMulticraftCrafterMessage(CustomVar<int> _skillid)
		{

			this.SkillId = _skillid;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.SkillId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.SkillId = reader.Read<CustomVar<int>>();

		}


	}
}
