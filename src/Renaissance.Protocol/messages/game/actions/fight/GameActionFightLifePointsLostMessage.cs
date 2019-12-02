//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:15.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.messages.game.actions;

namespace Renaissance.Protocol.messages.game.actions.fight
{
	public class GameActionFightLifePointsLostMessage : AbstractGameActionMessage, IDofusMessage
	{
		public new const int NetworkId = 6312;
		public new int ProtocolId { get { return NetworkId; } }

		public double TargetId { get; set; }

		public CustomVar<int> Loss { get; set; }

		public CustomVar<int> PermanentDamages { get; set; }

		public CustomVar<int> ElementId { get; set; }


		public GameActionFightLifePointsLostMessage() { }


		public GameActionFightLifePointsLostMessage InitGameActionFightLifePointsLostMessage(double _targetid, CustomVar<int> _loss, CustomVar<int> _permanentdamages, CustomVar<int> _elementid)
		{

			this.TargetId = _targetid;
			this.Loss = _loss;
			this.PermanentDamages = _permanentdamages;
			this.ElementId = _elementid;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.TargetId);
			writer.Write(this.Loss);
			writer.Write(this.PermanentDamages);
			writer.Write(this.ElementId);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.TargetId = reader.Read<double>();
			this.Loss = reader.Read<CustomVar<int>>();
			this.PermanentDamages = reader.Read<CustomVar<int>>();
			this.ElementId = reader.Read<CustomVar<int>>();

		}


	}
}