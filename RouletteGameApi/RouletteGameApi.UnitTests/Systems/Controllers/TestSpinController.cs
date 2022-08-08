using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RouletteGameApi.UnitTests.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RouletteGameApi.UnitTests.Systems.Controllers
{
   //public  class TestSpinController
   // {
    //    [Fact]
    //    public async Task GetPreviousSpins_InvockesSpinRepositoryExactlyOnce()
    //    {
    //        //Arrange
          
    //        var MockSpinRepository = new Mock<IRepositoryWrapper>();
    //        MockSpinRepository
    //            .Setup(service => service.spin.GetPreviousSpins())
    //                 .ReturnsAsync(SpinsData.GetPreviousSpins());

    //        var sut = new SpinController(MockSpinRepository.Object);
    //        //Act 
    //        var result = await sut.GetPreviousSpins();
    //        //Assert
    //        MockSpinRepository.Verify(
    //            service => service.spin.GetPreviousSpins(),
    //            Times.Once()
    //         );
    //    }
    //    [Fact]
    //    public async Task GetPreviousSpin_OnSuccess_ResultsList()
    //    {
    //        //Arrange
    //        var MockSpinRepository = new Mock<IRepositoryWrapper>();
    //        MockSpinRepository
    //            .Setup(service => service.spin.GetPreviousSpins())
    //              .ReturnsAsync(SpinsData.GetPreviousSpins());

    //        var sut = new SpinController(MockSpinRepository.Object);

    //        //Act 
    //        var result = await sut.GetPreviousSpins();

    //        //Assert
    //        var objectResult = (OkObjectResult)result;
    //        objectResult.Value.Should().BeOfType<List<Spin>>();
    //    }

    //    [Fact]
    //    public async Task GetPlacedBets_OnNoSpins_Returns404()
    //    {
    //        //Arrange
    //        Spin spin = new Spin();
    //        var MockSpinRepository = new Mock<IRepositoryWrapper>();
    //        MockSpinRepository
    //            .Setup(service => service.spin.SpinWheel(spin))
    //              .ReturnsAsync(new Spin());

    //        var sut = new SpinController(MockSpinRepository.Object);
    //        //Act 
    //        var result = await sut.Get();

    //        //Assert
    //        result.Should().BeOfType<NotFoundResult>();

    //    }
    //}
}
