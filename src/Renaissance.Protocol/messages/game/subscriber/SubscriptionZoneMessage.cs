//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:14.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.subscriber
{
	public class SubscriptionZoneMessage : IDofusMessage
	{
		public  const int NetworkId = 5573;
		public  int ProtocolId { get { return NetworkId; } }

		public bool Active { get; set; }


		public SubscriptionZoneMessage() { }


		public SubscriptionZoneMessage InitSubscriptionZoneMessage(bool _active)
		{

			this.Active = _active;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Active);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Active = reader.Read<bool>();

		}


	}
}
