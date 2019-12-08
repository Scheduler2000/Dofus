//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:58.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.house
{
	public class HouseInformationsInside : HouseInformations, IDofusType
	{
		public new const int NetworkId = 218;
		public new int ProtocolId { get { return NetworkId; } }

		public HouseInstanceInformations HouseInfos { get; set; }

		public short WorldX { get; set; }

		public short WorldY { get; set; }


		public HouseInformationsInside() { }


		public HouseInformationsInside InitHouseInformationsInside(CustomVar<int> _houseid, CustomVar<short> _modelid, HouseInstanceInformations _houseinfos, short _worldx, short _worldy)
		{

			base.HouseId = _houseid;
			base.ModelId = _modelid;
			this.HouseInfos = _houseinfos;
			this.WorldX = _worldx;
			this.WorldY = _worldy;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += 2;
			var serialized1 = this.HouseInfos.Serialize();
			size += serialized1.Length;
			size += DofusBinaryFactory.Sizing.SizeOf(WorldX);
			size += DofusBinaryFactory.Sizing.SizeOf(WorldY);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData((short)(HouseInfos.ProtocolId));
			writer.WriteDatas(serialized1);
			writer.WriteData(this.WorldX);
			writer.WriteData(this.WorldY);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			reader.Skip(2); // skip protocolManager.GetInstance(short)
			this.HouseInfos = new HouseInstanceInformations();
			this.HouseInfos.Deserialize(reader);
			this.WorldX = reader.Read<short>();
			this.WorldY = reader.Read<short>();

		}


	}
}
