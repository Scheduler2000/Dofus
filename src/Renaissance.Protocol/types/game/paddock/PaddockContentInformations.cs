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
	public class PaddockContentInformations : PaddockInformations, IDofusType
	{
		public new const int NetworkId = 183;
		public new int ProtocolId { get { return NetworkId; } }

		public double PaddockId { get; set; }

		public short WorldX { get; set; }

		public short WorldY { get; set; }

		public double MapId { get; set; }

		public CustomVar<short> SubAreaId { get; set; }

		public bool Abandonned { get; set; }

		public MountInformationsForPaddock[] MountsInformations { get; set; }


		public PaddockContentInformations() { }


		public PaddockContentInformations InitPaddockContentInformations(double _paddockid, short _worldx, short _worldy, double _mapid, CustomVar<short> _subareaid, bool _abandonned, MountInformationsForPaddock[] _mountsinformations)
		{

			this.PaddockId = _paddockid;
			this.WorldX = _worldx;
			this.WorldY = _worldy;
			this.MapId = _mapid;
			this.SubAreaId = _subareaid;
			this.Abandonned = _abandonned;
			this.MountsInformations = _mountsinformations;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(PaddockId);
			size += DofusBinaryFactory.Sizing.SizeOf(WorldX);
			size += DofusBinaryFactory.Sizing.SizeOf(WorldY);
			size += DofusBinaryFactory.Sizing.SizeOf(MapId);
			size += DofusBinaryFactory.Sizing.SizeOf(SubAreaId);
			size += DofusBinaryFactory.Sizing.SizeOf(Abandonned);
			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.MountsInformations.Length));
			var memory1 = new Memory<byte>[MountsInformations.Length];
			for(int i = 0; i < MountsInformations.Length; i++)
			{
				memory1[i] = this.MountsInformations[i].Serialize();
				size += memory1[i].Length;
			}
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData(this.PaddockId);
			writer.WriteData(this.WorldX);
			writer.WriteData(this.WorldY);
			writer.WriteData(this.MapId);
			writer.WriteData(this.SubAreaId);
			writer.WriteData(this.Abandonned);
			writer.WriteData((short)(this.MountsInformations.Length));
			for(int i = 0; i < memory1.Length; i++)
			{
				writer.WriteDatas(memory1[i]);
			}

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.PaddockId = reader.Read<double>();
			this.WorldX = reader.Read<short>();
			this.WorldY = reader.Read<short>();
			this.MapId = reader.Read<double>();
			this.SubAreaId = reader.Read<CustomVar<short>>();
			this.Abandonned = reader.Read<bool>();
			int MountsInformations_length = reader.Read<short>();
			this.MountsInformations = new MountInformationsForPaddock[MountsInformations_length];
			for(int i = 0; i < MountsInformations_length; i++)
			{
				this.MountsInformations[i] = new MountInformationsForPaddock();
				this.MountsInformations[i].Deserialize(reader);
			}

		}


	}
}
