using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using FluentValidator;
using BaltaShop.Shared.Commands;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Domain.StoreContext.Entities;
using System;
using BaltaShop.Domain.StoreContext.Repositories;
using BaltaShop.Domain.StoreContext.Services;


namespace BaltaShop.StoreContext.Handlers
{
    public class CustomerHandler :
        Notifiable,
        ICommandHandler<CreateCustomerCommand>,
        ICommandHandler<AddAddressCommand>
    {

        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;
        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }
        public ICommandResult Handle(CreateCustomerCommand command)
        {
            // Verificar se o CPF existe na base
            if (_repository.CheckDocument(command.Document))
                AddNotification("Document", "Este CPF já está em uso");

            // Verificar se o email existe no banco
            if (_repository.CheckEmail(command.Email))
                AddNotification("Email", "Este Email já está em uso");

            // Criar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            // Criar a entidade
            var customer = new Customer(name, document, email, command.Phone);

            // Validad Entidade e VOs
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);
            if (!Invalid)
                return null;

            // Persistir o cliente
            _repository.Save(customer);

            // Enviar o email de boas vindas
            _emailService.Send(email.Address, "ajs21@gmail.com", "Ben vindo", "Seja ben vindo ao Store!");

            // Retornar resultado para tela
            return new CreateCustomerCommandResult(customer.Id, name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}