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

namespace Renaissance.Protocol.messages.game.dare
{
	public class DareErrorMessage : IDofusMessage
	{
		public  const int NetworkId = 6667;
		public  int ProtocolId { get { return NetworkId; } }

		public byte Error { get; set; }


		public DareErrorMessage() { }


		public DareErrorMessage InitDareErrorMessage(byte _error)
		{

			this.Error = _error;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Error);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Error = reader.Read<byte>();

		}


	}
}
