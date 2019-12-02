//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:13.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.prism
{
	public class PrismInfoJoinLeaveRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 5844;
		public  int ProtocolId { get { return NetworkId; } }

		public bool Join { get; set; }


		public PrismInfoJoinLeaveRequestMessage() { }


		public PrismInfoJoinLeaveRequestMessage InitPrismInfoJoinLeaveRequestMessage(bool _join)
		{

			this.Join = _join;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Join);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Join = reader.Read<bool>();

		}


	}
}
