
using Renaissance.Abstract.Frame;
using Renaissance.Protocol;
using Renaissance.Protocol.messages.game.character.choice;
using Renaissance.World.Networking;

namespace Renaissance.World.Frame.Character
{
    public class CharacterChoiceFrame : IFrame
    {
        [MessageHandler(CharactersListRequestMessage.NetworkId)]
        public void HandleCharacterListRequestMessage(WorldClient client, IDofusMessage message)
        {
            client.Connection.Send(new CharactersListMessage()
                             .InitCharactersListMessage(client.Character.DataAccess.BaseInformations, false));
        }
    }
}
