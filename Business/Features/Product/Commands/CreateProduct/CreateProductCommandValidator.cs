using FluentValidation;

namespace Business.Features.Product.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("ad daxil edin");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("say azi 1 olmalidir");
            RuleFor(X => X.Price).GreaterThan(0).WithMessage("qiymet 0dan boyuk olmalidir ");
            RuleFor(x => x.Description).MinimumLength(8).MaximumLength(100).WithMessage("mehsul haqqinda melumat xarakterlerin sayi 8 - 100 olmalidir");
            RuleFor(x => x.Type).IsInEnum().WithMessage("Type yanlis formatdadir");

            RuleFor(x => x.Photo).NotEmpty().WithMessage("foto daxil edin");
            RuleFor(x => x.Photo).Must(IsCorrrectFormat).WithMessage("yanlis format");
        }
        private bool IsCorrrectFormat(string photo)
        {

            try
            {
                _ = Convert.FromBase64String(photo);
                var data = photo.Substring(0, 5);
                switch (data.ToUpper())
                {
                    case "IVBOR":
                    case "/9J/4":
                        return true;
                    default:
                        return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
