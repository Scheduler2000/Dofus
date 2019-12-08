//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:48.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.messages.game.actions;

namespace Renaissance.Protocol.messages.game.actions.fight
{
	public class GameActionFightPointsVariationMessage : AbstractGameActionMessage, IDofusMessage
	{
		public new const int NetworkId = 1030;
		public new int ProtocolId { get { return NetworkId; } }

		public double TargetId { get; set; }

		public short Delta { get; set; }


		public GameActionFightPointsVariationMessage() { }


		public GameActionFightPointsVariationMessage InitGameActionFightPointsVariationMessage(CustomVar<short> _actionid, double _sourceid, double _targetid, short _delta)
		{

			base.ActionId = _actionid;
			base.SourceId = _sourceid;
			this.TargetId = _targetid;
			this.Delta = _delta;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(TargetId);
			size += DofusBinaryFactory.Sizing.SizeOf(Delta);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData(this.TargetId);
			writer.WriteData(this.Delta);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.TargetId = reader.Read<double>();
			this.Delta = reader.Read<short>();

		}


	}
}
