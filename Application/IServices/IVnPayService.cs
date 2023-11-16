using Application.ViewModels.VnPayViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IVnPayService
    {
        public string CreatePaymentUrl(PaymentInformationModel model, HttpContext context);
        public PaymentResponseModel PaymentExecute(IQueryCollection collections);
    }
}
