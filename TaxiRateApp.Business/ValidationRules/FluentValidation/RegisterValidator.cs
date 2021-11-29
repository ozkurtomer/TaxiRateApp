using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiRateApp.Entities.Dtos;

namespace TaxiRateApp.Business.ValidationRules.FluentValidation
{
    public class RegisterValidator : AbstractValidator<UserForRegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(x=>x.UserName).NotEmpty().WithMessage("Ad soyad kısmı boş geçilemez");
            RuleFor(x => x.UserUserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            RuleFor(x => x.UserUserName).MinimumLength(2);
            RuleFor(x => x.UserEmail).NotEmpty().WithMessage("E-Posta boş geçilemez");
            RuleFor(x => x.UserPassword).NotEmpty().WithMessage("Şifre kısmı boş geçilemez");

        }
    }
}
