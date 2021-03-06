//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:50.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.roleplay
{
	public class CurrentMapMessage : IDofusMessage
	{
		public  const int NetworkId = 220;
		public  int ProtocolId { get { return NetworkId; } }

		public double MapId { get; set; }

		public string MapKey { get; set; }


		public CurrentMapMessage() { }


		public CurrentMapMessage InitCurrentMapMessage(double _mapid, string _mapkey)
		{

			this.MapId = _mapid;
			this.MapKey = _mapkey;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(MapId);
			size += DofusBinaryFactory.Sizing.SizeOf(MapKey);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.MapId);
			writer.WriteData(this.MapKey);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.MapId = reader.Read<double>();
			this.MapKey = reader.Read<string>();

		}


	}
}
