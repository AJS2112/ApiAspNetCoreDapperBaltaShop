using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class DocumentTests
    {
        private Document validDocument;
        private Document invalidDocument;

        public DocumentTests()
        {
            validDocument = new Document("123456789");
            invalidDocument = new Document("");
        }
        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsNotValid()
        {
            var document = invalidDocument;
            Assert.AreEqual(false, document.Valid);
            Assert.AreEqual(1, document.Notifications.Count);
        }
        [TestMethod]
        public void ShouldNotReturnNotificationWhenDocumentIsNotValid()
        {
            var document = validDocument;
            Assert.AreEqual(true, document.Valid);
            Assert.AreEqual(0, document.Notifications.Count);
        }
    }
}
