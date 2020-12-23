using System;
using System.Collections.Generic;
using BaltaShop.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class PlaceOrderCommand : Notifiable, ICommand
    {
        public PlaceOrderCommand()
        {
            OrderItems = new List<OrderItemCommand>();
        }
        public Guid Customer { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }

        public bool ValidCommand()
        {
            AddNotifications(
                new ValidationContract()
                    .Requires()
                    .HasLen(Customer.ToString(), 36, "Customer", "Identificador do cliente inválido")
                    .IsGreaterThan(OrderItems.Count, 0, "Itens", "Pedido sem items")
            );

            return true;
        }
    }

    public class OrderItemCommand
    {
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }
    }
}