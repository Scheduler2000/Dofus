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
	public class TreasureHuntStepDig : TreasureHuntStep, IDofusType
	{
		public new const int NetworkId = 465;
		public new int ProtocolId { get { return NetworkId; } }


		public TreasureHuntStepDig() { }


		public TreasureHuntStepDig InitTreasureHuntStepDig()
		{


			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);

		}


	}
}