using FluentValidation;
using SignalR.DtoLayer.BookingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BussinesLayer.ValidationRules.BookingValidations
{
	public class CreateBookingValidation:AbstractValidator<CreateBookingDto>
	{
        public CreateBookingValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Isim Alani Bos Gecilemez");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon Alani Bos Gecilemez");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Alani Bos Gecilemez");
            RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Kisi Sayisi Alani Bos Gecilemez");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih Alani Bos Gecilemez");

            RuleFor(x=>x.Name).MinimumLength(5).WithMessage("Lutfen Gecerli Bir Isim Giriniz!").MaximumLength(20).WithMessage ("Lutfen Isim Alanina Max 20 Karakter Giriniz");
            RuleFor(x=>x.Description).MaximumLength(100).WithMessage ("Lutfen Aciklama Alanina Max 100 Karakter Giriniz");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Gecerli Bir Email Adresi Giriniz");
        }
    }
}
