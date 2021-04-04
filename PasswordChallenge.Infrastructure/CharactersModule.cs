using System;
using System.Collections.Generic;
using System.Linq;

namespace PasswordChallenge.Infrastructure
{
    public class CharactersModule : ICharactersModule
    {
        private const string SPECIAL_CHARACTERS = "!@#$%^&*()-+";
        private const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWYXZ";
        private const string NUMERIC = "0123456789";

        public IEnumerable<char> GetSpecialCharacters()
        {
            return SPECIAL_CHARACTERS.ToCharArray();
        }

        public IEnumerable<char> GetAlphabetUpperCase()
        {
            return ALPHABET.ToCharArray();
        }

        public IEnumerable<char> GetAlphabetLowerCase()
        {
            return ALPHABET.ToLower().ToCharArray();
        }

        public IEnumerable<char> GetNumericCharacters()
        {
            return NUMERIC.ToCharArray();
        }
    }
}
