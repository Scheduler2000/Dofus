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
using    Renaissance.Protocol.types.game.context.roleplay.party;

namespace Renaissance.Protocol.messages.game.context.roleplay.party
{
	public class DungeonPartyFinderRoomContentUpdateMessage : IDofusMessage
	{
		public  const int NetworkId = 6250;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> DungeonId { get; set; }

		public DungeonPartyFinderPlayer[] AddedPlayers { get; set; }

		public CustomVar<long>[] RemovedPlayersIds { get; set; }


		public DungeonPartyFinderRoomContentUpdateMessage() { }


		public DungeonPartyFinderRoomContentUpdateMessage InitDungeonPartyFinderRoomContentUpdateMessage(CustomVar<short> _dungeonid, DungeonPartyFinderPlayer[] _addedplayers, CustomVar<long>[] _removedplayersids)
		{

			this.DungeonId = _dungeonid;
			this.AddedPlayers = _addedplayers;
			this.RemovedPlayersIds = _removedplayersids;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(DungeonId);
			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.AddedPlayers.Length));
			var memory1 = new Memory<byte>[AddedPlayers.Length];
			for(int i = 0; i < AddedPlayers.Length; i++)
			{
				memory1[i] = this.AddedPlayers[i].Serialize();
				size += memory1[i].Length;
			}
			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.RemovedPlayersIds.Length));
			size += DofusBinaryFactory.Sizing.SizeOf(RemovedPlayersIds);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.DungeonId);
			writer.WriteData((short)(this.AddedPlayers.Length));
			for(int i = 0; i < memory1.Length; i++)
			{
				writer.WriteDatas(memory1[i]);
			}
			writer.WriteData((short)(this.RemovedPlayersIds.Length));
			writer.WriteDatas(RemovedPlayersIds);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.DungeonId = reader.Read<CustomVar<short>>();
			int AddedPlayers_length = reader.Read<short>();
			this.AddedPlayers = new DungeonPartyFinderPlayer[AddedPlayers_length];
			for(int i = 0; i < AddedPlayers_length; i++)
			{
				this.AddedPlayers[i] = new DungeonPartyFinderPlayer();
				this.AddedPlayers[i].Deserialize(reader);
			}
			int RemovedPlayersIds_length = reader.Read<short>();
			this.RemovedPlayersIds = new CustomVar<long>[RemovedPlayersIds_length];
			for(int i = 0; i < RemovedPlayersIds_length; i++)
				this.RemovedPlayersIds[i] = reader.Read<CustomVar<long>>();

		}


	}
}
