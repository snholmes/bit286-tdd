using System;
using Xunit;
using Moq;
using LuckySpin.Repositories;
using System.Collections.Generic;
using LuckySpin.Models;
using LuckySpin.Services;

namespace LuckySpin.Test
{
    public class SpinServiceTest
    {
        [Fact]
        public void SpinServiceTest_averageWins()
        {
            //Assign
            var mockRepo = new Mock<SpinRepository>();
            //mockRepo.Setup(r => r.GetSpins()).Returns(new List<Spin>());
            var service = new SpinService(mockRepo.Object);

            //Act
            var average = service.averageWins();

            //Assert
            Assert.Equal(3, average);


        }
    }
}
