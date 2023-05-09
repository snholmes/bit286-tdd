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
            List<Spin> spins = new List<Spin>();
            Spin s1 = new Spin();
            Player p1 = new Player { Luck = s1.Numbers[0] }; // a winner
            s1.Player = p1;
            spins.Add(s1);
            var mockRepo = new Mock<SpinRepository>();
            mockRepo.Setup(r => r.GetSpins()).Returns(spins);
            var service = new SpinService(mockRepo.Object);

            //Act
            var average = service.averageWins();

            //Assert
            Assert.Equal(1, average);


        }
    }
}
