﻿using FluentValidation;
using RentACar.Model;

namespace RentACar.Api.Code.Validations
{
    public class KullaniciValidator : AbstractValidator<Kullanici>
    {

        public KullaniciValidator()
        {
            RuleFor(k => k.Ad).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            //RuleFor(k => k.Ad).EmailAddress().WithMessage("Hatalı email adresi");
            RuleFor(k => k.Parola).Length(6, 15).WithMessage("Şifre en az 6, en çok 15 karakter olabilir");
            RuleFor(k => k.Parola).Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                                 .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                                 .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                                 .Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.).");
        }
    }
}
