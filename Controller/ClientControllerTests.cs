using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using WebAPI.Controllers;
using WebAPI.Data;
using WebAPI.Entities;
using FakeItEasy;

namespace WebAPI_unitTesting.Controller
{
    public class ClientControllerTests
    {   
        [Fact]
        public void ClientController_Get_ResultOk()
        {
            //Arrange         
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new DataContext(options);

            var controller = new ClientController(databaseContext);

            //Act
            var result = controller.Get();

            //Assert
            result.Should().NotBeNull();            

        }
        [Fact]
        public void ClientController_AddClient_ResultOk()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<DataContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;
            var databaseContext = new DataContext(options);
            var client = A.Fake<Client>();
            var controller = new ClientController(databaseContext);
            //Act
            var result = controller.AddClient(client);
            //Assert
            result.Should().NotBeNull();

        }
        [Fact]
        public void ClientController_UpdateClient_ResultOk()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<DataContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;
            var databaseContext = new DataContext(options);
            var updateclient = A.Fake<Client>();
            
            var controller = new ClientController(databaseContext);
            //Act
            var result = controller.UpdateClient(updateclient);
            //Assert
            result.Should().NotBeNull();

        }
        [Fact]
        public void ClientController_DeleteClient_ResultOk()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<DataContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;
            var databaseContext = new DataContext(options);           
            var id = 1;
            var controller = new ClientController(databaseContext);
            //Act
            var result = controller.DeleteClient(id);
            //Assert
            result.Should().NotBeNull();

        }
    }
}
