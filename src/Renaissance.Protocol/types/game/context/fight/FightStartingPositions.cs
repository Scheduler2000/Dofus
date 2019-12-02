//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:29.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.context.fight
{
	public class FightStartingPositions : IDofusType
	{
		public  const int NetworkId = 513;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short>[] PositionsForChallengers { get; set; }

		public CustomVar<short>[] PositionsForDefenders { get; set; }


		public FightStartingPositions() { }


		public FightStartingPositions InitFightStartingPositions(CustomVar<short>[] _positionsforchallengers, CustomVar<short>[] _positionsfordefenders)
		{

			this.PositionsForChallengers = _positionsforchallengers;
			this.PositionsForDefenders = _positionsfordefenders;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write((short)(this.PositionsForChallengers.Length));
			foreach(var item in PositionsForChallengers)
				writer.Write(item);
			writer.Write((short)(this.PositionsForDefenders.Length));
			foreach(var item in PositionsForDefenders)
				writer.Write(item);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int PositionsForChallengers_length = reader.Read<short>();
			this.PositionsForChallengers = new CustomVar<short>[PositionsForChallengers_length];
			for(int i = 0; i < PositionsForChallengers_length; i++)
				this.PositionsForChallengers[i] = reader.Read<CustomVar<short>>();
			int PositionsForDefenders_length = reader.Read<short>();
			this.PositionsForDefenders = new CustomVar<short>[PositionsForDefenders_length];
			for(int i = 0; i < PositionsForDefenders_length; i++)
				this.PositionsForDefenders[i] = reader.Read<CustomVar<short>>();

		}


	}
}