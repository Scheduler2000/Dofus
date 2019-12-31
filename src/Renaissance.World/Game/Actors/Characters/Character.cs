using System;
using System.Collections.Generic;
using System.Text;
using Renaissance.World.Database.Characters;

namespace Renaissance.World.Game.Actors.Characters
{
    public class Character
    {
        public CharacterDataAccess DataAccess { get; private set; }

        public Character(CharacterDataAccess data)
        { this.DataAccess = data; }
    }
}
