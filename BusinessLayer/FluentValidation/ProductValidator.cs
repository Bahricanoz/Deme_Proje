using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ürün adını boş geçemezsiniz");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Ürün adı en az 3 karakter olamaldır");
            RuleFor(x => x.Stock).NotEmpty().WithMessage("Stok mikatarını boş geçemezsiniz");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat alaını boş geçemezsiniz");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("0 dan küçük olamaz");
            RuleFor(x => x.Stock).GreaterThan(0).WithMessage("0 dan küçük olamaz");


        }
    }
}
