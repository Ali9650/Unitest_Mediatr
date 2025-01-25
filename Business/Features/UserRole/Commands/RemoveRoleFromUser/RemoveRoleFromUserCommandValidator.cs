using FluentValidation;

namespace Business.Features.UserRole.Commands.RemoveRoleFromUser
{
    public class RemoveRoleFromUserCommandValidator :AbstractValidator<RemoveRoleFromUserCommand>
    {
        public RemoveRoleFromUserCommandValidator()
        {
            RuleFor(x => x.UserId)
             .NotEmpty().WithMessage("User id bos ola bilmez");

            RuleFor(x => x.RoleId)
                .NotEmpty().WithMessage("Role id bos ola bilmez");
        }
    }
}
