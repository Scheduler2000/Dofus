//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:51:01.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.context.roleplay.job
{
	public class DecraftedItemStackInfo : IDofusType
	{
		public  const int NetworkId = 481;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<int> ObjectUID { get; set; }

		public float BonusMin { get; set; }

		public float BonusMax { get; set; }

		public CustomVar<short>[] RunesId { get; set; }

		public CustomVar<int>[] RunesQty { get; set; }


		public DecraftedItemStackInfo() { }


		public DecraftedItemStackInfo InitDecraftedItemStackInfo(CustomVar<int> _objectuid, float _bonusmin, float _bonusmax, CustomVar<short>[] _runesid, CustomVar<int>[] _runesqty)
		{

			this.ObjectUID = _objectuid;
			this.BonusMin = _bonusmin;
			this.BonusMax = _bonusmax;
			this.RunesId = _runesid;
			this.RunesQty = _runesqty;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(ObjectUID);
			size += DofusBinaryFactory.Sizing.SizeOf(BonusMin);
			size += DofusBinaryFactory.Sizing.SizeOf(BonusMax);
			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.RunesId.Length));
			size += DofusBinaryFactory.Sizing.SizeOf(RunesId);
			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.RunesQty.Length));
			size += DofusBinaryFactory.Sizing.SizeOf(RunesQty);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.ObjectUID);
			writer.WriteData(this.BonusMin);
			writer.WriteData(this.BonusMax);
			writer.WriteData((short)(this.RunesId.Length));
			writer.WriteDatas(RunesId);
			writer.WriteData((short)(this.RunesQty.Length));
			writer.WriteDatas(RunesQty);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.ObjectUID = reader.Read<CustomVar<int>>();
			this.BonusMin = reader.Read<float>();
			this.BonusMax = reader.Read<float>();
			int RunesId_length = reader.Read<short>();
			this.RunesId = new CustomVar<short>[RunesId_length];
			for(int i = 0; i < RunesId_length; i++)
				this.RunesId[i] = reader.Read<CustomVar<short>>();
			int RunesQty_length = reader.Read<short>();
			this.RunesQty = new CustomVar<int>[RunesQty_length];
			for(int i = 0; i < RunesQty_length; i++)
				this.RunesQty[i] = reader.Read<CustomVar<int>>();

		}


	}
}
