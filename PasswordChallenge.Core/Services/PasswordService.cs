using PasswordChallenge.Core.Entities;
using PasswordChallenge.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordChallenge.Core.Services
{
    public class PasswordService
    {
        public Password CreatePassword(string password, ICharactersModule charactersModule) {
            return new Password(password, charactersModule);
        }

    }
}
