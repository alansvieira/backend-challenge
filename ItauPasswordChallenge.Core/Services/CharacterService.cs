using ItauPasswordChallenge.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItauPasswordChallenge.Core
{
    public class CharacterService
    {
        private ICharactersModule _module = null;
        public CharacterService(ICharactersModule module) {
            _module = module;
        }

        public List<char> GetValidCharactersForPassword()
        {
            var validCharacters = new List<char>();

            validCharacters.AddRange(_module.GetAlphabetUpperCase().ToList());
            validCharacters.AddRange(_module.GetAlphabetLowerCase().ToList());
            validCharacters.AddRange(_module.GetNumericCharacters().ToList());
            validCharacters.AddRange(_module.GetSpecialCharacters().ToList());

            return validCharacters;
        }

        public List<char> GetSpecialCharactersForPassword()
        {
            var specialCharacters = new List<char>();

            specialCharacters.AddRange(_module.GetSpecialCharacters().ToList());

            return specialCharacters;
        }

        public List<char> GetNumericCharactersForPassword()
        {
            var specialCharacters = new List<char>();

            specialCharacters.AddRange(_module.GetNumericCharacters().ToList());

            return specialCharacters;
        }

    }
}
