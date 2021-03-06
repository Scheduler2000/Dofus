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

namespace Renaissance.Protocol.types.game.data.items
{
	public class SellerBuyerDescriptor : IDofusType
	{
		public  const int NetworkId = 121;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<int>[] Quantities { get; set; }

		public CustomVar<int>[] Types { get; set; }

		public float TaxPercentage { get; set; }

		public float TaxModificationPercentage { get; set; }

		public byte MaxItemLevel { get; set; }

		public CustomVar<int> MaxItemPerAccount { get; set; }

		public int NpcContextualId { get; set; }

		public CustomVar<short> UnsoldDelay { get; set; }


		public SellerBuyerDescriptor() { }


		public SellerBuyerDescriptor InitSellerBuyerDescriptor(CustomVar<int>[] _quantities, CustomVar<int>[] _types, float _taxpercentage, float _taxmodificationpercentage, byte _maxitemlevel, CustomVar<int> _maxitemperaccount, int _npccontextualid, CustomVar<short> _unsolddelay)
		{

			this.Quantities = _quantities;
			this.Types = _types;
			this.TaxPercentage = _taxpercentage;
			this.TaxModificationPercentage = _taxmodificationpercentage;
			this.MaxItemLevel = _maxitemlevel;
			this.MaxItemPerAccount = _maxitemperaccount;
			this.NpcContextualId = _npccontextualid;
			this.UnsoldDelay = _unsolddelay;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Quantities.Length));
			size += DofusBinaryFactory.Sizing.SizeOf(Quantities);
			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Types.Length));
			size += DofusBinaryFactory.Sizing.SizeOf(Types);
			size += DofusBinaryFactory.Sizing.SizeOf(TaxPercentage);
			size += DofusBinaryFactory.Sizing.SizeOf(TaxModificationPercentage);
			size += DofusBinaryFactory.Sizing.SizeOf(MaxItemLevel);
			size += DofusBinaryFactory.Sizing.SizeOf(MaxItemPerAccount);
			size += DofusBinaryFactory.Sizing.SizeOf(NpcContextualId);
			size += DofusBinaryFactory.Sizing.SizeOf(UnsoldDelay);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData((short)(this.Quantities.Length));
			writer.WriteDatas(Quantities);
			writer.WriteData((short)(this.Types.Length));
			writer.WriteDatas(Types);
			writer.WriteData(this.TaxPercentage);
			writer.WriteData(this.TaxModificationPercentage);
			writer.WriteData(this.MaxItemLevel);
			writer.WriteData(this.MaxItemPerAccount);
			writer.WriteData(this.NpcContextualId);
			writer.WriteData(this.UnsoldDelay);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int Quantities_length = reader.Read<short>();
			this.Quantities = new CustomVar<int>[Quantities_length];
			for(int i = 0; i < Quantities_length; i++)
				this.Quantities[i] = reader.Read<CustomVar<int>>();
			int Types_length = reader.Read<short>();
			this.Types = new CustomVar<int>[Types_length];
			for(int i = 0; i < Types_length; i++)
				this.Types[i] = reader.Read<CustomVar<int>>();
			this.TaxPercentage = reader.Read<float>();
			this.TaxModificationPercentage = reader.Read<float>();
			this.MaxItemLevel = reader.Read<byte>();
			this.MaxItemPerAccount = reader.Read<CustomVar<int>>();
			this.NpcContextualId = reader.Read<int>();
			this.UnsoldDelay = reader.Read<CustomVar<short>>();

		}


	}
}
