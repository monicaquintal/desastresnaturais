using Xunit;
using Moq;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Fiap.Api.DesastresNaturais.Controllers;
using Fiap.Api.DesastresNaturais.Services;
using Fiap.Api.DesastresNaturais.Models;
using Fiap.Api.DesastresNaturais.ViewModel;

public class UsuarioControllerTests
{
    [Fact]
    public void Get_ReturnsHttpStatusCode200()
    {
        // Arrange
        var mockService = new Mock<IUsuarioService>();
        var mockMapper = new Mock<IMapper>();

        var usuarioList = new List<UsuarioModel>
        {
            new UsuarioModel { UsuarioId = 1, Nome = "Usuario A" }
        };

        var viewModelList = new List<UsuarioViewModel>
        {
            new UsuarioViewModel { UsuarioId = 1, Nome = "Usuario A" }
        };

        mockService.Setup(s => s.ListarUsuarios()).Returns(usuarioList);
        mockMapper.Setup(m => m.Map<IEnumerable<UsuarioViewModel>>(It.IsAny<IEnumerable<UsuarioModel>>()))
                  .Returns(viewModelList);

        var controller = new UsuarioController(mockService.Object, mockMapper.Object);

        // Act
        var result = controller.Get();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(200, okResult.StatusCode);
    }
}
