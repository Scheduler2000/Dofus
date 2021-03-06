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

namespace Renaissance.Protocol.types.game.idol
{
	public class Idol : IDofusType
	{
		public  const int NetworkId = 489;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> Id { get; set; }

		public CustomVar<short> XpBonusPercent { get; set; }

		public CustomVar<short> DropBonusPercent { get; set; }


		public Idol() { }


		public Idol InitIdol(CustomVar<short> _id, CustomVar<short> _xpbonuspercent, CustomVar<short> _dropbonuspercent)
		{

			this.Id = _id;
			this.XpBonusPercent = _xpbonuspercent;
			this.DropBonusPercent = _dropbonuspercent;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Id);
			size += DofusBinaryFactory.Sizing.SizeOf(XpBonusPercent);
			size += DofusBinaryFactory.Sizing.SizeOf(DropBonusPercent);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.Id);
			writer.WriteData(this.XpBonusPercent);
			writer.WriteData(this.DropBonusPercent);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Id = reader.Read<CustomVar<short>>();
			this.XpBonusPercent = reader.Read<CustomVar<short>>();
			this.DropBonusPercent = reader.Read<CustomVar<short>>();

		}


	}
}
