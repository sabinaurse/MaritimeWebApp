using Xunit;
using MaritimeWebApp.Server.Controllers;
using MaritimeWebApp.Server.Data;
using MaritimeWebApp.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MaritimeWebApp.Tests
{
    public class ShipsControllerTests
    {
        private MaritimeDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<MaritimeDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;

            var context = new MaritimeDbContext(options);
            context.Ships.Add(new Ship { Id = 1, Name = "Titanic", MaxSpeed = 24.5f });
            context.SaveChanges();
            return context;
        }

        [Fact]
        public async Task GetAll_ReturnsAllShips()
        {
            var context = GetDbContext();
            var controller = new ShipsController(context);

            var result = await controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var ships = Assert.IsAssignableFrom<IEnumerable<Ship>>(okResult.Value);
            Assert.Single(ships);
        }
    }
}
