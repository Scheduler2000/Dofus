//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:13.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.modificator
{
	public class AreaFightModificatorUpdateMessage : IDofusMessage
	{
		public  const int NetworkId = 6493;
		public  int ProtocolId { get { return NetworkId; } }

		public int SpellPairId { get; set; }


		public AreaFightModificatorUpdateMessage() { }


		public AreaFightModificatorUpdateMessage InitAreaFightModificatorUpdateMessage(int _spellpairid)
		{

			this.SpellPairId = _spellpairid;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.SpellPairId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.SpellPairId = reader.Read<int>();

		}


	}
}