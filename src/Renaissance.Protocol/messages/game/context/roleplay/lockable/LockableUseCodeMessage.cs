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

namespace Renaissance.Protocol.messages.game.context.roleplay.lockable
{
	public class LockableUseCodeMessage : IDofusMessage
	{
		public  const int NetworkId = 5667;
		public  int ProtocolId { get { return NetworkId; } }

		public string Code { get; set; }


		public LockableUseCodeMessage() { }


		public LockableUseCodeMessage InitLockableUseCodeMessage(string _code)
		{

			this.Code = _code;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Code);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Code = reader.Read<string>();

		}


	}
}
