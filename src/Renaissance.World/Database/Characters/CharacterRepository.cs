using System.Linq;

using Renaissance.Binary.Definition;
using Renaissance.Database.Pattern;
using Renaissance.Protocol.types.game.character.choice;

namespace Renaissance.World.Database.Characters
{
    public class CharacterRepository : Repository<CharacterContext, CharacterRecord>
    {
        public CharacterBaseInformations[] FetchBaseInformations(int accountId)
        {

            return base.GetEntities(x => x.AccountId == accountId)
                       .Select(x => new CharacterBaseInformations()
                       .InitCharacterBaseInformations(x.LastLook.ToEntityLook(),
                       (byte)x.BreedId, new CustomVar<short>(x.Level), x.Name,
                       new CustomVar<long>(x.Id), x.Sex)).ToArray();
        }

        public CharacterBaseInformations FetchBaseInformation(int id)
        {
            var character = base.GetEntity(x => x.Id == id);

            return new CharacterBaseInformations()
                       .InitCharacterBaseInformations(character.LastLook.ToEntityLook(), (byte)character.BreedId,
                                                      new CustomVar<short>(character.Level), character.Name,
                                                      new CustomVar<long>(character.Id), character.Sex);
        }

    }
}
