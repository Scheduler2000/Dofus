//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:42.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.prism;
using    Renaissance.Protocol.types.game.social;
using    Renaissance.Protocol.types.game.social;

namespace Renaissance.Protocol.messages.game.alliance
{
	public class AllianceInsiderInfoMessage : IDofusMessage
	{
		public  const int NetworkId = 6403;
		public  int ProtocolId { get { return NetworkId; } }

		public AllianceFactSheetInformations AllianceInfos { get; set; }

		public GuildInsiderFactSheetInformations[] Guilds { get; set; }

		public PrismSubareaEmptyInfo[] Prisms { get; set; }


		public AllianceInsiderInfoMessage() { }


		public AllianceInsiderInfoMessage InitAllianceInsiderInfoMessage(AllianceFactSheetInformations _allianceinfos, GuildInsiderFactSheetInformations[] _guilds, PrismSubareaEmptyInfo[] _prisms)
		{

			this.AllianceInfos = _allianceinfos;
			this.Guilds = _guilds;
			this.Prisms = _prisms;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			var serialized1 = this.AllianceInfos.Serialize();
			size += serialized1.Length;
			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Guilds.Length));
			var memory1 = new Memory<byte>[Guilds.Length];
			for(int i = 0; i < Guilds.Length; i++)
			{
				memory1[i] = this.Guilds[i].Serialize();
				size += memory1[i].Length;
			}
			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Prisms.Length));
			var memory2 = new Memory<byte>[Prisms.Length];
			for(int i = 0; i < Prisms.Length; i++)
			{
				size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Prisms[i].ProtocolId));
				memory2[i] = this.Prisms[i].Serialize();
				size += memory2[i].Length;
			}


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(serialized1);
			writer.WriteData((short)(this.Guilds.Length));
			for(int i = 0; i < memory1.Length; i++)
			{
				writer.WriteDatas(memory1[i]);
			}
			writer.WriteData((short)(this.Prisms.Length));
			for(int i = 0; i < memory2.Length; i++)
			{
				writer.WriteData((short)(Prisms[i].ProtocolId));
				writer.WriteDatas(memory2[i]);
			}

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.AllianceInfos = new AllianceFactSheetInformations();
			this.AllianceInfos.Deserialize(reader);
			int Guilds_length = reader.Read<short>();
			this.Guilds = new GuildInsiderFactSheetInformations[Guilds_length];
			for(int i = 0; i < Guilds_length; i++)
			{
				this.Guilds[i] = new GuildInsiderFactSheetInformations();
				this.Guilds[i].Deserialize(reader);
			}
			int Prisms_length = reader.Read<short>();
			this.Prisms = new PrismSubareaEmptyInfo[Prisms_length];
			for(int i = 0; i < Prisms_length; i++)
			{
			reader.Skip(2); // skip protocolManager.GetInstance(short)
				this.Prisms[i] = new PrismSubareaEmptyInfo();
				this.Prisms[i].Deserialize(reader);
			}

		}


	}
}
