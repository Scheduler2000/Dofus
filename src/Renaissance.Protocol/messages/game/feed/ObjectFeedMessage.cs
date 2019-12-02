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
using    Renaissance.Protocol.types.game.data.items;

namespace Renaissance.Protocol.messages.game.feed
{
	public class ObjectFeedMessage : IDofusMessage
	{
		public  const int NetworkId = 6290;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<int> ObjectUID { get; set; }

		public ObjectItemQuantity[] Meal { get; set; }


		public ObjectFeedMessage() { }


		public ObjectFeedMessage InitObjectFeedMessage(CustomVar<int> _objectuid, ObjectItemQuantity[] _meal)
		{

			this.ObjectUID = _objectuid;
			this.Meal = _meal;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.ObjectUID);
			writer.Write((short)(this.Meal.Length));
			foreach(var obj in Meal)
			{
				writer.Write(obj.Serialize());
			}

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.ObjectUID = reader.Read<CustomVar<int>>();
			int Meal_length = reader.Read<short>();
			this.Meal = new ObjectItemQuantity[Meal_length];
			for(int i = 0; i < Meal_length; i++)
			{
				this.Meal[i] = new ObjectItemQuantity();
				this.Meal[i].Deserialize(reader);
			}

		}


	}
}
