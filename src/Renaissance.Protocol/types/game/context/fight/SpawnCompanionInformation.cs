//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:30.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.context.fight
{
	public class SpawnCompanionInformation : SpawnInformation, IDofusType
	{
		public new const int NetworkId = 573;
		public new int ProtocolId { get { return NetworkId; } }

		public byte ModelId { get; set; }

		public CustomVar<short> Level { get; set; }

		public double SummonerId { get; set; }

		public double OwnerId { get; set; }


		public SpawnCompanionInformation() { }


		public SpawnCompanionInformation InitSpawnCompanionInformation(byte _modelid, CustomVar<short> _level, double _summonerid, double _ownerid)
		{

			this.ModelId = _modelid;
			this.Level = _level;
			this.SummonerId = _summonerid;
			this.OwnerId = _ownerid;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.ModelId);
			writer.Write(this.Level);
			writer.Write(this.SummonerId);
			writer.Write(this.OwnerId);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.ModelId = reader.Read<byte>();
			this.Level = reader.Read<CustomVar<short>>();
			this.SummonerId = reader.Read<double>();
			this.OwnerId = reader.Read<double>();

		}


	}
}
