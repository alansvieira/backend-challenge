using PasswordChallenge.Core.Entities;
using PasswordChallenge.Core.Resources;
using PasswordChallenge.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordChallenge.Core.Behaviors
{
    public class PasswordValidationBehavior : TextValidationBehavior<Password>
    {
        private Password _password;
        private ICharactersModule _charactersModule;

        private const int MINIMUM_CHARACTERS = 9;

        public PasswordValidationBehavior(Password password, ICharactersModule charactersModule) : base(password.Result.Value)
        {
            _password = password;
            _charactersModule = charactersModule;
        }

        public bool IsValid()
        {
            var validCharacters = new CharacterService(_charactersModule).GetValidCharactersForPassword();
            var specialCharacters = new CharacterService(_charactersModule).GetSpecialCharactersForPassword();
            var numericCharacters = new CharacterService(_charactersModule).GetNumericCharactersForPassword();

            if (!HasAtMost(validCharacters.Count)) { return false; }

            if (!HasAtLeast(MINIMUM_CHARACTERS)) { return false; };

            if (!DoesNotContainWhiteSpaces()) { return false; };

            if (!ContainsOnlyCharacterOfCollection(validCharacters)) { return false; }

            if (!ContainsAtLeastOneCharacterOfCollection(specialCharacters)) { return false; }

            if (!ContainsAtLeastOneCharacterOfCollection(numericCharacters)) { return false; };

            if (!ContainsOnlyDistinctCharacters()) { return false; }

            if (!ContainsAtLeastOneCharacterAsLowercase()) { return false; }

            if (!ContainsAtLeastOneCharacterAsUppercase()) { return false; }

            return true;
        }

        public override bool ContainsAtLeastOneCharacterAsUppercase()
        {
            bool isValid = base.ContainsAtLeastOneCharacterAsUppercase();

            if (!isValid)
                _password.ErrorHandling.ValidationErrors.Add(Localization.Password.ErrorContainsAtLeastOneCharacterAsUppercaseText);

            return isValid;
        }

        public override bool ContainsAtLeastOneCharacterAsLowercase()
        {
            bool isValid = base.ContainsAtLeastOneCharacterAsLowercase();

            if (!isValid)
                _password.ErrorHandling.ValidationErrors.Add(Localization.Password.ErrorContainsAtLeastOneCharacterAsLowercaseText);

            return isValid;
        }

        public override bool ContainsAtLeastOneCharacterOfCollection(IEnumerable<char> collection)
        {
            bool isValid = base.ContainsAtLeastOneCharacterOfCollection(collection);

            if (!isValid)
                _password.ErrorHandling.ValidationErrors.Add(Localization.Password.ErrorContainsAtLeastOneCharacterOfCollectionText);

            return isValid;
        }

        public override bool ContainsOnlyCharacterOfCollection(IEnumerable<char> collection)
        {
            bool isValid = base.ContainsOnlyCharacterOfCollection(collection);

            if (!isValid)
                _password.ErrorHandling.ValidationErrors.Add(Localization.Password.ErrorContainsOnlyCharacterOfCollectionText);

            return isValid;
        }

        public override bool ContainsOnlyDistinctCharacters()
        {
            bool isValid = base.ContainsOnlyDistinctCharacters();

            if (!isValid)
                _password.ErrorHandling.ValidationErrors.Add(Localization.Password.ErrorContainsOnlyDistinctCharactersText);

            return isValid;
        }

        public override bool DoesNotContainWhiteSpaces()
        {
            bool isValid = base.DoesNotContainWhiteSpaces();

            if (!isValid)
                _password.ErrorHandling.ValidationErrors.Add(Localization.Password.ErrorNotContainWhiteSpacesText);

            return isValid;
        }

        public override bool HasAtLeast(int minValue)
        {
            bool isValid = base.HasAtLeast(minValue);

            if (!isValid)
                _password.ErrorHandling.ValidationErrors.Add(Localization.Password.ErrorHasAtLeastText);

            return isValid;
        }

        public override bool HasAtMost(int maxValue)
        {
            bool isValid = base.HasAtMost(maxValue);

            if (!isValid)
                _password.ErrorHandling.ValidationErrors.Add(Localization.Password.ErrorHasAtMostText);

            return isValid;
        }

    }
}
