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

namespace Renaissance.Protocol.types.game.paddock
{
	public class PaddockInformationsForSell : IDofusType
	{
		public  const int NetworkId = 222;
		public  int ProtocolId { get { return NetworkId; } }

		public string GuildOwner { get; set; }

		public short WorldX { get; set; }

		public short WorldY { get; set; }

		public CustomVar<short> SubAreaId { get; set; }

		public byte NbMount { get; set; }

		public byte NbObject { get; set; }

		public CustomVar<long> Price { get; set; }


		public PaddockInformationsForSell() { }


		public PaddockInformationsForSell InitPaddockInformationsForSell(string _guildowner, short _worldx, short _worldy, CustomVar<short> _subareaid, byte _nbmount, byte _nbobject, CustomVar<long> _price)
		{

			this.GuildOwner = _guildowner;
			this.WorldX = _worldx;
			this.WorldY = _worldy;
			this.SubAreaId = _subareaid;
			this.NbMount = _nbmount;
			this.NbObject = _nbobject;
			this.Price = _price;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(GuildOwner);
			size += DofusBinaryFactory.Sizing.SizeOf(WorldX);
			size += DofusBinaryFactory.Sizing.SizeOf(WorldY);
			size += DofusBinaryFactory.Sizing.SizeOf(SubAreaId);
			size += DofusBinaryFactory.Sizing.SizeOf(NbMount);
			size += DofusBinaryFactory.Sizing.SizeOf(NbObject);
			size += DofusBinaryFactory.Sizing.SizeOf(Price);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.GuildOwner);
			writer.WriteData(this.WorldX);
			writer.WriteData(this.WorldY);
			writer.WriteData(this.SubAreaId);
			writer.WriteData(this.NbMount);
			writer.WriteData(this.NbObject);
			writer.WriteData(this.Price);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.GuildOwner = reader.Read<string>();
			this.WorldX = reader.Read<short>();
			this.WorldY = reader.Read<short>();
			this.SubAreaId = reader.Read<CustomVar<short>>();
			this.NbMount = reader.Read<byte>();
			this.NbObject = reader.Read<byte>();
			this.Price = reader.Read<CustomVar<long>>();

		}


	}
}
