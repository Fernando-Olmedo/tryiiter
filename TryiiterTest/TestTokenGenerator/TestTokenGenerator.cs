using tryiiter.Models;
using tryiiter.Utils;

namespace TryiiterTest.TestTokenGenerator;

public class TestTokenGenerator
{
    /// <summary>
    /// Test function that validates if Token is being generated, if it is not returning null or empty
    /// </summary>
    [Theory(DisplayName = "Teste para TokenGenerator em que token não é nulo")]
    [InlineData("Mayara", "Modulo 1", "email@email.com", "123456")]
    public void TestTokenGeneratorSuccess(string name, string module, string email, string password)
    {
        //Arrange
        var user = new User();
        user.Name = name;
        user.Module = module;
        user.Email = email;
        user.Password = password;

        //Act
        var generateToken = TokenGenerator.Generate(user);

        //Assert
        generateToken.Should().NotBeNullOrEmpty();
    }
    
    /// <summary>
    /// Test function that validates if Token is being generated according to JWT methodology, having 3 keys.
    /// </summary>
    [Theory(DisplayName = "Teste para TokenGenerator em que token JWT possui 3 partes")]
    [InlineData("Mayara", "Modulo 1", "email@email.com", "123456")]
    public void TestTokenGeneratorKeysSuccess(string name, string module, string email, string password)
    {
        //Arrange
        var user = new User();
        user.Name = name;
        user.Module = module;
        user.Email = email;
        user.Password = password;

        //Act
        var generateToken = TokenGenerator.Generate(user);
        var splitedToken = generateToken.Split('.');
        
        //Assert
        splitedToken.Length.Should().Be(3);
    }
}