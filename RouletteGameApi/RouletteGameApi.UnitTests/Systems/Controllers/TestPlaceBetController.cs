using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using RouletteGameApi.Contracts;
using RouletteGameApi.Controllers;
using RouletteGameApi.Entities;
using RouletteGameApi.UnitTests.Fixtures;

namespace RouletteGameApi.UnitTests.Systems.Controllers
{
    public class TestPlaceBetController
    {
        [Fact] 
        public async  Task GetPlacedBets_InvockesPlaceBetRepositoryExactlyOnce(){
            //Arrange
            var MockPlaceBetRepository = new  Mock<IRepositoryWrapper>();
            MockPlaceBetRepository
                .Setup(service => service.PlaceBet.GetPlacedBets())
                  .ReturnsAsync(PlacedBetsFixture.GetTestPlacesBets());


            var mock = new Mock<ILogger<PlaceBetController>>();
            ILogger<PlaceBetController> logger = mock.Object;

            var sut = new PlaceBetController( MockPlaceBetRepository.Object, logger);
            //Act 
            var result = (OkObjectResult)await sut.GetPlacedBets();
            //Assert
           MockPlaceBetRepository.Verify(
               service => service.PlaceBet.GetPlacedBets(), 
               Times.Once()
            );
        }
        [Fact]
        public async Task GetPlacedBets_OnSuccess_ReturnsListOfPlacedBets()
        {
            //Arrange
            var MockPlaceBetRepository = new Mock<IRepositoryWrapper>();
            MockPlaceBetRepository
                .Setup(service => service.PlaceBet.GetPlacedBets())
                  .ReturnsAsync(PlacedBetsFixture.GetTestPlacesBets()); 


            var mock = new Mock<ILogger<PlaceBetController>>();
            ILogger<PlaceBetController> logger = mock.Object;

            var sut = new PlaceBetController(MockPlaceBetRepository.Object, logger);
           
            //Act 
            var result = await sut.GetPlacedBets();

            //Assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<List<PlaceBet>>();
        }

        [Fact]
        public async Task GetPlacedBets_OnNoPlacedBets_Returns404()
        {
            //Arrange
            var MockPlaceBetRepository = new Mock<IRepositoryWrapper>();
            MockPlaceBetRepository
                .Setup(service => service.PlaceBet.GetPlacedBets())
                  .ReturnsAsync(new List<PlaceBet>());


            var mock = new Mock<ILogger<PlaceBetController>>();
            ILogger<PlaceBetController> logger = mock.Object;

            var sut = new PlaceBetController(MockPlaceBetRepository.Object, logger);

            //Act 
            var result = await sut.GetPlacedBets();

            //Assert
            result.Should().BeOfType<NotFoundResult>();
         
        }
        //[Fact]
        //public async void GetPayout_OnSucces_ReturnsSaatusCode200()
        //{
        //    //Arrange
        //    var sut = new PlaceBetController();

        //    //Act
        //    var result = (OkObjectResult)await sut.Get();

        //    //Assert
        //    result.StatusCode.Should().Be(200);

        //}
    } 
}