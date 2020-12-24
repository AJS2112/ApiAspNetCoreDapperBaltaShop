using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Queries;
using System;
using System.Collections.Generic;

namespace BaltaShop.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);
        CustomerOrdersCountResult GetCustomerOrdersCountResult(string document);

        IEnumerable<ListCustomerQueryResult> Get();

        GetCustomerQueryResult Get(Guid id);

        IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id);

    }
}