using Xunit;
using Moq;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Fiap.Api.DesastresNaturais.Controllers;
using Fiap.Api.DesastresNaturais.Services;
using Fiap.Api.DesastresNaturais.Models;
using Fiap.Api.DesastresNaturais.ViewModel;

public class DesastreNaturalControllerTests
{
    [Fact]
    public void Get_ReturnsHttpStatusCode200()
    {
        // Arrange
        var mockService = new Mock<IDesastreNaturalService>();
        var mockMapper = new Mock<IMapper>();

        var desastreList = new List<RegistrarDesastreNaturalModel>
        {
            new RegistrarDesastreNaturalModel { DesastreNaturalId = 1, TipoDesastre = "Terremoto" }
        };

        var viewModelList = new List<DesastreNaturalViewModel>
        {
            new DesastreNaturalViewModel { DesastreNaturalId = 1, TipoDesastre = "Wnchente" }
        };

        mockService.Setup(s => s.ListarDesastreNatural()).Returns(desastreList);
        mockMapper.Setup(m => m.Map<IEnumerable<DesastreNaturalViewModel>>(It.IsAny<IEnumerable<RegistrarDesastreNaturalModel>>()))
                  .Returns(viewModelList);

        var controller = new DesastreNaturalController(mockService.Object, mockMapper.Object);

        // Act
        var result = controller.Get();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(200, okResult.StatusCode);
    }
}
