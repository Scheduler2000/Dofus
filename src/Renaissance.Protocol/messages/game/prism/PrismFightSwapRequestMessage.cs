//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:46.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.prism
{
	public class PrismFightSwapRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 5901;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> SubAreaId { get; set; }

		public CustomVar<long> TargetId { get; set; }


		public PrismFightSwapRequestMessage() { }


		public PrismFightSwapRequestMessage InitPrismFightSwapRequestMessage(CustomVar<short> _subareaid, CustomVar<long> _targetid)
		{

			this.SubAreaId = _subareaid;
			this.TargetId = _targetid;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(SubAreaId);
			size += DofusBinaryFactory.Sizing.SizeOf(TargetId);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.SubAreaId);
			writer.WriteData(this.TargetId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.SubAreaId = reader.Read<CustomVar<short>>();
			this.TargetId = reader.Read<CustomVar<long>>();

		}


	}
}
