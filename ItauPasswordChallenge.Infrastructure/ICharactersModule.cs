using System.Collections.Generic;

namespace ItauPasswordChallenge.Infrastructure
{
    public interface ICharactersModule
    {
        IEnumerable<char> GetAlphabetLowerCase();
        IEnumerable<char> GetAlphabetUpperCase();
        IEnumerable<char> GetNumericCharacters();
        IEnumerable<char> GetSpecialCharacters();
    }
}