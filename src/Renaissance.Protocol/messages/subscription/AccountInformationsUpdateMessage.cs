//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:07.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.subscription
{
	public class AccountInformationsUpdateMessage : IDofusMessage
	{
		public  const int NetworkId = 6740;
		public  int ProtocolId { get { return NetworkId; } }

		public double SubscriptionEndDate { get; set; }

		public double UnlimitedRestatEndDate { get; set; }


		public AccountInformationsUpdateMessage() { }


		public AccountInformationsUpdateMessage InitAccountInformationsUpdateMessage(double _subscriptionenddate, double _unlimitedrestatenddate)
		{

			this.SubscriptionEndDate = _subscriptionenddate;
			this.UnlimitedRestatEndDate = _unlimitedrestatenddate;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.SubscriptionEndDate);
			writer.Write(this.UnlimitedRestatEndDate);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.SubscriptionEndDate = reader.Read<double>();
			this.UnlimitedRestatEndDate = reader.Read<double>();

		}


	}
}