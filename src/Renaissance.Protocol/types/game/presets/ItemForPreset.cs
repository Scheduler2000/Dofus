//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:59.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.presets
{
	public class ItemForPreset : IDofusType
	{
		public  const int NetworkId = 540;
		public  int ProtocolId { get { return NetworkId; } }

		public short Position { get; set; }

		public CustomVar<short> ObjGid { get; set; }

		public CustomVar<int> ObjUid { get; set; }


		public ItemForPreset() { }


		public ItemForPreset InitItemForPreset(short _position, CustomVar<short> _objgid, CustomVar<int> _objuid)
		{

			this.Position = _position;
			this.ObjGid = _objgid;
			this.ObjUid = _objuid;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Position);
			size += DofusBinaryFactory.Sizing.SizeOf(ObjGid);
			size += DofusBinaryFactory.Sizing.SizeOf(ObjUid);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.Position);
			writer.WriteData(this.ObjGid);
			writer.WriteData(this.ObjUid);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Position = reader.Read<short>();
			this.ObjGid = reader.Read<CustomVar<short>>();
			this.ObjUid = reader.Read<CustomVar<int>>();

		}


	}
}
