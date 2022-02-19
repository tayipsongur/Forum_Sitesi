using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class WriterValidator: AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Boş Geçilemez. ");  // Kategori name boş olamaz dedik ve mesaj verdik.
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadı Boş Geçilemez.");
            RuleFor(x => x.WriterAbout).MaximumLength(50).WithMessage("Hakkımda Kısmını Boş Geçemezsiniz.");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Girişi Yapınız.");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Lütfen 50 Karakterden Fazla Değer Girişi Yapmayın");
            RuleFor(x => x.WriterName).Must(x => x != null && x.Contains("A")).WithMessage("İsminizde 'A/a' Harfi Kullanmalısınız");
       


        }



    }
}
