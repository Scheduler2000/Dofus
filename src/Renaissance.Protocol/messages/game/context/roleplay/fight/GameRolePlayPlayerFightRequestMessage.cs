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
	public class GameRolePlayPlayerFightRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 5731;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<long> TargetId { get; set; }

		public short TargetCellId { get; set; }

		public bool Friendly { get; set; }


		public GameRolePlayPlayerFightRequestMessage() { }


		public GameRolePlayPlayerFightRequestMessage InitGameRolePlayPlayerFightRequestMessage(CustomVar<long> _targetid, short _targetcellid, bool _friendly)
		{

			this.TargetId = _targetid;
			this.TargetCellId = _targetcellid;
			this.Friendly = _friendly;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(TargetId);
			size += DofusBinaryFactory.Sizing.SizeOf(TargetCellId);
			size += DofusBinaryFactory.Sizing.SizeOf(Friendly);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.TargetId);
			writer.WriteData(this.TargetCellId);
			writer.WriteData(this.Friendly);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.TargetId = reader.Read<CustomVar<long>>();
			this.TargetCellId = reader.Read<short>();
			this.Friendly = reader.Read<bool>();

		}


	}
}
