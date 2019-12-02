//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:18.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.mount
{
	public class MountXpRatioMessage : IDofusMessage
	{
		public  const int NetworkId = 5970;
		public  int ProtocolId { get { return NetworkId; } }

		public byte Ratio { get; set; }


		public MountXpRatioMessage() { }


		public MountXpRatioMessage InitMountXpRatioMessage(byte _ratio)
		{

			this.Ratio = _ratio;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Ratio);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Ratio = reader.Read<byte>();

		}


	}
}