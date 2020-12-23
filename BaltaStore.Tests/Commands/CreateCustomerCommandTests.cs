using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class CreateCustomerCommandTest
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();

            command.FirstName = "Antonio";
            command.LastName = "Sucre";
            command.Document = "01234567890";
            command.Email = "ajs21br@gmail.com";
            command.Phone = "5555789789";


            Assert.AreEqual(true, command.ValidCommand());
        }

    }
}
