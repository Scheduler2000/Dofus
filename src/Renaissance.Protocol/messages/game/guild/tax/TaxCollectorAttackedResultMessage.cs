//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:50.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.context.roleplay;
using    Renaissance.Protocol.types.game.guild.tax;

namespace Renaissance.Protocol.messages.game.guild.tax
{
	public class TaxCollectorAttackedResultMessage : IDofusMessage
	{
		public  const int NetworkId = 5635;
		public  int ProtocolId { get { return NetworkId; } }

		public bool DeadOrAlive { get; set; }

		public TaxCollectorBasicInformations BasicInfos { get; set; }

		public BasicGuildInformations Guild { get; set; }


		public TaxCollectorAttackedResultMessage() { }


		public TaxCollectorAttackedResultMessage InitTaxCollectorAttackedResultMessage(bool _deadoralive, TaxCollectorBasicInformations _basicinfos, BasicGuildInformations _guild)
		{

			this.DeadOrAlive = _deadoralive;
			this.BasicInfos = _basicinfos;
			this.Guild = _guild;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(DeadOrAlive);
			var serialized1 = this.BasicInfos.Serialize();
			size += serialized1.Length;
			var serialized2 = this.Guild.Serialize();
			size += serialized2.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.DeadOrAlive);
			writer.WriteDatas(serialized1);
			writer.WriteDatas(serialized2);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.DeadOrAlive = reader.Read<bool>();
			this.BasicInfos = new TaxCollectorBasicInformations();
			this.BasicInfos.Deserialize(reader);
			this.Guild = new BasicGuildInformations();
			this.Guild.Deserialize(reader);

		}


	}
}
