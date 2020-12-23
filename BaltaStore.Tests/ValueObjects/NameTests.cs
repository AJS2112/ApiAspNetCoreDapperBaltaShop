using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class NameTests
    {
        private Name validName;
        private Name invalidName;

        public NameTests()
        {
            validName = new Name("Antonio", "Sucre");
            invalidName = new Name("Antonio", "");
        }
        [TestMethod]
        public void ShouldReturnNotificationWhenNameIsNotValid()
        {
            var name = invalidName;
            Assert.AreEqual(false, name.Valid);
        }

    }
}
