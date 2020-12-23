using BaltaStore.Domain.StoreContext.Entities;

namespace BaltaShop.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);

    }
}