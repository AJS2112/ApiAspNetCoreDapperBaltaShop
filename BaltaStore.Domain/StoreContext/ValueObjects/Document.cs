using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.ValueObjects
{
    public class Document : Notifiable
    {
        public Document(string number)
        {
            Number = number;

            AddNotifications(new ValidationContract()
                .IsTrue(Validate(Number), "Document", "CPF Inválido")
            );
        }
        public string Number { get; private set; }

        public override string ToString()
        {
            return $"{Number}";
        }

        public bool Validate(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return false;

            // if (int.Parse(cpf) < 0)
            //     return false;

            return true;
        }
    }
}