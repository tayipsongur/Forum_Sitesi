using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    
    // Bu sınıf içerisinde Category sınıfı/tablosu için doğrulama kurallarını yazacağız.
   public class CategoryValidatior:AbstractValidator<Category>  // Category sınıfımızı içine gönderdik.
    {
        public CategoryValidatior()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Alanı Boş Geçilemez. ");  // Kategori name boş olamaz dedik ve mesaj verdik.
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklama Alanı Boş Geçilemez");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lütfen En Az 3 Karakter Girişi Yapın.");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Lütfen 20 Karakterden Fazla Değer Girişi Yapmayın");
         

        }
     

    }
}
