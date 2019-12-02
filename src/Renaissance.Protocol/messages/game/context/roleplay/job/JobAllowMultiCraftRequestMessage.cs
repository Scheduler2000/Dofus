//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:24.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.roleplay.job
{
	public class JobAllowMultiCraftRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 5748;
		public  int ProtocolId { get { return NetworkId; } }

		public bool Enabled { get; set; }


		public JobAllowMultiCraftRequestMessage() { }


		public JobAllowMultiCraftRequestMessage InitJobAllowMultiCraftRequestMessage(bool _enabled)
		{

			this.Enabled = _enabled;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Enabled);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Enabled = reader.Read<bool>();

		}


	}
}
