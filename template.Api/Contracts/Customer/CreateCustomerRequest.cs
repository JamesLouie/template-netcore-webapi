using FluentValidation;

namespace template.Api.Contracts.Customer
{
    public class CreateCustomerRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Domain.Entities.Customer ToDomain()
        {
            return new Domain.Entities.Customer
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = (Email != null) ? new Domain.ValueObjects.Email(Email) : null,
                PhoneNumber = PhoneNumber
            };
        }

        public class Validator : AbstractValidator<CreateCustomerRequest>
        {
            public Validator()
            {
                RuleFor(x => x.FirstName).NotEmpty();
                RuleFor(x => x.LastName).NotEmpty();
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.PhoneNumber);
            }
        }
    }
}
