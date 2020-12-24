using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        [Route("customers")]
        public List<Customer> Get()
        {
            var name = new Name("Antonio", "Sucre");
            var document = new Document("70870129244");
            var email = new Email("ajs21br@gmail.com");
            var customer = new Customer(name, document, email, "55555");
            var customers = new List<Customer>();
            customers.Add(customer);

            return customers;
        }

        [HttpGet]
        [Route("customers/{id}")]
        public Customer GetById(Guid id)
        {
            var name = new Name("Antonio", "Sucre");
            var document = new Document("70870129244");
            var email = new Email("ajs21br@gmail.com");
            var customer = new Customer(name, document, email, "55555");

            return customer;
        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public List<Order> GetOrders()
        {
            var name = new Name("Antonio", "Sucre");
            var document = new Document("70870129244");
            var email = new Email("ajs21br@gmail.com");
            var customer = new Customer(name, document, email, "55555");
            var order = new Order(customer);

            var mouse = new Product("Mouse Gamer", "Mouse Gamer", "_mouse.jpg", 100M, 10);
            var monitor = new Product("Monitor Gamer", "Mouse Gamer", "_mouse.jpg", 100M, 10);

            order.AddItem(monitor, 5);
            order.AddItem(mouse, 5);

            order.Place();

            var orders=new List<Order>();
            orders.Add(order);


            return orders;
        }

        [HttpPost]
        [Route("customers")]
        public Customer Post([FromBody]CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);

            return customer;
        }

        [HttpPut]
        [Route("customers/{id}")]
        public Customer Put(Guid id, [FromBody] CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);

            return customer;
        }

        [HttpDelete]
        [Route("customers/{id}")]
        public object Delete()
        {
            return new { message = "Cliente removido com sucesso!"};
        }
    }
}
