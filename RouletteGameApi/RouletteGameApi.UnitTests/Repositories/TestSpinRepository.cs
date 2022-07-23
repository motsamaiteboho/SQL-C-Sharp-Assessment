﻿using FluentAssertions;
using Moq;
using Moq.Protected;
using RouletteGameApi.Contracts;
using RouletteGameApi.Entities;
using RouletteGameApi.Repository;
using RouletteGameApi.UnitTests.Fixtures;
using RouletteGameApi.UnitTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RouletteGameApi.UnitTests.Repositories
{
   public class TestSpinRepository
    {
        [Fact]
        public async Task GetSpin_WhenCalled_ReturnsSpin()
        {
            //Arrange
            var expectedResponse = PlacedBetsFixture.GetTestPlacesBets();
            var handleMock = MockhttpMessageHandler<PlaceBet>.SetupBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handleMock.Object);
            var sut = new SpinRepository();

            //Act
            var result = await sut.SpinWheel(SpinFixture.Spin());

            //Assert
            result.Should().BeOfType<Spin>();
        }
        [Fact]
        public async Task GetAllpreviousSpins_WhenCalled_ReturnsListOfSpins()
        {
            //Arrange
            var expectedResponse = PlacedBetsFixture.GetTestPlacesBets();
            var handleMock = MockhttpMessageHandler<PlaceBet>.SetupBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handleMock.Object);
            var sut = new SpinRepository();

            //Act
            var result = await sut.GetPreviousSpins();

            //Assert
            result.Should().BeOfType<List<Spin>>();
        }
    }
        
}
