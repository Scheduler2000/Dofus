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

namespace Renaissance.Protocol.types.common.basic
{
	public class StatisticDataInt : StatisticData, IDofusType
	{
		public new const int NetworkId = 485;
		public new int ProtocolId { get { return NetworkId; } }

		public int Value { get; set; }


		public StatisticDataInt() { }


		public StatisticDataInt InitStatisticDataInt(int _value)
		{

			this.Value = _value;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.Value);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.Value = reader.Read<int>();

		}


	}
}
