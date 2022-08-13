using Entities.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Moq;
using RouletteGameApi.Presentation.Controllers;
using RouletteGameApi.UnitTests.Fixtures;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RouletteGameApi.UnitTests.Systems.Controllers
{
    public class TestSpinController 
    {
       [Fact]
       public async Task GetAllAsync_ShouldReturn200Status()
        {
            //Arrange
            var  spinService = new Mock<IServiceManager>();
            spinService.Setup(_ => _.SpinService.GetAllSpinsAsync(false))
                .ReturnsAsync(SpinsFixture.GetAllSpins());
            var sut  = new SpinsController(spinService.Object);

            //Act
            var result = (OkObjectResult)await sut.GetSpins();

            //Assert 
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetSpinAsync_ShouldReturn200Status()
        {
            //Arrange
            var spinService = new Mock<IServiceManager>();
            spinService.Setup(_ => _.SpinService.GetSpinAsync(new Guid("c8d4c053-49b6-410c-bc78-2d54a9891870"),false))
                .ReturnsAsync(SpinsFixture.GetSpin(new Guid("c8d4c053-49b6-410c-bc78-2d54a9891870")));

            var sut = new SpinsController(spinService.Object);

            //Act
            var result = (OkObjectResult)await sut.GetSpin(new Guid("c8d4c053-49b6-410c-bc78-2d54a9891870"));

            //Assert 
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetNextSpinAsync_ShouldReturn200Status()
        {
            //Arrange
            var spinService = new Mock<IServiceManager>();
            spinService.Setup(_ => _.SpinService.GetSpinAsync(new Guid("c8d4c053-49b6-410c-bc78-2d54a9891870"), false))
                .ReturnsAsync(SpinsFixture.GetNextSpin());

            var sut = new SpinsController(spinService.Object);

            //Act
            var result = (OkObjectResult)await sut.GetSpin(new Guid("c8d4c053-49b6-410c-bc78-2d54a9891870"));

            //Assert 
            result.StatusCode.Should().Be(200);
        }

    }
}
