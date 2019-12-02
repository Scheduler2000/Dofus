//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:23.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.roleplay.breach
{
	public class BreachBudgetMessage : IDofusMessage
	{
		public  const int NetworkId = 6786;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<int> Bugdet { get; set; }


		public BreachBudgetMessage() { }


		public BreachBudgetMessage InitBreachBudgetMessage(CustomVar<int> _bugdet)
		{

			this.Bugdet = _bugdet;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Bugdet);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Bugdet = reader.Read<CustomVar<int>>();

		}


	}
}