using PasswordChallenge.Core.Entities;
using PasswordChallenge.Core.Resources;
using PasswordChallenge.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PasswordChallenge.Test
{
    [TestClass]
    public class PasswordTest
    {
        [TestMethod]
        public void PasswordHasAtLeastNineCharacters()
        {
            Assert.IsTrue(new Password("Abc123456!@#", new CharactersModule()).ErrorHandling.IsValid);
            
            Assert.IsFalse(new Password("Ab1!", new CharactersModule()).ErrorHandling.IsValid);
        }
        [TestMethod]
        public void PasswordHasAtMostSeventySevenCharacters()
        {
            Assert.IsTrue(new Password("ABCDEFGHIJKLMNOPQRSTUVWYXZabcdefghijklmnopqrstuvwyxz0123456789!@#$%^&*()-+", new CharactersModule()).ErrorHandling.IsValid);
            
            Assert.IsFalse(new Password("ABCDEFGHIJKLMNOPQRSTUVWYXZabcdefghijklmnopqrstuvwyxz0123456789!@#$%^&*()-+A", new CharactersModule()).ErrorHandling.IsValid);
        }
        [TestMethod]
        public void PasswordHasAllValidCharacters()
        {
            Assert.IsTrue(new Password("ABCDEFGHIJKLMNOPQRSTUVWYXZabcdefghijklmnopqrstuvwyxz0123456789!@#$%^&*()-+", new CharactersModule()).ErrorHandling.IsValid);

            Assert.IsFalse(new Password("ÂBCDEFGHIJKLMNOPQRSTUVWYXZabcdefghijklmnopqrstuvwyxz0123456789!@#$%^&*()-+", new CharactersModule()).ErrorHandling.IsValid);

            Assert.AreEqual(new Password("ÂBCDEFGHIJKLMNOPQRSTUVWYXZabcdefghijklmnopqrstuvwyxz0123456789!@#$%^&*()-+", new CharactersModule()).ErrorHandling.ValidationErrors[0], Localization.Password.ErrorContainsOnlyCharacterOfCollectionText);
            
        }
        [TestMethod]
        public void PasswordHasAtLeastOneNumericCharacter()
        {
            Assert.IsTrue(new Password("Abc12345!@", new CharactersModule()).ErrorHandling.IsValid);
           
            Assert.IsFalse(new Password("ABCDEFGHIJKa!@#$%^&*()-+", new CharactersModule()).ErrorHandling.IsValid);

            Assert.AreEqual(new Password("ABCDEFGHIJKa!@#$%^&*()-+", new CharactersModule()).ErrorHandling.ValidationErrors[0], Localization.Password.ErrorContainsAtLeastOneCharacterOfCollectionText);
        }
        
        [TestMethod]
        public void PasswordHasAtLeastOneSpecialCharacter()
        {
            Assert.IsTrue(new Password("Abc12345!@", new CharactersModule()).ErrorHandling.IsValid);

            Assert.IsFalse(new Password("Abc1234567", new CharactersModule()).ErrorHandling.IsValid);

            Assert.AreEqual(new Password("Abc1234567", new CharactersModule()).ErrorHandling.ValidationErrors[0], Localization.Password.ErrorContainsAtLeastOneCharacterOfCollectionText);
        }

        [TestMethod]
        public void PasswordHasAtLeastOneUpperCaseCharacter()
        {
            Assert.IsTrue(new Password("Abc12345!@", new CharactersModule()).ErrorHandling.IsValid);

            Assert.IsFalse(new Password("abc12345!@", new CharactersModule()).ErrorHandling.IsValid);
        }

        [TestMethod]
        public void PasswordHasAtLeastOneLowerCaseCharacter()
        {
            Assert.IsTrue(new Password("Abc12345!@", new CharactersModule()).ErrorHandling.IsValid);

            Assert.IsFalse(new Password("ABC12345!@", new CharactersModule()).ErrorHandling.IsValid);

            Assert.AreEqual(new Password("ABC12345!@", new CharactersModule()).ErrorHandling.ValidationErrors[0], Localization.Password.ErrorContainsAtLeastOneCharacterAsLowercaseText);
        }

        [TestMethod]
        public void PasswordDoesntHaveWhiteSpaces()
        {
            Assert.IsTrue(new Password("Abc12345!@", new CharactersModule()).ErrorHandling.IsValid);

            Assert.IsFalse(new Password("ABC12 345!@", new CharactersModule()).ErrorHandling.IsValid);
            Assert.IsFalse(new Password(" ABC12345!@", new CharactersModule()).ErrorHandling.IsValid);
            Assert.IsFalse(new Password("ABC12345!@ ", new CharactersModule()).ErrorHandling.IsValid);

            Assert.AreEqual(new Password("ABC12345!@ ", new CharactersModule()).ErrorHandling.ValidationErrors[0], Localization.Password.ErrorNotContainWhiteSpacesText);
        }

        [TestMethod]
        public void PasswordHasOnlyDistinctValues()
        {
            Assert.IsTrue(new Password("Abc12345!@", new CharactersModule()).ErrorHandling.IsValid);

            Assert.IsFalse(new Password("AAbc12345!@", new CharactersModule()).ErrorHandling.IsValid);

            Assert.AreEqual(new Password("AAbc12345!@", new CharactersModule()).ErrorHandling.ValidationErrors[0], Localization.Password.ErrorContainsOnlyDistinctCharactersText);
        }

    }
}
