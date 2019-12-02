//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:31.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.context.roleplay.treasureHunt
{
	public class TreasureHuntStepFollowDirectionToPOI : TreasureHuntStep, IDofusType
	{
		public new const int NetworkId = 461;
		public new int ProtocolId { get { return NetworkId; } }

		public byte Direction { get; set; }

		public CustomVar<short> PoiLabelId { get; set; }


		public TreasureHuntStepFollowDirectionToPOI() { }


		public TreasureHuntStepFollowDirectionToPOI InitTreasureHuntStepFollowDirectionToPOI(byte _direction, CustomVar<short> _poilabelid)
		{

			this.Direction = _direction;
			this.PoiLabelId = _poilabelid;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.Direction);
			writer.Write(this.PoiLabelId);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.Direction = reader.Read<byte>();
			this.PoiLabelId = reader.Read<CustomVar<short>>();

		}


	}
}
