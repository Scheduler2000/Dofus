//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:44.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.dare
{
	public class DareWonListMessage : IDofusMessage
	{
		public  const int NetworkId = 6682;
		public  int ProtocolId { get { return NetworkId; } }

		public double[] DareId { get; set; }


		public DareWonListMessage() { }


		public DareWonListMessage InitDareWonListMessage(double[] _dareid)
		{

			this.DareId = _dareid;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.DareId.Length));
			size += DofusBinaryFactory.Sizing.SizeOf(DareId);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData((short)(this.DareId.Length));
			writer.WriteDatas(DareId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int DareId_length = reader.Read<short>();
			this.DareId = new double[DareId_length];
			for(int i = 0; i < DareId_length; i++)
				this.DareId[i] = reader.Read<double>();

		}


	}
}
