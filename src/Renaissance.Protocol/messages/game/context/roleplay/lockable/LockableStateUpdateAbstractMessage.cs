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
	public class LockableStateUpdateAbstractMessage : IDofusMessage
	{
		public  const int NetworkId = 5671;
		public  int ProtocolId { get { return NetworkId; } }

		public bool Locked { get; set; }


		public LockableStateUpdateAbstractMessage() { }


		public LockableStateUpdateAbstractMessage InitLockableStateUpdateAbstractMessage(bool _locked)
		{

			this.Locked = _locked;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Locked);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Locked = reader.Read<bool>();

		}


	}
}
