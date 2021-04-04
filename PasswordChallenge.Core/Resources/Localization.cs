using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordChallenge.Core.Resources
{
    // I believe that this would fit better in a resx file (or perhaps in database), but as return validation errors 
    // it's not part of the initial requirements, I just did a 'cleaner' way to avoid magical strings
    public static class Localization
    {
        public static class Password {
            public static string ErrorHasAtMostText = "Your password doesnt match the maximum characters criteria";
            public static string ErrorHasAtLeastText = "Your password doesnt match the minimum characters criteria";
            public static string ErrorNotContainWhiteSpacesText = "Your password cannot contain white spaces";
            public static string ErrorContainsOnlyCharacterOfCollectionText = "Your password contain invalid characters";
            public static string ErrorContainsAtLeastOneCharacterOfCollectionText = "Your password must contain at least one numeric and on special character";
            public static string ErrorContainsOnlyDistinctCharactersText = "Your password must contain only distinct characters";
            public static string ErrorContainsAtLeastOneCharacterAsLowercaseText = "Your password must contain at least one lowercase character";
            public static string ErrorContainsAtLeastOneCharacterAsUppercaseText = "Your password must contain at least one uppercase character";
        }
    }
}
