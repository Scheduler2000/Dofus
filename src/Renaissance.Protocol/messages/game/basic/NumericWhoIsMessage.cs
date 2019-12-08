//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:43.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.basic
{
	public class NumericWhoIsMessage : IDofusMessage
	{
		public  const int NetworkId = 6297;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<long> PlayerId { get; set; }

		public int AccountId { get; set; }


		public NumericWhoIsMessage() { }


		public NumericWhoIsMessage InitNumericWhoIsMessage(CustomVar<long> _playerid, int _accountid)
		{

			this.PlayerId = _playerid;
			this.AccountId = _accountid;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(PlayerId);
			size += DofusBinaryFactory.Sizing.SizeOf(AccountId);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.PlayerId);
			writer.WriteData(this.AccountId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.PlayerId = reader.Read<CustomVar<long>>();
			this.AccountId = reader.Read<int>();

		}


	}
}
