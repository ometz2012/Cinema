using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ometz.Cinema.UI.ContentPages.Users.PaymentMVP
{
    public class PaymentPresenter
    {
        public IPaymentView PaymentView { get; set; }

        public PaymentPresenter(IPaymentView MyView)
        {
            PaymentView = MyView;
            PaymentView.LoadData += LoadData;
            PaymentView.Submit += Submit;

        }

        private void LoadData(PerformanceDataArgs pda)
        {
 
        }

        private void Submit(OrderArgs or)
        {

        }
    }

    //=========DELEGATES=============

    public delegate void DataLoadHandler(PerformanceDataArgs pda);
    public delegate void ButtonSubmitHandler( OrderArgs or);


    //==========Event Args==============

    public class PerformanceDataArgs:EventArgs
    {
        public String PerformanceID {get;set;}

    }

    public class OrderArgs:EventArgs
    {
        public int NumberOfSeats { get; set; }
        public decimal TotalPrice { get; set; }
        public int PerformanceID { get; set; }
        public String UserID { get; set; }
    }
}