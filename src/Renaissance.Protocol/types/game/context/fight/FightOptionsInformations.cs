//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:29.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.context.fight
{
	public class FightOptionsInformations : IDofusType
	{
		public  const int NetworkId = 20;
		public  int ProtocolId { get { return NetworkId; } }

		public WrappedBool IsSecret { get; set; }

		public WrappedBool IsRestrictedToPartyOnly { get; set; }

		public WrappedBool IsClosed { get; set; }

		public WrappedBool IsAskingForHelp { get; set; }


		public FightOptionsInformations() { }


		public FightOptionsInformations InitFightOptionsInformations(WrappedBool _issecret, WrappedBool _isrestrictedtopartyonly, WrappedBool _isclosed, WrappedBool _isaskingforhelp)
		{

			this.IsSecret = _issecret;
			this.IsRestrictedToPartyOnly = _isrestrictedtopartyonly;
			this.IsClosed = _isclosed;
			this.IsAskingForHelp = _isaskingforhelp;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			byte box = 0;
			box = writer.SetFlag(box,0,this.IsSecret);
			box = writer.SetFlag(box,1,this.IsRestrictedToPartyOnly);
			box = writer.SetFlag(box,2,this.IsClosed);
			box = writer.SetFlag(box,3,this.IsAskingForHelp);
			writer.Write(box);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			byte box = reader.Read<byte>();
			this.IsSecret = reader.ReadFlag(box,0);
			this.IsRestrictedToPartyOnly = reader.ReadFlag(box,1);
			this.IsClosed = reader.ReadFlag(box,2);
			this.IsAskingForHelp = reader.ReadFlag(box,3);

		}


	}
}