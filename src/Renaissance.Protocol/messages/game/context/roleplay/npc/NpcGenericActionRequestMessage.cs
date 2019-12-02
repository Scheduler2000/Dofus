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

namespace Renaissance.Protocol.messages.game.context.roleplay.npc
{
	public class NpcGenericActionRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 5898;
		public  int ProtocolId { get { return NetworkId; } }

		public int NpcId { get; set; }

		public byte NpcActionId { get; set; }

		public double NpcMapId { get; set; }


		public NpcGenericActionRequestMessage() { }


		public NpcGenericActionRequestMessage InitNpcGenericActionRequestMessage(int _npcid, byte _npcactionid, double _npcmapid)
		{

			this.NpcId = _npcid;
			this.NpcActionId = _npcactionid;
			this.NpcMapId = _npcmapid;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.NpcId);
			writer.Write(this.NpcActionId);
			writer.Write(this.NpcMapId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.NpcId = reader.Read<int>();
			this.NpcActionId = reader.Read<byte>();
			this.NpcMapId = reader.Read<double>();

		}


	}
}