using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class OrderTests
    {
        private Customer _customer;
        private Order _order;
        private Product _mouse;
        private Product _keyboard;
        private Product _chair;
        private Product _monitor;

        public OrderTests()
        {
            var name = new Name("Antonio", "Sucre");
            var document = new Document("70870129244");
            var email = new Email("ajs21br@gmail.com");
            _customer = new Customer(name, document, email, "55555");
            _order = new Order(_customer);

            _mouse = new Product("Mouse Gamer", "Mouse Gamer", "_mouse.jpg", 100M, 10);
            _keyboard = new Product("Teclado Gamer", "Teclado Gamer", "_mouse.jpg", 100M, 10);
            _chair = new Product("Cadeira Gamer", "Cadeira Gamer", "_mouse.jpg", 100M, 10);
            _monitor = new Product("Monitor Gamer", "Mouse Gamer", "_mouse.jpg", 100M, 10);

        }

        //Consigo criar um novo pedido
        [TestMethod]
        public void ShouldCreateOrderWhenValid()
        {
            Assert.AreEqual(true, _order.Valid);
        }

        // Ao criar o pedido o status deve ser created
        [TestMethod]
        public void StatusShouldBeCreatedWhenOrderCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        // Ao adicionar um novo item, a quantidade deve mudar
        [TestMethod]
        public void ShouldReturnTwoWhenAddedTwoValidItems()
        {
            _order.AddItem(_monitor, 5);
            _order.AddItem(_mouse, 5);

            Assert.AreEqual(2, _order.Items.Count);
        }

        // Ao adicionar um novo item, deve subtrair a quantidade de produto
        [TestMethod]
        public void ShouldReturnFiveWhenAddedPurchasedFiveItem()
        {
            _order.AddItem(_monitor, 5);

            Assert.AreEqual(_monitor.QuantityOnHand, 5);
        }

        // Ao confirmar o pedido deve gerar um numero
        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlaced()
        {
            _order.Place();
            Assert.AreNotEqual("", _order.Number);
        }

        // Ao pagar o pedido, o status deve ser pago
        [TestMethod]
        public void ShouldReturnPaidWhenOrderPaid()
        {
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);

        }

        // Dados mais 10 produtos devem haver duas entregas
        [TestMethod]
        public void ShouldReturnTwoShippingsWhenPurchasedTenProducts()
        {
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.Ship();

            Assert.AreEqual(2, _order.Deliveries.Count);
        }

        // Ao cancelar o pedido, o status deve ser cancelado
        [TestMethod]
        public void StatusShouldBeCanceledWhenOrderCanceled()
        {
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        // Ao cancelar o pedido, deve cancelar as entregas
        [TestMethod]
        public void ShouldCancelShippingWhenOrderCanceled()
        {
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.Ship();

            _order.Cancel();

            foreach (var item in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, item.Status);
            }

        }

        public void CreateCustomer()
        {
            // Verifica se o CPF já existe
            // Verifica se o Email já existe
            // Criar os VOs
            // Criar a entidade
            // Validar as entidades e VOs
            // Inserir o cliente no banco
            // Envia convite do Slack
            // Envia um Email de boas vidas
        }

    }
}
