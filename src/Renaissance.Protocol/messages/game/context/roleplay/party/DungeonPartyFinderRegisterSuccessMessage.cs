//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:55.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.roleplay.party
{
	public class DungeonPartyFinderRegisterSuccessMessage : IDofusMessage
	{
		public  const int NetworkId = 6241;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short>[] DungeonIds { get; set; }


		public DungeonPartyFinderRegisterSuccessMessage() { }


		public DungeonPartyFinderRegisterSuccessMessage InitDungeonPartyFinderRegisterSuccessMessage(CustomVar<short>[] _dungeonids)
		{

			this.DungeonIds = _dungeonids;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.DungeonIds.Length));
			size += DofusBinaryFactory.Sizing.SizeOf(DungeonIds);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData((short)(this.DungeonIds.Length));
			writer.WriteDatas(DungeonIds);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int DungeonIds_length = reader.Read<short>();
			this.DungeonIds = new CustomVar<short>[DungeonIds_length];
			for(int i = 0; i < DungeonIds_length; i++)
				this.DungeonIds[i] = reader.Read<CustomVar<short>>();

		}


	}
}
