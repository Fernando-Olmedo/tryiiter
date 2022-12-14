using System.Diagnostics.CodeAnalysis;

namespace tryiiter.Models;

public interface IUser
{
    [ExcludeFromCodeCoverage]
    string Name { get; set; }
    string Email { get; set; }
    string Module { get; set; }
    string Status { get; set; }
    string Password { get; set; } 
}