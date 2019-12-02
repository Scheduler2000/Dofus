//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:27.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.dare
{
	public class DareVersatileInformations : IDofusType
	{
		public  const int NetworkId = 504;
		public  int ProtocolId { get { return NetworkId; } }

		public double DareId { get; set; }

		public int CountEntrants { get; set; }

		public int CountWinners { get; set; }


		public DareVersatileInformations() { }


		public DareVersatileInformations InitDareVersatileInformations(double _dareid, int _countentrants, int _countwinners)
		{

			this.DareId = _dareid;
			this.CountEntrants = _countentrants;
			this.CountWinners = _countwinners;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.DareId);
			writer.Write(this.CountEntrants);
			writer.Write(this.CountWinners);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.DareId = reader.Read<double>();
			this.CountEntrants = reader.Read<int>();
			this.CountWinners = reader.Read<int>();

		}


	}
}
