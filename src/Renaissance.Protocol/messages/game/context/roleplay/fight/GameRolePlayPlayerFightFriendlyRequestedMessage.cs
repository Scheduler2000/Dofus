//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:54.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.roleplay.fight
{
	public class GameRolePlayPlayerFightFriendlyRequestedMessage : IDofusMessage
	{
		public  const int NetworkId = 5937;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> FightId { get; set; }

		public CustomVar<long> SourceId { get; set; }

		public CustomVar<long> TargetId { get; set; }


		public GameRolePlayPlayerFightFriendlyRequestedMessage() { }


		public GameRolePlayPlayerFightFriendlyRequestedMessage InitGameRolePlayPlayerFightFriendlyRequestedMessage(CustomVar<short> _fightid, CustomVar<long> _sourceid, CustomVar<long> _targetid)
		{

			this.FightId = _fightid;
			this.SourceId = _sourceid;
			this.TargetId = _targetid;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(FightId);
			size += DofusBinaryFactory.Sizing.SizeOf(SourceId);
			size += DofusBinaryFactory.Sizing.SizeOf(TargetId);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.FightId);
			writer.WriteData(this.SourceId);
			writer.WriteData(this.TargetId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.FightId = reader.Read<CustomVar<short>>();
			this.SourceId = reader.Read<CustomVar<long>>();
			this.TargetId = reader.Read<CustomVar<long>>();

		}


	}
}
