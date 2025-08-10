using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeyMer.Domain.Dtos.User;

namespace ZeyMer.Application.Validators
{

    public class UserRegisterValidator : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("İsim boş olamaz")
                .MinimumLength(3).WithMessage("İsim en az 3 karakter olmalı");
            RuleFor(x => x.LastName)
              .NotEmpty().WithMessage("Soyisim boş olamaz")
              .MinimumLength(3).WithMessage("Soyisim en az 3 karakter olmalı");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email boş olamaz")
                .EmailAddress().WithMessage("Geçerli bir email girin");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre boş olamaz")
                .MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalı");
        }
    }
}
