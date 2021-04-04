using ItauPasswordChallenge.Core.Entities;
using ItauPasswordChallenge.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItauPasswordChallenge.Core.Services
{
    public class PasswordService
    {
        public Password CreatePassword(string password, ICharactersModule charactersModule) {
            return new Password(password, charactersModule);
        }

    }
}
