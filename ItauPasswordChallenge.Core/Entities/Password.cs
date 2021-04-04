using ItauPasswordChallenge.Core.Behaviors;
using ItauPasswordChallenge.Core.Resources;
using ItauPasswordChallenge.Infrastructure;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using System.Text;

namespace ItauPasswordChallenge.Core.Entities
{
    // In the proposed challenge the expected return is only a Boolean value, however, 
    // as the design of the api is part of one of the evaluated items, I thought 
    // it would be nice to have a basic return structure.    
    public class Password : IEntity
    {
        private ICharactersModule _charactersModule;

        public Password(string password, ICharactersModule charactersModule)
        {
            if (password == null) { throw new ArgumentNullException(); }
            
            if (charactersModule == null) { throw new ArgumentNullException(); }

            _charactersModule = charactersModule;

            Result.Value = password;

            ErrorHandling.IsValid = new PasswordValidationBehavior(this, _charactersModule).IsValid();
        }

        public PasswordResult Result { get; set; } = new PasswordResult();
        public IMetadata Metadata { get; set; } = new PasswordMetadata();
        public IErrorHandling ErrorHandling { get; set; } = new PasswordErrorHandling();

    }

    public class PasswordResult
    {
        public string Value { get; set; }
    }
    public class PasswordMetadata : IMetadata
    {

    }
    public class PasswordErrorHandling : IErrorHandling
    {
        public bool IsValid { get; set; }

        public List<string> ValidationErrors { get; set; } = new List<string>();
    }
}
