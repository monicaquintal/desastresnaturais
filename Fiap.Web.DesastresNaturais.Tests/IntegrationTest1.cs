using IdentityModel.Client;
using System.Net;
using System.Net.Http;

namespace Fiap.Web.DesastresNaturais.Tests.Tests
{
    public class IntegrationTest1
    {}


        // Instructions:
        // 1. Add a project reference to the target AppHost project, e.g.:
        //
        //    <ItemGroup>
        //        <ProjectReference Include="../MyAspireApp.AppHost/MyAspireApp.AppHost.csproj" />
        //    </ItemGroup>
        //
        // 2. Uncomment the following example test and update 'Projects.MyAspireApp_AppHost' to match your AppHost project:
        // 
        // [Fact]
        // public async Task GetWebResourceRootReturnsOkStatusCode()
        // {
        //     // Arrange
        //     var appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.MyAspireApp_AppHost>();
        //     await using var app = await appHost.BuildAsync();
        //     await app.StartAsync();

        //     // Act
        //     var httpClient = app.CreateHttpClient("webfrontend");
        //     var response = await httpClient.GetAsync("/");

        //     // Assert
        //     Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        // }

        // [Fact]
        // public void VerificaMaioridade_DeveRetornarTrueSeMaiorDeIdade()
        // {
        // Arrange
        // var dataNascimento = new DateTime(2000, 1, 1); // Uma pessoa nascida em 01/01/2000
        // var hoje = DateTime.Now;
        // var maioridade = hoje.Year - dataNascimento.Year;
        //  if (dataNascimento > hoje.AddYears(-maioridade))
        // maioridade--;
        // Act
        // var ehMaiorDeIdade = maioridade >= 18;

        // Assert
        // Assert.True(ehMaiorDeIdade);
        // }
    }