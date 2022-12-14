using System.Net;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Testing;
using tryiiter.Models;
using tryiiter.Utils;

namespace TryiiterTest.TestController;

public class TestCategoryController : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private const string controllerName = "category";
    
    public TestCategoryController(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }
    
    [Theory(DisplayName = "Teste para Categories com Status Ok")]
    [InlineData("Mayara", "Modulo 1", "email@email.com", "123456")]
    public async Task TestGetCategoriesSuccess(string name, string module, string email, string password)
    {
        //Arrange
        var webClient = _factory.CreateClient();
        var user = new User();
        user.Name = name;
        user.Module = module;
        user.Email = email;
        user.Password = password;

        //Act
        var generatedToken = TokenGenerator.Generate(user);
        webClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", generatedToken);
        var response = await webClient.GetAsync("api/Category/Categories");

        //Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
    
    
    [Theory(DisplayName = "Teste para Categories com Status Unauthorized")]
    [InlineData("INVALIDTOKEN")]
    public async Task TestGetCategoriesFail(string invalidToken)
    {   
        //Arrange
        var webClient = _factory.CreateClient();

        //Act
        webClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", invalidToken);
        var response = await webClient.GetAsync("api/Category/Categories");

        //Assert
        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }
    
}