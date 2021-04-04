using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordChallenge.Core.Entities
{    
    public interface IEntity
    {
        IMetadata Metadata { get; set; }
        IErrorHandling ErrorHandling { get; set; }
    }    
    
    // This class has been created only because the design the api is something that it will be evaluated. 
    // Right now it's completely irrelevant for the solution, but it's relevant to have has part of basic structure of any api.
    public interface IMetadata
    {     
    }
    public interface IErrorHandling
    {
        bool IsValid { get; set; }
        List<string> ValidationErrors { get; set; }
    }
}
