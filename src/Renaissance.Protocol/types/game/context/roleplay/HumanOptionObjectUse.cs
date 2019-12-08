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

namespace Renaissance.Protocol.types.game.context.roleplay
{
	public class HumanOptionObjectUse : HumanOption, IDofusType
	{
		public new const int NetworkId = 449;
		public new int ProtocolId { get { return NetworkId; } }

		public byte DelayTypeId { get; set; }

		public double DelayEndTime { get; set; }

		public CustomVar<short> ObjectGID { get; set; }


		public HumanOptionObjectUse() { }


		public HumanOptionObjectUse InitHumanOptionObjectUse(byte _delaytypeid, double _delayendtime, CustomVar<short> _objectgid)
		{

			this.DelayTypeId = _delaytypeid;
			this.DelayEndTime = _delayendtime;
			this.ObjectGID = _objectgid;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(DelayTypeId);
			size += DofusBinaryFactory.Sizing.SizeOf(DelayEndTime);
			size += DofusBinaryFactory.Sizing.SizeOf(ObjectGID);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData(this.DelayTypeId);
			writer.WriteData(this.DelayEndTime);
			writer.WriteData(this.ObjectGID);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.DelayTypeId = reader.Read<byte>();
			this.DelayEndTime = reader.Read<double>();
			this.ObjectGID = reader.Read<CustomVar<short>>();

		}


	}
}
