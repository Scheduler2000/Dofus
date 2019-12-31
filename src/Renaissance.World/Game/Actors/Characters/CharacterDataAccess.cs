using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Renaissance.Protocol.types.game.character.choice;
using Renaissance.World.Database.Characters;
using Renaissance.World.IoC;

namespace Renaissance.World.Game.Actors.Characters
{
    public class CharacterDataAccess
    {
        public CharacterRecord Data { get; }

        public CharacterBaseInformations[] BaseInformations { get; }

        public CharacterBaseInformations CharacterInformations { get; }

        public CharacterDataAccess(CharacterRecord data)
        {
            var repository = ServiceLocator.Provider.GetService<CharacterRepository>();

            this.Data = data;
            this.BaseInformations = repository.FetchBaseInformations(data.Id);
            this.CharacterInformations = repository.FetchBaseInformation(data.Id);
        }
    }
}
