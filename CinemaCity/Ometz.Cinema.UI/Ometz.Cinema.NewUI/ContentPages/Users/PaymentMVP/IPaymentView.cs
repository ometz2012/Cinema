using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ometz.Cinema.UI.ContentPages.Users.PaymentMVP
{
    public interface IPaymentView
    {
        event DataLoadHandler LoadData;
        event ButtonSubmitHandler Submit;

        PaymentPresenter Presenter { get; set; }
        PaymentModel Model { get; set; }
    }
}
