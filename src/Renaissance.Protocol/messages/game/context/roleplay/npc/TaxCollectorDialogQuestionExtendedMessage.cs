//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:55.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.context.roleplay;

namespace Renaissance.Protocol.messages.game.context.roleplay.npc
{
	public class TaxCollectorDialogQuestionExtendedMessage : TaxCollectorDialogQuestionBasicMessage, IDofusMessage
	{
		public new const int NetworkId = 5615;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> MaxPods { get; set; }

		public CustomVar<short> Prospecting { get; set; }

		public CustomVar<short> Wisdom { get; set; }

		public byte TaxCollectorsCount { get; set; }

		public int TaxCollectorAttack { get; set; }

		public CustomVar<long> Kamas { get; set; }

		public CustomVar<long> Experience { get; set; }

		public CustomVar<int> Pods { get; set; }

		public CustomVar<long> ItemsValue { get; set; }


		public TaxCollectorDialogQuestionExtendedMessage() { }


		public TaxCollectorDialogQuestionExtendedMessage InitTaxCollectorDialogQuestionExtendedMessage(BasicGuildInformations _guildinfo, CustomVar<short> _maxpods, CustomVar<short> _prospecting, CustomVar<short> _wisdom, byte _taxcollectorscount, int _taxcollectorattack, CustomVar<long> _kamas, CustomVar<long> _experience, CustomVar<int> _pods, CustomVar<long> _itemsvalue)
		{

			base.GuildInfo = _guildinfo;
			this.MaxPods = _maxpods;
			this.Prospecting = _prospecting;
			this.Wisdom = _wisdom;
			this.TaxCollectorsCount = _taxcollectorscount;
			this.TaxCollectorAttack = _taxcollectorattack;
			this.Kamas = _kamas;
			this.Experience = _experience;
			this.Pods = _pods;
			this.ItemsValue = _itemsvalue;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(MaxPods);
			size += DofusBinaryFactory.Sizing.SizeOf(Prospecting);
			size += DofusBinaryFactory.Sizing.SizeOf(Wisdom);
			size += DofusBinaryFactory.Sizing.SizeOf(TaxCollectorsCount);
			size += DofusBinaryFactory.Sizing.SizeOf(TaxCollectorAttack);
			size += DofusBinaryFactory.Sizing.SizeOf(Kamas);
			size += DofusBinaryFactory.Sizing.SizeOf(Experience);
			size += DofusBinaryFactory.Sizing.SizeOf(Pods);
			size += DofusBinaryFactory.Sizing.SizeOf(ItemsValue);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData(this.MaxPods);
			writer.WriteData(this.Prospecting);
			writer.WriteData(this.Wisdom);
			writer.WriteData(this.TaxCollectorsCount);
			writer.WriteData(this.TaxCollectorAttack);
			writer.WriteData(this.Kamas);
			writer.WriteData(this.Experience);
			writer.WriteData(this.Pods);
			writer.WriteData(this.ItemsValue);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.MaxPods = reader.Read<CustomVar<short>>();
			this.Prospecting = reader.Read<CustomVar<short>>();
			this.Wisdom = reader.Read<CustomVar<short>>();
			this.TaxCollectorsCount = reader.Read<byte>();
			this.TaxCollectorAttack = reader.Read<int>();
			this.Kamas = reader.Read<CustomVar<long>>();
			this.Experience = reader.Read<CustomVar<long>>();
			this.Pods = reader.Read<CustomVar<int>>();
			this.ItemsValue = reader.Read<CustomVar<long>>();

		}


	}
}
