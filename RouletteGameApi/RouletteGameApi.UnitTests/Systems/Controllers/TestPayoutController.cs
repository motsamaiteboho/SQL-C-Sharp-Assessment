using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RouletteGameApi.Presentation.Controllers;
using RouletteGameApi.UnitTests.Fixtures;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RouletteGameApi.UnitTests.Systems.Controllers
{
    public class TestPayoutController
    {
        [Fact]
        public async Task GetPayout_InvockesPayoutRepositoryExactlyOnce()
        {
            //Arrange
            var MockPayoutRepository = new Mock<IServiceManager>();
            MockPayoutRepository
                .Setup(service => service.PayoutService.GetAllPayoutsAsync(
                    new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                   new Guid("c8d4c053-49b6-410c-bc78-2d54a9891870"),false))
                  .ReturnsAsync(PayoutFixture.GetAllPayouts());

            var sut = new PayoutController(MockPayoutRepository.Object);

            //Act 
            var result = (OkObjectResult)await sut.GetPayouts(
                   new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                   new Guid("c8d4c053-49b6-410c-bc78-2d54a9891870") );

            //Assert
            MockPayoutRepository.Verify(
                service => service.PayoutService.GetAllPayoutsAsync(
                    new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                   new Guid("c8d4c053-49b6-410c-bc78-2d54a9891870"),
                   false ),
                Times.Once()
             );
        }
        [Fact]
        public async Task GetAllAsync_ShouldReturn200Status()
        {   
            //Arrange
            var MockPayoutRepository = new Mock<IServiceManager>();
            MockPayoutRepository
                .Setup(service => service.PayoutService.GetAllPayoutsAsync(
                    new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                   new Guid("c8d4c053-49b6-410c-bc78-2d54a9891870"), false))
                  .ReturnsAsync(PayoutFixture.GetAllPayouts());

            var sut = new PayoutController(MockPayoutRepository.Object);

            //Act 
            var result = (OkObjectResult)await sut.GetPayouts(
                   new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                   new Guid("c8d4c053-49b6-410c-bc78-2d54a9891870"));

            //Assert 
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetPayoutAsync_ShouldReturn200Status()
        {
            //Arrange
            var payoutService = new Mock<IServiceManager>();
            payoutService.Setup(_ => _.PayoutService.GetPayoutAsync(
                new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
               new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
               new Guid("c8d4c053-49b6-410c-bc78-2d54a9891870"),
                false))
                .ReturnsAsync(PayoutFixture.GetPayout(new Guid("80abbca8-664d-4b20-b5de-024705497d4a")));

            var sut = new PayoutController(payoutService.Object);

            //Act
            var result = (OkObjectResult)await sut.GetPayout(
                new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
               new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
               new Guid("c8d4c053-49b6-410c-bc78-2d54a9891870"));

            //Assert 
            result.StatusCode.Should().Be(200);
        }
    }
}
