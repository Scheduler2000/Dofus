using System;

using Microsoft.Extensions.DependencyInjection;

using Renaissance.Abstract.Extensions;
using Renaissance.Abstract.Frame;
using Renaissance.Protocol;
using Renaissance.Protocol.messages.game.character.creation;
using Renaissance.World.IoC;
using Renaissance.World.Manager.Frame.Character;
using Renaissance.World.Networking;

namespace Renaissance.World.Frame.Character
{
    public class CharacterCreationFrame : IFrame
    {
        [MessageHandler(CharacterCreationRequestMessage.NetworkId)]
        public void HandleCharacterCreationRequestMessage(WorldClient client, IDofusMessage message)
        {
            ServiceLocator.Provider.GetService<CharacterCreationManager>()
                                   .SendCharacterCreationResultMessage(client, message as CharacterCreationRequestMessage);

        }

        [MessageHandler(CharacterNameSuggestionRequestMessage.NetworkId)]
        public void HandleCharacterNameSuggestionRequestMessage(WorldClient client, IDofusMessage message)
        {
            client.Connection.Send(new CharacterNameSuggestionSuccessMessage()
                             .InitCharacterNameSuggestionSuccessMessage(new Random().Next(5, 10).GenerateName()));
        }
    }
}
