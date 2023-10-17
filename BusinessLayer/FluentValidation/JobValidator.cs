using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class JobValidator: AbstractValidator<Job>
    {
        public JobValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen meslek alaını boş geçmeyiniz");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz");
        }
    }
}
