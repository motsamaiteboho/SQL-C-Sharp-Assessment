using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RouletteGameApi.Contracts;
using RouletteGameApi.Controllers;
using RouletteGameApi.Entities;
using RouletteGameApi.UnitTests.Fixtures;
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
            var MockPayoutRepository = new Mock<IRepositoryWrapper>();
            MockPayoutRepository
                .Setup(service => service.Payout.GetPayout(1))
                  .ReturnsAsync(PayoutFixture.Payout());

            var sut = new PayoutController(MockPayoutRepository.Object);
            //Act 
            var result = (OkObjectResult)await sut.GetPayout(1);
            //Assert
            MockPayoutRepository.Verify(
                service => service.Payout.GetPayout(1),
                Times.Once()
             );
        }
        [Fact]
        public async Task GetPlacedBets_OnSuccess_ReturnsPayOut()
        {
            //Arrange
            var MockPayoutRepository = new Mock<IRepositoryWrapper>();
            MockPayoutRepository
                .Setup(service => service.Payout.GetPayout(1))
                  .ReturnsAsync(PayoutFixture.Payout());

            var sut = new PayoutController(MockPayoutRepository.Object);

            //Act 
            var result = await sut.GetPayout(1);

            //Assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<Payout>();
        }

        [Fact]
        public async Task GetPlacedBets_OnNoPayout_Returns404()
        {
            //Arrange
            var MockPayoutRepository = new Mock<IRepositoryWrapper>();
            MockPayoutRepository
                .Setup(service => service.Payout.GetPayout(0))
                  .ReturnsAsync(new Payout());

            var sut = new PayoutController(MockPayoutRepository.Object);

            //Act 
            var result = await sut.GetPayout(1);

            //Assert
            result.Should().BeOfType<NotFoundResult>();

        }
    }
}
