//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:09.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.alliance
{
	public class AllianceModificationStartedMessage : IDofusMessage
	{
		public  const int NetworkId = 6444;
		public  int ProtocolId { get { return NetworkId; } }

		public WrappedBool CanChangeName { get; set; }

		public WrappedBool CanChangeTag { get; set; }

		public WrappedBool CanChangeEmblem { get; set; }


		public AllianceModificationStartedMessage() { }


		public AllianceModificationStartedMessage InitAllianceModificationStartedMessage(WrappedBool _canchangename, WrappedBool _canchangetag, WrappedBool _canchangeemblem)
		{

			this.CanChangeName = _canchangename;
			this.CanChangeTag = _canchangetag;
			this.CanChangeEmblem = _canchangeemblem;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			byte box = 0;
			box = writer.SetFlag(box,0,this.CanChangeName);
			box = writer.SetFlag(box,1,this.CanChangeTag);
			box = writer.SetFlag(box,2,this.CanChangeEmblem);
			writer.Write(box);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			byte box = reader.Read<byte>();
			this.CanChangeName = reader.ReadFlag(box,0);
			this.CanChangeTag = reader.ReadFlag(box,1);
			this.CanChangeEmblem = reader.ReadFlag(box,2);

		}


	}
}