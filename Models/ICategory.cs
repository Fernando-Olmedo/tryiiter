using System.Diagnostics.CodeAnalysis;

namespace tryiiter.Models;

public interface ICategory
{
    [ExcludeFromCodeCoverage]
    // public int Id { get; set; }
    public string Name { get; set; }
}