//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:10.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.dare;

namespace Renaissance.Protocol.messages.game.dare
{
	public class DareSubscribedMessage : IDofusMessage
	{
		public  const int NetworkId = 6660;
		public  int ProtocolId { get { return NetworkId; } }

		public double DareId { get; set; }

		public WrappedBool Success { get; set; }

		public WrappedBool Subscribe { get; set; }

		public DareVersatileInformations DareVersatilesInfos { get; set; }


		public DareSubscribedMessage() { }


		public DareSubscribedMessage InitDareSubscribedMessage(double _dareid, WrappedBool _success, WrappedBool _subscribe, DareVersatileInformations _dareversatilesinfos)
		{

			this.DareId = _dareid;
			this.Success = _success;
			this.Subscribe = _subscribe;
			this.DareVersatilesInfos = _dareversatilesinfos;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			byte box = 0;
			box = writer.SetFlag(box,0,this.Success);
			box = writer.SetFlag(box,1,this.Subscribe);
			writer.Write(box);
			writer.Write(this.DareId);
			writer.Write(this.DareVersatilesInfos.Serialize());

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			byte box = reader.Read<byte>();
			this.Success = reader.ReadFlag(box,0);
			this.Subscribe = reader.ReadFlag(box,1);
			this.DareId = reader.Read<double>();
			this.DareVersatilesInfos = new DareVersatileInformations();
			this.DareVersatilesInfos.Deserialize(reader);

		}


	}
}
