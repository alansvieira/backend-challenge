using ItauPasswordChallenge.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItauPasswordChallenge.Core.Behaviors
{
    public class TextValidationBehavior<T> where T : IEntity
    {
        string _word = string.Empty;
        
        public TextValidationBehavior(string word)
        {
            _word = word;
        }
     
        public virtual bool ContainsAtLeastOneCharacterAsUppercase()
        {
            return _word.Any(char.IsUpper);
        }
        
        public virtual bool ContainsAtLeastOneCharacterAsLowercase()
        {
            return _word.Any(char.IsLower);            
        }

        public virtual bool ContainsAtLeastOneCharacterOfCollection(IEnumerable<char> collection)
        {
            return _word.IndexOfAny(collection.ToArray()) != -1;            
        }

        public virtual bool ContainsOnlyCharacterOfCollection(IEnumerable<char> collection)
        {
            return _word.All(c => collection.Contains(c));            
        }

        public virtual bool ContainsOnlyDistinctCharacters()
        {
            return new String(_word.Distinct().ToArray()).Length == _word.Length;
        }

        public virtual bool DoesNotContainWhiteSpaces()
        {
            return !_word.Any(char.IsWhiteSpace);
        }

        public virtual bool HasAtLeast(int minValue)
        {
            return _word.Length >= minValue;
        }
        
        public virtual bool HasAtMost(int maxValue)
        {
            return _word.Length <= maxValue;            
        }

    }
}
