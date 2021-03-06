//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:57.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.roleplay.houses.guild
{
	public class HouseGuildRightsViewMessage : IDofusMessage
	{
		public  const int NetworkId = 5700;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<int> HouseId { get; set; }

		public int InstanceId { get; set; }


		public HouseGuildRightsViewMessage() { }


		public HouseGuildRightsViewMessage InitHouseGuildRightsViewMessage(CustomVar<int> _houseid, int _instanceid)
		{

			this.HouseId = _houseid;
			this.InstanceId = _instanceid;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(HouseId);
			size += DofusBinaryFactory.Sizing.SizeOf(InstanceId);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.HouseId);
			writer.WriteData(this.InstanceId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.HouseId = reader.Read<CustomVar<int>>();
			this.InstanceId = reader.Read<int>();

		}


	}
}
