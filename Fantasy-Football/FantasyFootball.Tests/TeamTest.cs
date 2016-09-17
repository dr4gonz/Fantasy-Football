using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Fantasy_Football.Models;


namespace FantasyFootball.Tests
{
    public class TeamTest
    {
        [Fact]
        public void Get_TeamName_Test()
        {
            //Arrange
            var team = new Team();

            //Act
            team.Name = "Team 1";
            var result = team.Name;

            //Assert
            Assert.Equal("Team 1", result);
        }
    }
}
