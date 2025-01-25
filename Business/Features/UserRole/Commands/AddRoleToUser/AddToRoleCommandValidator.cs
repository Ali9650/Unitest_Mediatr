
using FluentValidation;

namespace Business.Features.UserRole.Commands.AddRoleToUser
{
    public class AddToRoleCommandValidator : AbstractValidator<AddRoleToUserCommand>
    {
        public AddToRoleCommandValidator()
        {
            RuleFor(x => x.UserId)
               .NotEmpty().WithMessage("User id bos ola bilmez");

            RuleFor(x => x.RoleId)
                .NotEmpty().WithMessage("Role id bos ola bilmez");
        }
    }
}
